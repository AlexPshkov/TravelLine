using System.Text;
using MySqlConnector;
using SQL_Task_2.sys.storage.entities;

namespace SQL_Task_2.sys.storage.implementation.sql;

public static class SqlHelper
{

    /**
     * Convers fields list to string
     * Example: SELECT `First`, `Seconds`, ...
     */
    public static string ConvertFieldsToSelectString( List<SqlField> fields )
    {
        var stringBuilder = new StringBuilder("SELECT "); 
        fields.ForEach( field => stringBuilder.Append('`').Append( field.FieldName ).Append( "`, " ) );
        return  stringBuilder.ToString()[..(stringBuilder.Length - 2)];
    }
    
    /**
     * Convers fields list to string
     * Example: SET `First` = @first, `Seconds` = @second, ...
     */
    public static string ConvertFieldsToSetString( List<SqlField> fields )
    {
        var stringBuilder = new StringBuilder( "SET" );
        fields.ForEach( field =>
            stringBuilder.Append( " `" ).Append( field.FieldName ).Append( "` = @" )
                .Append( field.FieldName.ToLower() ).Append( ',' ) );
        return stringBuilder.ToString()[..( stringBuilder.Length - 17 )]; 
    }
    

    
    /**
     * Get fields
     */
    public static List<SqlField> GetSqlFields( AbstractEntity abstractEntity )
    {
        List<SqlField> fields = new();
        foreach ( var fieldInfo in abstractEntity.GetType().GetFields() ) //Handle all fields in class
        {
            var fieldName = fieldInfo.Name.ToLower();
            var fieldValue = fieldInfo.GetValue( abstractEntity );

            if ( fieldValue == null )
            {
                Console.WriteLine( "SKIP NULL FIELD " + fieldName );
                continue;
            }

            switch ( fieldValue ) //Handle different types of parameters
            {
                case int value:
                {
                    fields.Add( new SqlField( fieldName, value, MySqlDbType.Int32 ));
                    break;
                }
                case string value:
                {
                    fields.Add( new SqlField( fieldName, value, MySqlDbType.VarChar ));
                    break;
                }
                default:
                    Console.WriteLine( "SKIP INVALID FILED TYPE " + fieldName );
                    continue;
            }
        }
            
        return fields;
    }

    /**
     * Gets table name from entity class name
     */
    public static string GetTableName( Type abstractEntityType )
    {
        return '`' + abstractEntityType.Name + '`';
    }
    
}