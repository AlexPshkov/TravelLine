namespace WebAPI_ORM.Dto.implementation;

public class CitizenDto : AbstractDto
{
    public FlatDto ? Flat { get; set; } //foreign field ref

    public string ? FirstName { get; set; }
    public string ? LastName { get; set; }
    public string ? CardUID { get; set; }
}