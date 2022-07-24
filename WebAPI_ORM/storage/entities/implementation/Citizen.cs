using System.ComponentModel.DataAnnotations;

namespace WebAPI_ORM.storage.entities.implementation;

public class Citizen : AbstractEntity
{
    [Required] 
    [MaxLength(250)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }
    
    public int FlatUuid { get; set; } //foreign field ref
    public Flat Flat { get; set; }  
    public string ? CardUID { get; set; }
}