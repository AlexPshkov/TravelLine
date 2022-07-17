using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.storage.entities;
using WebAPI_Task_1.storage.entities.implementation;

namespace WebAPI_Task_1.Extensions.implementation;

public static class CitizenExtension 
{
    
    public static CitizenDto ConvertToDto( this AbstractEntity abstractEntity, FlatDto ?  flatDto )
    {
        var citizen = (Citizen) abstractEntity;
        return new CitizenDto
        {
            Uuid = citizen.UUID,
            FirstName = citizen.FirstName,
            LastName = citizen.LastName,
            Flat = flatDto
        };
    } 
    
    public static Citizen ConvertToDomainObject( this CitizenDto citizenDto )
    {
        return new Citizen()
        {
            UUID = citizenDto.Uuid,
            FirstName = citizenDto.FirstName ?? throw new InvalidOperationException(),
            LastName = citizenDto.LastName ?? throw new InvalidOperationException(),
            FlatId = citizenDto.Flat?.Uuid ?? 0
        };
    }
}