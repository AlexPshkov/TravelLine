namespace WebAPI_ORM.Dto.implementation;

public partial class HouseDto : AbstractDto
{
    public CityDto ? City { get; set; } //foreign field ref

    public string ? StreetName { get; set; }
    public int FloorsNumber { get; set; }
    public string ? HouseNumber { get; set; }
}