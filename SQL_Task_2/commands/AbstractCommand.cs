using System.Text;
using SQL_Task_2.storage.entities;
using SQL_Task_2.storage.sql;

namespace SQL_Task_2.commands;

public abstract class AbstractCommand
{
    /**
     * Write color line
     */
    public void WriteColorLine( string message, ConsoleColor color = ConsoleColor.White )
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine( message );
        Console.ForegroundColor = prevColor;
    }

    /**
     * Gets string with available entities
     * <returns>First | Second | Third | etc.</returns> 
     */
    protected string GetStringWithAvailableEntities()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach ( var keyValuePair in AbstractRepository.GetAvailableEntities() )
            stringBuilder.Append( keyValuePair.Key ).Append( " | " );
        return stringBuilder.ToString()[..( stringBuilder.Length - 3 )];
    }

    /**
     * Gets entity by name
     * <exception cref="ArgumentException">If no such name</exception>>
     */
    protected AbstractEntity GetEntityByName( string entityName )
    {
        if ( !AbstractRepository.GetAvailableEntities().TryGetValue( entityName, out var entity ) )
            throw new ArgumentException( "No such entity" );
        if (entity == null) throw new ApplicationException("Invalid entity in dictionary");
        return (AbstractEntity)entity.Clone();
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

    /**
     * Get command label.
     */
    public abstract string GetLabel();
}