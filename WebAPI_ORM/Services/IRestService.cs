using System.Text.Json;
using WebAPI_ORM.Dto;
using WebAPI_ORM.Dto.implementation;

namespace WebAPI_ORM.Services;

public interface IRestService
{
 
    /**
     * Parse json to DTO
     */
    public T ? ParseToDto<T>( JsonElement jsonElement ) where T : AbstractDto;

    /**
     * Loads all entities of some type from storage
     */
    public List<object> GetAllFromStorage( string entityName );

    /**
     * Loads entity data from storage
     */
    public object ? GetFromStorage( string entityName, int entityId );

    /**
     * Deletes entity from storage
     */
    public int DeleteFromStorage( string entityName, int entityId );

    /**
     * Updates entity in storage
     */
    public int UpdateInStorage( string entityName, JsonElement dtoBody );

    /**
     * Creates entity in storage
     */
    public int CreateInStorage( string entityName, JsonElement dtoBody );

    /**
     * Gets citizen with such cardUID
     */
    public CitizenDto ? GetCitizenWithSuchCard( string cardUID );
}