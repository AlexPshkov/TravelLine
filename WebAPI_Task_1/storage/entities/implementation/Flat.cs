namespace WebAPI_Task_1.storage.entities.implementation
{
    public class Flat : AbstractEntity
    {
        public int HouseId; //foreign field ref
    
        public int FlatNumber;

        public Flat() : base( 0 )
        {
            HouseId = 0;
            FlatNumber = 0;
        }
        
        public Flat( int uuid, int houseId, int flatNumber ) : base( uuid )
        {
            HouseId = houseId;
            FlatNumber = flatNumber;
        }
    }
}