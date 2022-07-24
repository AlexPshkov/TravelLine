using WebAPI_ORM.Dto.implementation;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.Extensions;

public static class HouseExtension
{
    public static HouseDto ConvertToDto( this House house )
    {
        return new HouseDto()
        {
            Uuid = house.Uuid,
            StreetName = house.StreetName,
            HouseNumber = house.HouseNumber,
            FloorsNumber = house.FloorsNumber,
            City = house.City?.ConvertToDto()
        };
    } 
    
    public static House ConvertToDomainObject( this HouseDto houseDto )
    {
        return new House()
        {
            Uuid = houseDto.Uuid,
            StreetName = houseDto.StreetName ?? throw new InvalidOperationException(),
            HouseNumber = houseDto.HouseNumber ?? throw new InvalidOperationException(),
            FloorsNumber = houseDto.FloorsNumber,
            CityUuid = houseDto.City?.Uuid ?? throw new ArgumentException("Foreign key null")
        };
    }
}