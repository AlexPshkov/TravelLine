using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySqlConnector;
using SQL_Task_2.commands;
using SQL_Task_2.storage;
using SQL_Task_2.storage.sql.implementation;

namespace SQL_Task_2;

/**
 * Author AlexPshkov
 */
public class SimpleSQLProgram
{
    private static readonly CommandsManager CommandsManager = new CommandsManager();
    private static readonly IRepository StorageRepository = new SqlRepository<SqliteConnection>("TravelLine"); //Доступны: MySqlConnection, SqliteConnection, SqlConnection
    
    
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