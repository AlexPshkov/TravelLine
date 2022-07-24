using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using WebAPI_Task_1.Services;
using WebAPI_Task_1.Services.implementation;
using WebAPI_Task_1.storage;
using WebAPI_Task_1.storage.sql.implementation;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IRepository>( s =>
    new SqlRepository<MySqlConnection>( builder.Configuration.GetValue<string>( "DataBaseName" ) ) );
builder.Services.AddScoped<IRestService, RestService>();


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
// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler( "/api/error" );
app.MapControllers();
app.Run(); 
