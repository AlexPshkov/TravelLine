namespace WebAPI_Task_1.storage.entities.implementation;

public partial class House : AbstractEntity
{
    public int CityId; //foreign field ref

    public string StreetName;
    public int FloorsNumber;
    public string HouseNumber;

    public House() : base( 0 )
    {
        StreetName = "Empty";
        CityId = 0;
        FloorsNumber = 0;
        HouseNumber = "Empty";
    }

    public House( int uuid, int cityId, string streetName, int floorsNumber, string houseNumber) : base( uuid )
    {
        CityId = cityId;
        StreetName = streetName;
        FloorsNumber = floorsNumber;
        HouseNumber = houseNumber;
    }
}