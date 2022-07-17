using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Task_1.Dto.implementation;
using WebAPI_Task_1.Services;

namespace WebAPI_Task_1.Controllers;

[ApiController]
[Route( "api/")]
public class RestController : ControllerBase
{

    private readonly IRestService _restService;

    public RestController( IRestService restService )
    {
        _restService = restService;
    }

    [Route("error")]
    public IActionResult Error()
    {
        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        return Problem( title: exceptionHandlerFeature.Error.Message );
    }

    [HttpGet]
    [Route("{entityName}")]
    public IActionResult GetAll( string entityName )
    {
        return Ok( _restService.GetAllFromStorage( entityName ) );
    }

    [HttpGet]
    [Route( "{entityName}/{entityId:int}" )]
    public IActionResult Get( string entityName, int entityId )
    {
        return Ok( _restService.GetFromStorage( entityName.ToLower(), entityId ) );
    }  
    
    [HttpPost]
    [Route("{entityName}")]
    public IActionResult Create( string entityName, [FromBody] CityDto dtoBody )
    {
        var name = entityName.ToLower();
        if ( name != "city" ) throw new ArgumentException( "Only city available" );
        return Ok( _restService.UpdateInStorage( name, dtoBody ) > 0 ? "Successfully updated" : "No such field" );
    } 
    
    [HttpDelete]
    [Route( "{entityName}/{entityId:int}" )]
    public IActionResult Delete( string entityName, int entityId )
    { 
        return Ok( _restService.DeleteFromStorage( entityName.ToLower(), entityId ) > 0 ? "Successfully deleted" : "No such field"  );
    } 
    
    [HttpGet]
    [Route( "citizen-skyscrapers" )]
    public IActionResult GetCitizenInSkyScrapers( )
    {
        return Ok( _restService.GetCitizensInSkyscrapers() );
    } 
}