namespace SQL_Task_2.sys.storage.entities.implementation
{
    public class Flat : AbstractEntity
    {
        public int HouseId; //foreign field ref
    
        public int FlatNumber;

        public Flat( int uuid ) : base( uuid )
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