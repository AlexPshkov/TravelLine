using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.storage.entities;
using WebAPI_Task_1.storage.entities.implementation;

namespace WebAPI_Task_1.Extensions;

public static class HouseExtension
{
    public static HouseDto ConvertToDto( this AbstractEntity abstractEntity, CityDto ?  cityDto )
    {
        var house = (House) abstractEntity;
        return new HouseDto()
        {
            Uuid = house.UUID,
            StreetName = house.StreetName,
            HouseNumber = house.HouseNumber,
            FloorsNumber = house.FloorsNumber,
            City = cityDto
        };
    } 
    
    public static House ConvertToDomainObject( this HouseDto houseDto )
    {
        return new House()
        {
            UUID = houseDto.Uuid,
            StreetName = houseDto.StreetName ?? throw new InvalidOperationException(),
            HouseNumber = houseDto.HouseNumber ?? throw new InvalidOperationException(),
            FloorsNumber = houseDto.FloorsNumber,
            CityId = houseDto.City?.Uuid ?? 0
        };
    }
}