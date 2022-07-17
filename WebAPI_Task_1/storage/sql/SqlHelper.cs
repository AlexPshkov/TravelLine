using System.Data.Common;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySqlConnector;
using WebAPI_Task_1.storage.entities;

namespace WebAPI_Task_1.storage.sql;

public static class SqlHelper
{
    
    /**
     * Makes SQL parameter from name and its value
     */
    public static DbParameter MakeSqlParameter<T>( string name, object ?  value ) where T: DbConnection
    {
        return typeof( T ).Name switch
        {
            nameof( SqlConnection ) => new SqlParameter(name, value),
            nameof( MySqlConnection ) => new MySqlParameter(name, value),
            nameof( SqliteConnection ) => new SqliteParameter(name, value),
            _ => throw new ApplicationException( "Invalid connection type" )
        };
    }
    
    /**
     * Converts fields list to string
     * Example: First, Second, ...
     */
    public static string ConvertFieldsToString( List<SqlField> fields )
    {
        var stringBuilder = new StringBuilder(); 
        fields.ForEach( field => stringBuilder.Append( field.FieldName ).Append( ", " ) );
        return stringBuilder.ToString()[..(stringBuilder.Length - 2)];
    }

    /**
     * Converts fields list to string
     * Example: SET First = @first, Seconds = @second, ...
     */
    public static string ConvertFieldsToSetString( List<SqlField> fields )
    {
        var stringBuilder = new StringBuilder( "SET" );
        fields.ForEach( field =>
            stringBuilder.Append( ' ' ).Append( field.FieldName ).Append( " = @" )
                .Append( field.FieldName.ToLower() ).Append( ',' ) );
        return stringBuilder.ToString()[..( stringBuilder.Length - 15 )];
    }
    
    /**
     * Get fields
     */
    public static List<SqlField> GetRequiredEntityFields( AbstractEntity abstractEntity )
    {
        List<SqlField> fields = new();
        foreach ( var fieldInfo in abstractEntity.GetType().GetFields() ) //Handle all fields in class
        {
            var fieldName = fieldInfo.Name.ToLower();
            var fieldValue = fieldInfo.GetValue( abstractEntity );
            fields.Add( new SqlField( fieldName, fieldValue ));
        }
        return fields;
    }

    /**
     * Gets table name from entity class name
     */
    public static string GetTableName( AbstractEntity abstractEntity )
    {
        return abstractEntity.GetType().Name;
    }
}