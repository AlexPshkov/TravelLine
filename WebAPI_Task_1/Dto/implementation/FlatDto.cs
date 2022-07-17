namespace WebAPI_Task_1.Dto.implementation
{
    public class FlatDto : AbstractDto
    {
        public HouseDto ? House { get; set; } //foreign field ref
    
        public int FlatNumber { get; set; }
        
    }
}