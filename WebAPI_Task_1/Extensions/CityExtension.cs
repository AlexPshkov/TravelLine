using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.storage.entities;
using WebAPI_Task_1.storage.entities.implementation;

namespace WebAPI_Task_1.Extensions;

public static class CityExtension
{
    public static CityDto ConvertToDto( this AbstractEntity abstractEntity )
    {
        var city = (City) abstractEntity;
        return new CityDto()
        {
            Uuid = city.UUID,
            CityName = city.CityName,
            Country = city.Country,
            Region = city.Region
        };
    } 
    
    public static City ConvertToDomainObject( this CityDto cityDto )
    {
        return new City()
        {
            UUID = cityDto.Uuid,
            CityName = cityDto.CityName ?? throw new InvalidOperationException(),
            Country = cityDto.Country ?? throw new InvalidOperationException(),
            Region = cityDto.Region ?? throw new InvalidOperationException()
        };
    }
}