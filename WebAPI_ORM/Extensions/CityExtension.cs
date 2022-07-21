using WebAPI_ORM.Dto.implementation;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.Extensions;

public static class CityExtension
{
    public static CityDto ConvertToDto( this City city )
    {
        return new CityDto()
        {
            Uuid = city.Uuid,
            CityName = city.CityName,
            Country = city.Country,
            Region = city.Region
        };
    } 
    
    public static City ConvertToDomainObject( this CityDto cityDto )
    {
        return new City()
        {
            Uuid = cityDto.Uuid,
            CityName = cityDto.CityName ?? throw new InvalidOperationException(),
            Country = cityDto.Country ?? throw new InvalidOperationException(),
            Region = cityDto.Region ?? throw new InvalidOperationException()
        };
    }
}