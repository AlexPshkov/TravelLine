using Microsoft.EntityFrameworkCore;
using WebAPI_ORM.storage.entities;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.storage.sql.implementation
{
    public class SqliteRepository : IRepository
    {
        private readonly CityMapContext _dbContext;

        public SqliteRepository( CityMapContext dbContext )
        {
            _dbContext = dbContext;
        }
        
        
        /**
         * Loads all entities from storage
         */
        public Citizen ?  LoadCitizenWithSuchCard( string cardUID )
        {
            return _dbContext.Citizen?.AsQueryable().FirstOrDefault( citizen => citizen.CardUID!.Equals( cardUID ) );
        }

        
        /**
         * Loads all entities from storage
         */
        public IEnumerable<T> LoadAllFromStorage<T>() where T: AbstractEntity
        {
            return typeof( T ).Name.ToLower() switch
            {
                "city" =>  (IEnumerable<T>)_dbContext.City!.ToList(),
                "house" => (IEnumerable<T>)_dbContext.House!.ToList(),
                "flat" => (IEnumerable<T>)_dbContext.Flat!.ToList(),
                "citizen" => (IEnumerable<T>)_dbContext.Citizen!.ToList(),
                _ => throw new ApplicationException( "Internal error. No such entity" )
            };
        }

        /**
         * Loads one entity from storage
         */
        public T ? LoadFromStorage<T>( int uuid ) where T : AbstractEntity
        {
            return typeof( T ).Name.ToLower() switch
            {
                "city" =>  _dbContext.City!.SingleOrDefault( elem => elem.Uuid == uuid) as T,
                "house" => _dbContext.House!.SingleOrDefault( elem => elem.Uuid == uuid) as T,
                "flat" => _dbContext.Flat!.SingleOrDefault( elem => elem.Uuid == uuid) as T,
                "citizen" => _dbContext.Citizen!.SingleOrDefault( elem => elem.Uuid == uuid) as T,
                _ => throw new ApplicationException( "Internal error. No such entity" )
            };
        }

        /**
         * Deletes object
         */
        public int DeleteFromStorage( AbstractEntity entity )
        {
            AbstractEntity result = entity.GetType().Name.ToLower() switch
            {
                "city" =>  _dbContext.City!.Remove((City)entity).Entity,
                "house" => _dbContext.House!.Remove((House)entity).Entity,
                "flat" => _dbContext.Flat!.Remove((Flat)entity).Entity,
                "citizen" => _dbContext.Citizen!.Remove((Citizen)entity).Entity,
                _ => throw new ApplicationException( "Internal error. No such entity" )
            }; 
            return _dbContext.SaveChanges();
        }

        /**
         * Creates object
         */
        public int CreateInStorage( AbstractEntity entity )
        {
            AbstractEntity result = entity.GetType().Name.ToLower() switch
            {
                "city" =>  _dbContext.City!.Add((City)entity).Entity,
                "house" => _dbContext.House!.Add((House)entity).Entity,
                "flat" => _dbContext.Flat!.Add((Flat)entity).Entity,
                "citizen" => _dbContext.Citizen!.Add((Citizen)entity).Entity,
                _ => throw new ApplicationException( "Internal error. No such entity" )
            };
            return _dbContext.SaveChanges();
        }

        /**
         * Updates object
         */
        public int UpdateInStorage( AbstractEntity entity )
        {
            AbstractEntity result = entity.GetType().Name.ToLower() switch
            {
                "city" =>  _dbContext.City!.Update((City)entity).Entity,
                "house" => _dbContext.House!.Update((House)entity).Entity,
                "flat" => _dbContext.Flat!.Update((Flat)entity).Entity,
                "citizen" => _dbContext.Citizen!.Update((Citizen)entity).Entity,
                _ => throw new ApplicationException( "Internal error. No such entity" )
            };
            return _dbContext.SaveChanges();
        }
    }
}
