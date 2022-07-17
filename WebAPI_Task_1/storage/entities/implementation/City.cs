namespace WebAPI_Task_1.storage.entities.implementation;

public class City : AbstractEntity
{
    public string Country;
    public string Region;
    public string CityName;

    public City() : base( 0 )
    {
        Country = "Empty";
        Region = "Empty";
        CityName = "Empty";
    }
    public City( int uuid, string country, string region, string cityName ) : base( uuid )
    {
        Country = country;
        Region = region;
        CityName = cityName;
    }
}