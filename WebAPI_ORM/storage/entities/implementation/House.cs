using System.ComponentModel.DataAnnotations;

namespace WebAPI_ORM.storage.entities.implementation;

public class House : AbstractEntity
{
    [Required]
    [MaxLength(250)]
    public string StreetName  { get; set; }
    
    [Required]
    public int FloorsNumber { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string HouseNumber { get; set; } 
    
    public int CityUuid { get; set; } //foreign field ref
    public City City { get; set; } 
    
    public List<Flat> Flats { get; set; }
    
}