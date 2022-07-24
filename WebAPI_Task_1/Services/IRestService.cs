using WebAPI_Task_1.Dto;
using WebAPI_Task_1.Dto.implementation;

namespace WebAPI_Task_1.Services;

public interface IRestService
{
 
    /**
     * Loads all entities of some type from storage
     */
    public List<object> GetAllFromStorage( string entityName );

    /**
     * Loads entity data from storage
     */
    public AbstractDto ? GetFromStorage( string entityName, int entityId );

    /**
     * Deletes entity from storage
     */
    public int DeleteFromStorage( string entityName, int entityId );

    /**
     * Updates entity in storage
     */
    public int UpdateInStorage( string entityName, object dtoBody );
    
    /**
     * Gets Citizens in houses where floorsNumber >= 10
     */
    public List<CitizenDto> GetCitizensInSkyscrapers();
}