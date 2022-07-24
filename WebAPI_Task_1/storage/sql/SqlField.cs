namespace WebAPI_Task_1.storage.sql;

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