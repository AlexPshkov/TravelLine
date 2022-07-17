namespace WebAPI_Task_1.storage.entities.implementation;

public class Citizen : AbstractEntity
{
    public int FlatId; //foreign field ref

    public string FirstName;
    public string LastName;
    
    public Citizen() : base( 0 )
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