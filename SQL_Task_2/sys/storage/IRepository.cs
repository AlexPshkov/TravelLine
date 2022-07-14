using SQL_Task_2.sys.storage.entities;
using SQL_Task_2.sys.storage.entities.implementation;

namespace SQL_Task_2.sys.storage;

public interface IRepository
{

 /**
     * Gets Citizens in houses where floorsNumber >= 10
     */
 public Task<List<Citizen>> GetCitizensInSkyscrapers(); 
 
    /**
     * Loads all entities of some type from storage
     */
    public Task<List<T>> LoadAllFromStorage<T>( T reqEntity, string condition = "" ) where T : AbstractEntity;
    
    /**
     * Loads entity data from storage
     */
    public Task<T ?> LoadFromStorage<T>( T reqEntity ) where T : AbstractEntity;

    /**
     * Deletes entity from storage
     */
    public Task<int> DeleteFromStorage( AbstractEntity entity );
    
    /**
     * Updates entity in storage
     */
    public Task<int> UpdateInStorage( AbstractEntity entity );
}