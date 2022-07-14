using SQL_Task_2.sys.storage.entities;
using SQL_Task_2.sys.storage.entities.implementation;

namespace SQL_Task_2.sys.commands.implementation;

public class RemoveCommand : AbstractCommand
{
    private const string Label = "remove"; //Command name

    public override void Run( string[] args )
    {
        if ( args.Length < 3 )
        {
            WriteColorLine( $"Use {GetUsage()}", ConsoleColor.Red );
            return;
        }

        int entityId;
        try
        {
            entityId = Convert.ToInt32( args[2] ); //Check if ID is invalid
        }
        catch ( Exception )
        {
            WriteColorLine( "Bad ID type. It must be Int32", ConsoleColor.Red );
            return;
        }

        switch ( args[1].ToLower() )
        {
            case "citizen":
                RemoveObject( new Citizen( entityId ), args[1] );
                break;
            case "city":
                RemoveObject( new City( entityId ), args[1] );
                break;
            case "flat":
                RemoveObject( new Flat( entityId ), args[1] );
                break;
            case "house":
                RemoveObject( new House( entityId ), args[1] );
                break;
            default:
            {
                WriteColorLine( $"Type {args[1]} doesn't exists", ConsoleColor.Red );
                return;
            }
        }
    }

    /**
     * Remove object from db
     */
    private void RemoveObject( AbstractEntity abstractEntity, string tableName )
    {
        var result = SimpleSQLProgram.GetStorageRepository().DeleteFromStorage( abstractEntity ).Result;
        if ( result == 0 )
        {
            WriteColorLine( $"No such object in table {tableName} with ID {abstractEntity.UUID}", ConsoleColor.Red );
            return;
        }

        WriteColorLine( $"Object with ID {abstractEntity.UUID} successfully deleted from {tableName}",
            ConsoleColor.Green );
    }

    public override string GetHelp()
    {
        return "Remove object from table by ID"; //Command info
    }

    public override string GetUsage()
    {
        return "remove <city | flat | citizen | house> <ID>"; //Command usage
    }

    public RemoveCommand() : base( Label )
    {
    }
}