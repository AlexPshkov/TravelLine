namespace SQL_Task_2.storage.sql;

public class SqlField 
{
    public readonly string FieldName;
    public readonly object ? FieldValue;

    public SqlField( string fieldName, object ? fieldValue )
    {
        FieldName = fieldName;
        FieldValue = fieldValue;
    }
    
}