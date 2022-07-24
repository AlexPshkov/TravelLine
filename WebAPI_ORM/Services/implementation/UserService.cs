using System.IO.Ports;
using WebAPI_ORM.Dto.implementation;

namespace WebAPI_ORM.Services.implementation;

public class UserService
{
    private string _lastCard = "";
    private readonly SerialPort _port = new("COM4", 9600, Parity.None, 8, StopBits.One );
    
    public UserService()
    {
        Task.Run( () =>
        {
            Console.WriteLine("Serial read init");
            _port.DataReceived += DataReceived;
            _port.Open();
        } );

    } 
    
    private void DataReceived( object sender, SerialDataReceivedEventArgs e )
    {
        var stringLine = _port.ReadLine();
        if ( !stringLine.StartsWith( "Card UID" ) ) return;
        var cardUid = GetCardUUID( stringLine );
        SetLastUID( cardUid );
        Console.WriteLine("Check card => " + cardUid);
    }

    private string GetCardUUID( string stringLine )
    {
        return stringLine.Split( "Card UID: " )[1].Replace( "\r", "" );
    }
    
    public CardDto GetLastCardDto()
    {
        return new CardDto()
        {
            CardUID = _lastCard
        };
    }

    public string SetLastUID( string cardUid )
    {
        _lastCard = cardUid;
        return _lastCard;
    }
}