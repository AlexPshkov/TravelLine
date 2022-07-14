using SQL_Task_2.sys.storage.entities;
using SQL_Task_2.sys.storage.entities.implementation;

namespace SQL_Task_2.sys.commands.implementation;

public class GetAllCommand : AbstractCommand
{
    private const string Label = "get-all"; //Command name

    public override void Run( string[] args )
    {
        if ( args.Length < 2 )
        {
            WriteColorLine( $"Use {GetUsage()}", ConsoleColor.Red );
            return;
        }

        var condition = "";
        if ( args.Length >= 3 )
        {
            if ( !args[2].ToLower().StartsWith( "where" ) )
            {
                WriteColorLine( $"For condition use \"WHERE <condition>\" ", ConsoleColor.Red );
                return;
            }

            for ( var i = 2; i < args.Length; i++ ) condition += args[i] + " ";
        }

        switch ( args[1].ToLower() ) //Available tables
        {
            case "citizen":
                GetFor( new Citizen( 0 ), condition );
                break;
            case "city":
                GetFor( new City( 0 ), condition );
                break;
            case "flat":
                GetFor( new Flat( 0 ), condition );
                break;
            case "house":
                GetFor( new House( 0 ), condition );
                break;
            default:
            {
                WriteColorLine( $"Type {args[1]} doesn't exists", ConsoleColor.Red );
                return;
            }
        }
    }

    /**
     * Gets list for some entity
     */
    private void GetFor<T>( T reqEntity, string condition ) where T : AbstractEntity
    {
        var result = SimpleSQLProgram.GetStorageRepository().LoadAllFromStorage( reqEntity, condition ).Result;
        WriteColorLine(
            $"============ [List of {reqEntity.GetType().Name} objects. Amount is {result.Count}] ============" ); //Visualize objects list
        result.ForEach( entity => WriteColorLine( $" - {entity}" ) );
        if ( condition.Length > 0 ) WriteColorLine( " Current condition: " + condition, ConsoleColor.Green );
        WriteColorLine( $"===============================================================" );
    }

    public override string GetHelp()
    {
        return "Gets list of all objects in storage"; //Command info
    }

    public override string GetUsage()
    {
        return "get-all <city | flat | citizen | house> [condition]"; //Command usage
    }

    public GetAllCommand() : base( Label )
    {
    }
}