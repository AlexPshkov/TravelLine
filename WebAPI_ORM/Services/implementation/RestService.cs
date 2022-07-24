using System.Text.Json;
using WebAPI_ORM.Dto;
using WebAPI_ORM.Dto.implementation;
using WebAPI_ORM.Extensions;
using WebAPI_ORM.storage;
using WebAPI_ORM.storage.entities;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.Services.implementation;

public class RestService : IRestService
{
    private readonly IRepository _repository;

    public RestService( IRepository repository )
    {
        _repository = repository;
    }
    
    public List<object> GetAllFromStorage( string entityName )
    {
        var resultList = new List<object>();
        switch ( entityName )
        {
            case "city":
            {
                var list = _repository.LoadAllFromStorage<City>().ToList();
                list.ForEach( item => resultList.Add( item.ConvertToDto() ));
                return resultList;
            }
            case "house":
            {
                var list = _repository.LoadAllFromStorage<House>().ToList();
                list.ForEach( item => resultList.Add( item.ConvertToDto() ));

                return resultList;
            }
            case "flat":
            {
                var list = _repository.LoadAllFromStorage<Flat>().ToList();
                list.ForEach( item => resultList.Add( item.ConvertToDto() ));
                return resultList;
            }
            case "citizen":
            {
                var list = _repository.LoadAllFromStorage<Citizen>().ToList();
                list.ForEach( item => resultList.Add( item.ConvertToDto() ));
                return resultList;
            }
            default: throw new ApplicationException( "Internal error. No such entity" );
        }
    }

    public object ? GetFromStorage( string entityName, int entityId )
    {
        return entityName switch
        {
            "city" => _repository.LoadFromStorage<City>( entityId )?.ConvertToDto(),
            "house" => _repository.LoadFromStorage<House>( entityId )?.ConvertToDto(),
            "flat" => _repository.LoadFromStorage<Flat>( entityId )?.ConvertToDto(),
            "citizen" => _repository.LoadFromStorage<Citizen>( entityId )?.ConvertToDto(),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
    }

    /**
     * Deletes entity from storage
     */
    public int DeleteFromStorage( string entityName, int entityId )
    {
        AbstractEntity ? receivedEntity = entityName switch
        {
            "city" => _repository.LoadFromStorage<City>( entityId ),
            "house" => _repository.LoadFromStorage<House>( entityId ),
            "flat" => _repository.LoadFromStorage<Flat>( entityId ),
            "citizen" => _repository.LoadFromStorage<Citizen>( entityId ),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
        if ( receivedEntity == null ) throw new ArgumentException( "No such entity" );
        return _repository.DeleteFromStorage( receivedEntity );
    }

    /**
     * Updates entity in table
     */
    public int UpdateInStorage( string entityName, JsonElement dtoBody )
    {
        AbstractEntity ? receivedEntity = entityName switch
        {
            "city" =>  ParseToDto<CityDto>( dtoBody )?.ConvertToDomainObject(),
            "house" => ParseToDto<HouseDto>( dtoBody )?.ConvertToDomainObject(),
            "flat" =>  ParseToDto<FlatDto>( dtoBody )?.ConvertToDomainObject(),
            "citizen" => ParseToDto<CitizenDto>( dtoBody )?.ConvertToDomainObject(),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
        
        if ( receivedEntity == null ) throw new ArgumentException("Invalid entity");
        return  _repository.UpdateInStorage( receivedEntity );
    } 
    
    /**
     * Creates entity in table
     */
    public int CreateInStorage( string entityName, JsonElement dtoBody )
    {
        AbstractEntity ? receivedEntity = entityName switch
        {
            "city" =>  ParseToDto<CityDto>( dtoBody )?.ConvertToDomainObject(),
            "house" => ParseToDto<HouseDto>( dtoBody )?.ConvertToDomainObject(),
            "flat" =>  ParseToDto<FlatDto>( dtoBody )?.ConvertToDomainObject(),
            "citizen" => ParseToDto<CitizenDto>( dtoBody )?.ConvertToDomainObject(),
            _ => throw new ApplicationException( "Internal error. No such entity" )
        };
        
        if ( receivedEntity == null ) throw new ArgumentException("Invalid entity");
        return  _repository.CreateInStorage( receivedEntity );
    }
    
    /**
     * Parse json to DTO
     */
    public T ? ParseToDto<T>( JsonElement body ) where T: AbstractDto
    {
        Console.WriteLine(body);
        AbstractDto abstractDto = Activator.CreateInstance<T>();
        
        foreach ( var fieldInfo in abstractDto.GetType().GetProperties() )
        {
            try
            {
                var fieldType = fieldInfo.GetMethod?.ReturnType;
                var property = body.GetProperty( fieldInfo.Name );
                if ( property.ValueKind == JsonValueKind.Object )
                {
                    switch ( fieldInfo.Name.ToLower() )
                    {
                        case "city":
                        {
                            fieldInfo.SetValue( abstractDto, ParseToDto<CityDto>( property ));
                            break;
                        } 
                        case "house":
                        {
                            fieldInfo.SetValue( abstractDto, ParseToDto<HouseDto>( property ));
                            break;
                        } 
                        case "flat":
                        {
                            fieldInfo.SetValue( abstractDto, ParseToDto<FlatDto>( property ));
                            break;
                        } 
                        case "citizen":
                        {
                            fieldInfo.SetValue( abstractDto, ParseToDto<CitizenDto>( property ));
                            break;
                        }
                    }
                    continue;
                }
                object ? value = fieldType == typeof( string ) ? property.GetString() : ( property.ValueKind == JsonValueKind.Number ? property.GetInt32() : Convert.ToInt32( property.GetString() ));
                fieldInfo.SetValue( abstractDto, value );
            }
            catch ( Exception e)
            {
                Console.WriteLine(e);
            }
        }
        return abstractDto as T;
    } 
    
    public CitizenDto ? GetCitizenWithSuchCard( string cardUID )
    {
        return _repository.LoadCitizenWithSuchCard( cardUID )?.ConvertToDto();
    }
}