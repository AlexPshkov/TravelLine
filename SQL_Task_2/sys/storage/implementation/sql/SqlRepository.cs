using MySqlConnector;
using SQL_Task_2.sys.storage.entities;
using SQL_Task_2.sys.storage.entities.implementation;

namespace SQL_Task_2.sys.storage.implementation.sql;

public class SqlRepository : IRepository
{
    private const string
        SqlConnectionString = "server=localhost;user=root;password=123456;database=CityMap"; //MySQL connection

    /**
     * Loads all entities of some type from storage
     */
    public Task<List<T>> LoadAllFromStorage<T>( T reqEntity, string condition = "") where T : AbstractEntity
    {
        return Task.Run( () =>
        {
            List<T> entitiesList = new();
            using var connection = new MySqlConnection( SqlConnectionString );
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            var fields = SqlHelper.GetSqlFields( reqEntity );

            sqlCommand.CommandText =
                $" { SqlHelper.ConvertFieldsToSelectString( fields ) } FROM { SqlHelper.GetTableName( reqEntity.GetType() ) } { condition }";

            using MySqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                foreach ( var fieldInfo in reqEntity.GetType().GetFields() )
                {
                    var value = reader[fieldInfo.Name];
                    if ( value is DBNull ) value = null;
                    fieldInfo.SetValue( reqEntity, value); 
                }
                entitiesList.Add( (T)reqEntity.Clone() );
            }

            return entitiesList;
        } );
        
    }
    
    /**
     * Loads entity data from storage
     * TODO Make normal new class instance creation
     */
    public Task<T ?> LoadFromStorage<T>( T reqEntity ) where T : AbstractEntity
    {
        return Task.Run( () =>
        {
            using var connection = new MySqlConnection( SqlConnectionString );
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            var fields = SqlHelper.GetSqlFields( reqEntity );

            sqlCommand.CommandText =
                $" { SqlHelper.ConvertFieldsToSelectString( fields ) } FROM { SqlHelper.GetTableName( reqEntity.GetType() ) } WHERE `UUID` = @uuid";
            sqlCommand.Parameters.Add( "@uuid", MySqlDbType.Int32 ).Value = reqEntity.UUID; //SQL-Injection block

            using MySqlDataReader reader = sqlCommand.ExecuteReader();
            if ( !reader.Read() ) return null;
            
            foreach ( var fieldInfo in reqEntity.GetType().GetFields() )
            {
                var value = reader[fieldInfo.Name];
                if ( value is DBNull ) value = null;
                fieldInfo.SetValue( reqEntity, value); 
            }
            return reqEntity;
        } );
    }


    /**
     * Updates entity in storage
     */
    public Task<int> UpdateInStorage( AbstractEntity entity )
    {
        return Task.Run( () =>
        {
            if ( entity == null ) throw new ArgumentNullException( nameof( entity ) );

            using var connection = new MySqlConnection( SqlConnectionString );
            connection.Open();

            using MySqlCommand sqlCommand = connection.CreateCommand();
            var fields = SqlHelper.GetSqlFields( entity );

            sqlCommand.CommandText =
                $"UPDATE {SqlHelper.GetTableName( entity.GetType() )} { SqlHelper.ConvertFieldsToSetString( fields ) } WHERE `UUID` = @uuid";

            foreach ( var sqlField in fields ) //SQL-Injection block
                sqlCommand.Parameters.Add( sqlField.FieldName, sqlField.FieldType ).Value =
                    sqlField.FieldValue; //Add sql parameters
            
            return sqlCommand.ExecuteNonQuery();
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

            using var connection = new MySqlConnection( SqlConnectionString );
            connection.Open();

            using MySqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText =
                $"DELETE FROM { SqlHelper.GetTableName( entity.GetType() ) } WHERE `UUID` = @uuid";
            sqlCommand.Parameters.Add( "@uuid", MySqlDbType.Int32 ).Value = entity.UUID; //SQL-Injection block
            
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
            var bufferEntity = new Citizen( 0 );
            using var connection = new MySqlConnection( SqlConnectionString );
            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText =
                $" SELECT * FROM { SqlHelper.GetTableName( bufferEntity.GetType() ) } JOIN Citymap.Flat ON Citymap.Citizen.FlatId = Citymap.Flat.UUID JOIN Citymap.House ON Citymap.Flat.HouseId = Citymap.House.UUID GROUP BY Citymap.Citizen.UUID HAVING MAX(Citymap.House.FloorsNumber) >= 10";

            using MySqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                foreach ( var fieldInfo in bufferEntity.GetType().GetFields() )
                {
                    var value = reader[fieldInfo.Name];
                    if ( value is DBNull ) value = null;
                    fieldInfo.SetValue( bufferEntity, value); 
                }
                citizens.Add( (Citizen)bufferEntity.Clone() );
            }
            return citizens;
        } );
    }
}