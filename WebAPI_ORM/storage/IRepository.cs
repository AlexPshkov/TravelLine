using WebAPI_ORM.storage.entities;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.storage;

public interface IRepository
{
 
    /**
     * Loads all entities of some type from storage
     */
    public IEnumerable<T> LoadAllFromStorage<T>() where T: AbstractEntity;

    /**
     * Loads entity data from storage
     */
    public T ? LoadFromStorage<T>( int uuid ) where T : AbstractEntity;

    /**
     * Deletes entity from storage
     */
    public int DeleteFromStorage( AbstractEntity entity );

    /**
     * Creates entity in storage
     */
    public int CreateInStorage( AbstractEntity entity );

    /**
     * Updates entity in storage
     */
    public int UpdateInStorage( AbstractEntity entity );

    /**
         * Loads all entities from storage
         */
    public Citizen ? LoadCitizenWithSuchCard( string cardUID );
}