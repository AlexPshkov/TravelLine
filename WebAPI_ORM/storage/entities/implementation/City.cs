using System.ComponentModel.DataAnnotations;

namespace WebAPI_ORM.storage.entities.implementation;

public class City : AbstractEntity
{
    [Required]
    [MaxLength(250)]
    public string Country { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Region { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string CityName { get; set; } 
    
    public List<House> Houses { get; set; }
}