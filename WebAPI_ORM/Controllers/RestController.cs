using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ORM.Services;

namespace WebAPI_ORM.Controllers;

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
    public IActionResult Create( string entityName, [FromBody] JsonElement dtoBody )
    {
        var elem = dtoBody.GetProperty( nameof(dtoBody) );
        var result = _restService.CreateInStorage( entityName.ToLower(), elem );
        return result > 0 ? Ok() : NoContent();
    } 
    
    [HttpPut]
    [Route("{entityName}")]
    public IActionResult Update( string entityName, [FromBody] JsonElement dtoBody )
    {
        var elem = dtoBody.GetProperty( nameof(dtoBody) );
        var result = _restService.UpdateInStorage( entityName.ToLower(), elem );
        return result > 0 ? Ok() : NoContent();
    }
    
    
    [HttpDelete]
    [Route( "{entityName}/{entityId:int}" )]
    public IActionResult Delete( string entityName, int entityId )
    {
        var result = _restService.DeleteFromStorage( entityName.ToLower(), entityId );
        return result > 0 ? Ok() : NoContent();
    } 
    
}