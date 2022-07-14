namespace SQL_Task_2.sys.commands;

public abstract class AbstractCommand
{
    public readonly string CommandLabel;

    protected AbstractCommand( string commandLabel )
    {
        this.CommandLabel = commandLabel;
    }

    
    /**
     * Write color line
     */
    public void WriteColorLine( string message, ConsoleColor color = ConsoleColor.White)
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = prevColor;
    }
    
    /**
     * Run command
     */
    public abstract void Run( string[] args ); 
    
    /**
     * Get help for command
     */
    public abstract string GetHelp(); 
    
    /**
     * Get usage for command
     */
    public abstract string GetUsage();
}