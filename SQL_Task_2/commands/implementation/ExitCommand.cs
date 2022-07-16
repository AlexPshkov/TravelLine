namespace SQL_Task_2.commands.implementation;

public class ExitCommand : AbstractCommand
{
    public override void Run( string[] args )
    {
        WriteColorLine( "Bye Bye :)", ConsoleColor.Green );
        SimpleSQLProgram.GetCommandsManager().StopListeningCommands(); //Stop
    }

    public override string GetLabel()
    {
        return "exit"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Exit from program"; //Command info
    } 
    
    public override string GetUsage()
    {
        return "exit"; //Command usage
    }
}