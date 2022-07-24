using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_ORM.Services;
using WebAPI_ORM.Services.implementation;
using WebAPI_ORM.storage;
using WebAPI_ORM.storage.sql.implementation;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CityMapContext>( c =>
{
    c.UseSqlite( builder.Configuration.GetValue<string>( "SQLiteConnection" ) );
} );

builder.Services.AddScoped<IRepository, SqliteRepository>(); 
builder.Services.AddScoped<IRestService, RestService>();
builder.Services.AddSingleton<UserService>();


builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(context.ModelState)
            {
                ContentTypes =
                {
                    MediaTypeNames.Application.Json,
                    MediaTypeNames.Application.Xml
                }
            };
    }).AddXmlSerializerFormatters();

var app = builder.Build();

app.UseExceptionHandler( "/api/error" );
app.MapControllers();
app.Run(); 
app.UseCors( x => x
    .WithOrigins( "http://localhost:4200" )
    .AllowCredentials()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader() ); 
    