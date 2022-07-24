namespace SQL_Task_2.commands.implementation;

public class RemoveCommand : AbstractCommand
{
    public override void Run( string[] args )
    {
        if ( args.Length < 3 )
        {
            WriteColorLine( $"Use {GetUsage()}", ConsoleColor.Red );
            return;
        }
        
        try
        {
            var entityId = Convert.ToInt32( args[2] ); //Check if ID is invalid
            var entity = GetEntityByName( args[1].ToLower() );
            entity.UUID = entityId;
            var result = SimpleSQLProgram.GetStorageRepository().DeleteFromStorage( entity ).Result;
            if ( result != 0 ) WriteColorLine( $"Object with ID {entityId} successfully deleted from {args[1]}", ConsoleColor.Green );
            else WriteColorLine( $"No such object in table {args[1]} with ID {entityId}", ConsoleColor.Red );
        }
        catch ( FormatException )
        {
            WriteColorLine( "Bad ID type. It must be Int32", ConsoleColor.Red );
        }
        catch ( ArgumentException )
        {
            WriteColorLine( $"Table {args[1]} doesn't exists", ConsoleColor.Red );
        }
    }
    
    public override string GetLabel()
    {
        return "remove"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Remove object from table by ID"; //Command info
    }

    public override string GetUsage()
    {
        return $"remove <{GetStringWithAvailableEntities()}> <ID>"; //Command usage
    }
}