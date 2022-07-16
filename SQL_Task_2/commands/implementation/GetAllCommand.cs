using SQL_Task_2.storage.entities;

namespace SQL_Task_2.commands.implementation;

public class GetAllCommand : AbstractCommand
{
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

        try
        {
            var entity = GetEntityByName( args[1].ToLower() );
            WriteListFor( entity, condition );
        }
        catch ( ArgumentException )
        {
            WriteColorLine( $"Type {args[1]} doesn't exists", ConsoleColor.Red );
        }
    }

    /**
     * Gets list for some entity
     */
    private void WriteListFor( AbstractEntity reqEntity, string condition )
    {
        var result = SimpleSQLProgram.GetStorageRepository().LoadAllFromStorage( reqEntity, condition ).Result;
        WriteColorLine(
            $"============ [List of {reqEntity.GetType().Name} objects. Amount is {result.Count}] ============" ); //Visualize objects list
        result.ForEach( entity => WriteColorLine( $" - {entity}" ) );
        if ( condition.Length > 0 ) WriteColorLine( " > Current condition: " + condition, ConsoleColor.Green );
        WriteColorLine( $"===============================================================" );
    }

    public override string GetLabel()
    {
        return "get-all"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Gets list of all objects in storage"; //Command info
    }

    public override string GetUsage()
    {
        return $"get-all <{GetStringWithAvailableEntities()}> [condition]"; //Command usage
    }
}