using System.Data.Common;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySqlConnector;
using SQL_Task_2.storage.entities;
using SQL_Task_2.storage.entities.implementation;

namespace SQL_Task_2.storage.sql.implementation;

public class SqlRepository<TU>: AbstractRepository, IRepository where TU : DbConnection
{
    private const string RootPath = "..\\..\\..\\";
    private const string SqlScriptsFolder = "SqlScripts\\";
    
    private const string InsertDataScriptName = "INSERT_SOME_DATA";
    private const string InitDbScriptPrefix = "INIT_DB_";
    private const string SqlScriptsExtension = ".sql";
    
    public SqlRepository( string dataBaseName ) : base( dataBaseName )
    {
        InitTables();
    }
    
    /**
     * Gets connection string
     */
    private string GetConnectionString()
    {
        return typeof( TU ).Name switch
        {
            nameof( SqlConnection ) => @$"Server=localhost\SQLEXPRESS;Trusted_Connection=True;Database={DbName}",
            nameof( MySqlConnection ) => @$"server=localhost;user=root;password=123456;database={DbName}",
            nameof( SqliteConnection ) => @$"Data Source=file:{RootPath}{DbName}.sqlite",
            _ => throw new ApplicationException( "Invalid connection type" )
        };
    }

    /**
     * Makes connection
     */
    private TU MakeConnection()
    {
        var connection = (TU)Activator.CreateInstance( typeof( TU ) )!;
        connection.ConnectionString = GetConnectionString();
        return connection;
    }
    
    /**
     * Init tables
     */
    private void InitTables()
    {
        using var connection = MakeConnection();
        connection.Open();

        using var sqlCommand = connection.CreateCommand();
        var sqlTypeName = typeof( TU ).Name.Replace( "Connection", "" ).ToUpper();

        var scriptPath = $"{SqlScriptsFolder}{InitDbScriptPrefix}{sqlTypeName}{SqlScriptsExtension}";
        try
        {
            sqlCommand.CommandText = File.ReadAllText( $"{RootPath}{scriptPath}" );
            sqlCommand.ExecuteNonQuery();
        }
        catch ( FileNotFoundException )
        {
            throw new ApplicationException($"Can't find init script. Please make {scriptPath}");
        }
    }

    /**
     * Fill with some data
     */
    public void FillWithSomeData()
    {
        using var connection = MakeConnection();
        connection.Open();

        using var sqlCommand = connection.CreateCommand();
        const string scriptPath = $"{SqlScriptsFolder}{InsertDataScriptName}{SqlScriptsExtension}";
        try
        {
            sqlCommand.CommandText = File.ReadAllText( $"{RootPath}{scriptPath}", Encoding.UTF8 );
            sqlCommand.ExecuteNonQuery();
        }
        catch ( FileNotFoundException )
        {
            throw new ApplicationException($"Can't find insert data script. Please make {scriptPath}");
        }
    }
    
