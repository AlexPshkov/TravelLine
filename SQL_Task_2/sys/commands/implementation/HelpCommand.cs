namespace SQL_Task_2.sys.commands.implementation;

public class HelpCommand : AbstractCommand
{
    private const string Label = "help"; //Command name

    public override void Run( string[] args )
    {
        var commandsList = SimpleSQLProgram.GetCommandsManager().GetAllCommands(); //Get all commands from CommandsManager

        WriteColorLine($"============ [Help for {commandsList.Count} commands] ============", ConsoleColor.Green); //Visualize commands list
        commandsList.ForEach( abstractCommand => WriteColorLine(
            $" > { abstractCommand.CommandLabel }" +
            $" - { abstractCommand.GetHelp() } " +
            $"\n    Usage: { abstractCommand.GetUsage() }", ConsoleColor.Yellow));
        WriteColorLine($"===============================================", ConsoleColor.Green);
    }

    public override string GetHelp()
    {
        return "Gets list of all available commands"; //Command info
    } 
    
    public override string GetUsage()
    {
        return "help"; //Command usage
    }

    public HelpCommand() : base( Label )
    {
    }
}