using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.storage.entities;
using WebAPI_Task_1.storage.entities.implementation;

namespace WebAPI_Task_1.Extensions;

public static class FlatExtension
{
    public static FlatDto ConvertToDto( this AbstractEntity abstractEntity, HouseDto ?  houseDto )
    {
        var flat = (Flat) abstractEntity;
        return new FlatDto()
        {
            Uuid = flat.UUID,
            FlatNumber = flat.FlatNumber,
            House = houseDto
        };
    } 
    
    public static Flat ConvertToDomainObject( this FlatDto flatDto )
    {
        return new Flat()
        {
            UUID = flatDto.Uuid,
            FlatNumber = flatDto.FlatNumber,
            HouseId = flatDto.House?.Uuid ?? 0
        };
    }
}