using MySqlConnector;

namespace SQL_Task_2.sys.storage.implementation.sql;

public class SqlField
{
    public readonly string FieldName;
    public readonly object FieldValue;
    public readonly MySqlDbType FieldType;
    
    public SqlField( string fieldName, object fieldValue, MySqlDbType fieldType )
    {
        FieldName = fieldName;
        FieldValue = fieldValue;
        FieldType = fieldType;
    }

    public MySqlDbType GetFieldType()
    {
        return FieldValue switch 
        {
            int => MySqlDbType.Int32,
            string => MySqlDbType.VarChar,
            _ => throw new ArgumentException( "Invalid type for " + FieldName )
        };
    }

    
}