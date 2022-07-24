using WebAPI_ORM.Dto.implementation;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.Extensions;

public static class FlatExtension
{
    public static FlatDto ConvertToDto( this Flat flat )
    {
        return new FlatDto()
        {
            Uuid = flat.Uuid,
            FlatNumber = flat.FlatNumber,
            House = flat.House.ConvertToDto()
        };
    } 
    
    public static Flat ConvertToDomainObject( this FlatDto flatDto )
    {
        return new Flat()
        {
            Uuid = flatDto.Uuid,
            FlatNumber = flatDto.FlatNumber,
            HouseUuid = flatDto.House?.Uuid ?? throw new ArgumentException("Foreign key null")
        };
    }
}