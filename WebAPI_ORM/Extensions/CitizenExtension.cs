using WebAPI_ORM.Dto.implementation;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.Extensions;

public static class CitizenExtension 
{
    
    public static CitizenDto ConvertToDto( this Citizen citizen )
    {
        return new CitizenDto
        {
            Uuid = citizen.Uuid,
            FirstName = citizen.FirstName,
            LastName = citizen.LastName,
            CardUID = citizen.CardUID,
            Flat = citizen.Flat?.ConvertToDto()
        };
    } 
    
    public static Citizen ConvertToDomainObject( this CitizenDto citizenDto )
    {
        return new Citizen()
        {
            Uuid = citizenDto.Uuid,
            FirstName = citizenDto.FirstName ?? throw new InvalidOperationException(),
            LastName = citizenDto.LastName ?? throw new InvalidOperationException(),
            CardUID = citizenDto.CardUID,
            FlatUuid = citizenDto.Flat?.Uuid ?? throw new ArgumentException("Foreign key null")
        };
    }
}