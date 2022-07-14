namespace SQL_Task_2.sys.storage.entities.implementation;

public class City : AbstractEntity
{
    public string Country;
    public string Region;
    public string CityName;

    public City( int uuid ) : base( uuid )
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