namespace SQL_Task_2.commands.implementation;

public class FillDataCommand : AbstractCommand
{
    public override void Run( string[] args )
    {
        WriteColorLine( "Start data filling...", ConsoleColor.Green );
        SimpleSQLProgram.GetStorageRepository().FillWithSomeData();
        WriteColorLine( "Successfully filled. Check this by get-all command", ConsoleColor.Yellow );
    }

    public override string GetLabel()
    {
        return "fill-data"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Fills repository with some data from SQL script"; //Command info
    } 
    
    public override string GetUsage()
    {
        return "fill-data"; //Command usage
    }
}