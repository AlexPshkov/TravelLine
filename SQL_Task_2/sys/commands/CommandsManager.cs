using System.Diagnostics;
using ThreadState = System.Threading.ThreadState;

namespace SQL_Task_2.sys.commands;

public class CommandsManager
{
    private readonly Dictionary<string, AbstractCommand> _availableCommands = new();
    private Thread ? _commandsListeningThread;
    private bool working = false;
    
    public CommandsManager()
    {
        LoadCommands();
    }

    /**
     * Gets list of all available commands
     */
    public List<AbstractCommand> GetAllCommands()
    {
        return _availableCommands.Values.ToList();
    }

    /**
     * Stops thread for listening commands
     */
    public void StopListeningCommands()
    {
        working = false;
    }

    /**
     * Starts thread for listening console commands
     */
    public void StartListeningCommands()
    {
        if ( _commandsListeningThread is { IsAlive: true } )
            throw new InvalidOperationException( "Thread for listening commands is already running" );
        working = true;
        _commandsListeningThread = new Thread( () =>
        {
            if (( _commandsListeningThread?.ThreadState & ThreadState.Aborted ) != 0) return;
            
            while ( working )
            {
                var stringCommand = Console.ReadLine(); //Read new line from console
                if ( stringCommand == null ) continue;
                stringCommand = stringCommand.Trim();
                var commandArgs = stringCommand.Split( " " );

                if ( !_availableCommands.ContainsKey( commandArgs[0].ToLower() ) ) // If no such command
                {
                    Console.WriteLine( $"Command {commandArgs[0]} doesn't exists. Write \"help\" for commands list" );
                    continue;
                }

                var abstractCommand = _availableCommands[commandArgs[0].ToLower()];

                try
                {
                    abstractCommand.Run( commandArgs ); //Run command in try-catch
                }
                catch ( Exception exception )
                {
                    Console.WriteLine( $"Error while executing command {commandArgs[0]}. Please contact developer" );
                    Console.WriteLine( exception.Message );
                }
            }
        } );

        _commandsListeningThread.Start(); //Run thread
    }

    /**
     * Loads all available commands
     */
    private void LoadCommands()
    {
        foreach ( var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes() ) //For every type
        {
            if ( !type.IsSubclassOf( typeof( AbstractCommand ) ) ) continue; // If not abstract class
            var nullableCommandInstance = Activator.CreateInstance( type ); //Make new instance for this class
            if ( nullableCommandInstance == null ) continue;
            var command = (AbstractCommand)nullableCommandInstance;
            _availableCommands.Add( command.CommandLabel.ToLower(), command ); //Add this command in hash map
        }
    }
}