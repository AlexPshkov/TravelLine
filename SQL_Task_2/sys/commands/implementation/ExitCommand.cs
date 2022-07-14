namespace SQL_Task_2.sys.commands.implementation;

public class ExitCommand : AbstractCommand
{
    private const string Label = "exit"; //Command name

    public override void Run( string[] args )
    {
        WriteColorLine( "Bye Bye :)", ConsoleColor.Green );
        SimpleSQLProgram.GetCommandsManager().StopListeningCommands(); //Stop
    }

    public override string GetHelp()
    {
        return "Exit from program"; //Command info
    } 
    
    public override string GetUsage()
    {
        return "exit"; //Command usage
    }

    public ExitCommand() : base( Label )
    {
    }
}