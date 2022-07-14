using SQL_Task_2.sys.storage;
using SQL_Task_2.sys.storage.entities;
using SQL_Task_2.sys.storage.entities.implementation;

namespace SQL_Task_2.sys.commands.implementation;

public class UpdateCommand : AbstractCommand
{
    private const string Label = "update"; //Command name

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
                CheckAndUpdate( new Citizen( entityId ) );
                break;
            case "city":
                CheckAndUpdate( new City( entityId ) );
                break;
            case "flat":
                CheckAndUpdate( new Flat( entityId ) );
                break;
            case "house":
                CheckAndUpdate( new House( entityId ) );
                break;
            default:
            {
                WriteColorLine( $"Type { args[1] } doesn't exists", ConsoleColor.Red );
                return;
            }
        }
    }

    /**
     * Make check and update if OK
     */
    private void CheckAndUpdate( AbstractEntity abstractEntity )
    {
        IRepository repository = SimpleSQLProgram.GetStorageRepository();
        var result = repository.LoadFromStorage( abstractEntity ).Result;

        if ( result == null )
        {
            WriteColorLine( $"There is no such field with ID {abstractEntity.UUID}", ConsoleColor.Red );
            return;
        }

        UpdateObject( result ); //Update
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

    public override string GetHelp()
    {
        return "Updates all fields by ID"; //Command info
    }

    public override string GetUsage()
    {
        return "update <city | flat | citizen | house> <ID>"; //Command usage
    }

    public UpdateCommand() : base( Label )
    {
    }
}