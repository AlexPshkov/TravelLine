namespace SQL_Task_2.sys.storage.entities.implementation;

public class Citizen : AbstractEntity
{
    public int FlatId; //foreign field ref

    public string FirstName;
    public string LastName;
    
    public Citizen( int uuid ) : base( uuid )
    {
        FlatId = 0;
        FirstName = "Empty";
        LastName = "Empty";
    }
    
    public Citizen( int uuid, int flatId, string firstName, string lastName ) : base( uuid )
    {
        FlatId = flatId;
        FirstName = firstName;
        LastName = lastName;
    }
}