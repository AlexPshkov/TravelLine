using SQL_Task_2.sys.commands;
using SQL_Task_2.sys.storage;
using SQL_Task_2.sys.storage.implementation.sql;

namespace SQL_Task_2;

/**
 * Author AlexPshkov
 */
public class SimpleSQLProgram
{
    private static readonly CommandsManager CommandsManager = new CommandsManager();
    private static readonly IRepository StorageRepository = new SqlRepository();
    
    
    /**
     * Program entry point
     */
    public static void Main( string[] args )
    {
        CommandsManager.StartListeningCommands();
        Console.WriteLine(" > Use \"help\" for commands list"); //Help message
    }

    
    /**
     * Gets storage repository
     */
    public static IRepository GetStorageRepository()
    {
        return StorageRepository;
    }
    
    /**
     * Gets command manager
     */
    public static CommandsManager GetCommandsManager()
    {
        return CommandsManager;
    }
    
    
}