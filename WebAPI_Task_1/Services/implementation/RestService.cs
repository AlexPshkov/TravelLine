using WebAPI_Task_1.Dto;
using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.Extensions;
using WebAPI_Task_1.Extensions.implementation;
using WebAPI_Task_1.storage;
using WebAPI_Task_1.storage.entities;
using WebAPI_Task_1.storage.entities.implementation;
using WebAPI_Task_1.storage.sql;

namespace WebAPI_Task_1.Services.implementation;

public class RestService : IRestService
{
    private readonly IRepository _repository;

    public RestService( IRepository repository )
    {
        _repository = repository;
    }

    public List<object> GetAllFromStorage( string entityName )
    {
        var list = _repository.LoadAllFromStorage( GetEntityByName( entityName ) ).Result;

        var resultList = new List<object>();
        switch ( entityName )
        {
            case "city":
            {
                list.ForEach( item => resultList.Add( ((City)item).ConvertToDto() ));
                return resultList;
            }
            case "house":
            {
                list.ForEach( item =>
                {
                    var foreignDtoField = GetCityDto((House)item);
                    resultList.Add( item.ConvertToDto(foreignDtoField) );
                } );
                return resultList;
            }
            case "flat":
            {
                list.ForEach( item =>
                {
                    var foreignDtoField = GetHouseDto((Flat)item);
                    resultList.Add( item.ConvertToDto(foreignDtoField) );
                } );
                return resultList;
            }
            case "citizen":
            {
                list.ForEach( item =>
                {
                    var foreignDtoField = GetFlatDto((Citizen)item);
                    resultList.Add( item.ConvertToDto(foreignDtoField) );
                } );
                return resultList;
            }
            default: throw new ApplicationException( "Internal error. No such entity" );
        }
    }

    public AbstractDto GetFromStorage( string entityName, int entityId )
    {
        var reqEntity = GetEntityByName( entityName );
        reqEntity.UUID = entityId;
        var entity = _repository.LoadFromStorage( reqEntity ).Result;
        if ( entity == null ) throw new ArgumentException( "No such field in table" );
        return entityName switch
        {
            "city" => entity.ConvertToDto(),
            "house" => entity.ConvertToDto( GetCityDto( (House)entity ) ),
            "flat" => entity.ConvertToDto( GetHouseDto( (Flat)entity ) ),
            "citizen" => entity.ConvertToDto( GetFlatDto( (Citizen)entity ) ),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
    }

    /**
     * Deletes entity from storage
     */
    public int DeleteFromStorage( string entityName, int entityId )
    {
        var reqEntity = GetEntityByName( entityName );
        reqEntity.UUID = entityId;
        return _repository.DeleteFromStorage( reqEntity ).Result;
    }

    /**
     * Updates entity in table
     */
    public int UpdateInStorage( string entityName, object dtoBody )
    {
        AbstractEntity entity = entityName switch
        {
            "city" => ((CityDto)dtoBody).ConvertToDomainObject(),
            "house" =>((HouseDto)dtoBody).ConvertToDomainObject(),
            "flat" => ((FlatDto)dtoBody).ConvertToDomainObject(),
            "citizen" => ((CitizenDto)dtoBody).ConvertToDomainObject(),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
        var objFromRep = _repository.LoadFromStorage( entity ).Result;
        return objFromRep == null ? _repository.CreateInStorage(entity).Result : _repository.UpdateInStorage( entity ).Result;
    }

    /**
     * Gets citizens in skyscrapers. FloorsNumber >= 10
     */
    public List<CitizenDto> GetCitizensInSkyscrapers()
    {
        return _repository.GetCitizensInSkyscrapers().Result.ConvertAll( item => item.ConvertToDto( GetFlatDto( item ) ) );
    }


    /**
     * Gets CityDto with foreign field House
     */
    private CityDto ? GetCityDto( House entity )
    {
        var cityEntity = _repository.LoadFromStorage( new City()
        {
            UUID = entity.CityId
        } ).Result;
        return cityEntity?.ConvertToDto();
    }  
    
    /**
     * Gets HouseDto with foreign field Flat
     */
    private HouseDto ? GetHouseDto( Flat entity )
    {
        var houseEntity = _repository.LoadFromStorage( new House()
        {
            UUID = entity.HouseId
        } ).Result;
        return houseEntity?.ConvertToDto( GetCityDto( (House)houseEntity.Clone() ) );
    }   
    
    /**
     * Gets FlatDto with foreign field Citizen
     */
    private FlatDto ? GetFlatDto( Citizen entity )
    {
        var flatEntity = _repository.LoadFromStorage( new Flat
        {
            UUID = entity.FlatId
        } ).Result;
        return flatEntity?.ConvertToDto( GetHouseDto( (Flat)flatEntity.Clone() ) );
    }  
    
    
    /**
     * Gets entity by name
     * <exception cref="ArgumentException">If no such name</exception>
     */
    private AbstractEntity GetEntityByName( string entityName )
    {
        if ( !AbstractRepository.GetAvailableEntities().TryGetValue( entityName, out var entity ) )
            throw new ArgumentException( "No such entity" );
        if ( entity == null ) throw new ApplicationException( "Invalid entity in dictionary" );
        return (AbstractEntity)entity.Clone();
    }
}