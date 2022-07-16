using SQL_Task_2.storage.entities;

namespace SQL_Task_2.commands.implementation;

public class UpdateCommand : AbstractCommand
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
            var repository = SimpleSQLProgram.GetStorageRepository();
            var result = repository.LoadFromStorage( entity ).Result;

            if ( result == null )
            {
                WriteColorLine( $"There is no such field with ID {entityId}", ConsoleColor.Red );
                return;
            }
        
            UpdateObject( result ); //Update
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
    
    /**
     * Update object in db
     */
    private void UpdateObject( AbstractEntity abstractEntity )
    {
        WriteColorLine( $"Now u must to type new values for object with ID {abstractEntity.UUID}",
            ConsoleColor.Yellow );
        foreach ( var fieldInfo in abstractEntity.GetType().GetFields() )
        {
            if ( fieldInfo.Name.Equals( "UUID" ) ) continue; //Skip uuid field
            var fieldValue = fieldInfo.GetValue( abstractEntity );
            while ( true )
            {
                WriteColorLine(
                    $" > Type new {fieldValue?.GetType().Name} value for field {fieldInfo.Name}. Old value is {fieldValue}",
                    ConsoleColor.Green );

                var inputValue = Console.ReadLine();
                try
                {
                    fieldInfo.SetValue( abstractEntity,
                        fieldValue is string ? inputValue : Convert.ToInt32( inputValue ) );
                    break;
                }
                catch ( Exception )
                {
                    WriteColorLine( $"Bad type for {fieldInfo.Name}", ConsoleColor.Red );
                }
            }
        }

        var result = SimpleSQLProgram.GetStorageRepository().UpdateInStorage( abstractEntity ).Result;
        if ( result != 0 )
            WriteColorLine( $"Successful! All fields in object with ID {abstractEntity.UUID} are updated ",
                ConsoleColor.Yellow );
        else WriteColorLine( $"Some error while updating field with ID {abstractEntity.UUID}", ConsoleColor.Red );
    }

    public override string GetLabel()
    {
        return "update"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Updates all fields by ID"; //Command info
    }

    public override string GetUsage()
    {
        return $"update <{GetStringWithAvailableEntities()}> <ID>"; //Command usage
    }
}