    /**
     * Loads all entities of some type from storage
     */
    public Task<List<T>> LoadAllFromStorage<T>( T entity, string condition = "" ) where T : AbstractEntity
    {
        return Task.Run( () =>
        {
            List<T> entitiesList = new();
            using var connection = MakeConnection();
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            var fields = SqlHelper.GetRequiredEntityFields( entity );

            sqlCommand.CommandText =
                $" {SqlHelper.ConvertFieldsToSelectString( fields )} FROM {SqlHelper.GetTableName( entity )} {condition}";

            using var reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                var resultEntity = (T) entity.Clone();
                foreach ( var fieldInfo in resultEntity.GetType().GetFields() )
                {
                    var value = reader[fieldInfo.Name];
                    if ( value is DBNull ) value = null;
                    if ( value is Int64 ) value = Convert.ToInt32( value );
                    fieldInfo.SetValue( resultEntity, value );
                }
                entitiesList.Add( resultEntity );
            }

            return entitiesList;
        } );
    }

    /**
     * Loads entity data from storage
     */
    public Task<T ?> LoadFromStorage<T>( T entity ) where T : AbstractEntity
    {
        return Task.Run( () =>
        {
            using var connection = MakeConnection();
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            var fields = SqlHelper.GetRequiredEntityFields( entity );

            sqlCommand.CommandText =
                $" {SqlHelper.ConvertFieldsToSelectString( fields )} FROM {SqlHelper.GetTableName( entity )} WHERE UUID = @uuid";
            sqlCommand.Parameters.Add(
                SqlHelper.MakeSqlParameter<TU>( "@uuid", entity.UUID ) ); //SQL-Injection block

            using var reader = sqlCommand.ExecuteReader();
            if ( !reader.Read() ) return null;

            var resultEntity = (T) entity.Clone();
            foreach ( var fieldInfo in resultEntity.GetType().GetFields() )
            {
                var value = reader[fieldInfo.Name];
                if ( value is DBNull ) value = null;
                if ( value is Int64 ) value = Convert.ToInt32( value );
                fieldInfo.SetValue( resultEntity, value );
            }

            return resultEntity;
        } );
    }


    /**
     * Updates entity in storage
     */
    public Task<int> UpdateInStorage( AbstractEntity entity )
    {
        return Task.Run( () =>
        {
            try
            {
                if ( entity == null ) throw new ArgumentNullException( nameof( entity ) );

                using var connection = MakeConnection();
                connection.Open();

                using var sqlCommand = connection.CreateCommand();
                var fields = SqlHelper.GetRequiredEntityFields( entity );

                sqlCommand.CommandText =
                    $"UPDATE {SqlHelper.GetTableName( entity )} {SqlHelper.ConvertFieldsToSetString( fields )} WHERE `UUID` = @uuid";

                foreach ( var sqlField in fields ) //SQL-Injection block
                    sqlCommand.Parameters.Add(
                        SqlHelper.MakeSqlParameter<TU>( sqlField.FieldName, sqlField.FieldValue ) ); //Add sql parameters

                return sqlCommand.ExecuteNonQuery();
            }
            catch ( Exception e )
            {
                Console.WriteLine( e );
                throw;
            }
            
        } );
    }

    /**
     * Deletes entity from storage
     */
    public Task<int> DeleteFromStorage( AbstractEntity entity )
    {
        return Task.Run( () =>
        {
            if ( entity == null ) throw new ArgumentNullException( nameof( entity ) );

            using var connection = MakeConnection();
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText =
                $"DELETE FROM {SqlHelper.GetTableName( entity )} WHERE UUID = @uuid";
            sqlCommand.Parameters.Add( SqlHelper.MakeSqlParameter<TU>( "@uuid", entity.UUID ) ); //SQL-Injection block

            return sqlCommand.ExecuteNonQuery();
        } );
    }

    /**
     * Gets Citizens in houses where floorsNumber >= 10
     */
    public Task<List<Citizen>> GetCitizensInSkyscrapers() //Statistic method with GROUP
    {
        return Task.Run( () =>
        {
            List<Citizen> citizens = new();
            var bufferEntity = new Citizen();
            using var connection = MakeConnection();
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText =
                $" SELECT * FROM {SqlHelper.GetTableName( bufferEntity )} JOIN Flat ON Citizen.FlatId = Flat.UUID JOIN House ON Flat.HouseId = House.UUID GROUP BY Citizen.UUID HAVING MAX(House.FloorsNumber) >= 10";

            using var reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                foreach ( var fieldInfo in bufferEntity.GetType().GetFields() )
                {
                    var value = reader[fieldInfo.Name];
                    if ( value is DBNull ) value = null;
                    fieldInfo.SetValue( bufferEntity, value );
                }

                citizens.Add( (Citizen)bufferEntity.Clone() );
            }

            return citizens;
        } );
    }
}