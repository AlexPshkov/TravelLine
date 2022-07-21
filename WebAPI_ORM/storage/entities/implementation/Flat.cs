using System.ComponentModel.DataAnnotations;

namespace WebAPI_ORM.storage.entities.implementation
{
    public class Flat : AbstractEntity
    {
        [Required]
        public int FlatNumber { get; set; } 
        
        public int HouseUuid { get; set; } //foreign field ref
        public House House { get; set; } 
        
        public List<Citizen> Citizens { get; set; }
    }
}