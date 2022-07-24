using WebAPI_Task_1.storage.entities;

namespace WebAPI_Task_1.storage.sql;

public abstract class AbstractRepository
{
    private static readonly Dictionary<string, AbstractEntity ?> AvailableEntities = new();
    protected readonly string DbName;
    
    protected AbstractRepository( string dataBaseName ) 
    {
        DbName = dataBaseName;
        LoadAllEntities(); 
    }

    /**
     * Gets available entities
     */
    public static Dictionary<string, AbstractEntity ?> GetAvailableEntities()
    {
        return AvailableEntities;
    }
    
    /**
     * Init. Load all entities
     */
    private void LoadAllEntities()
    {
        foreach ( var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes() ) //For every type
        {
            if ( !type.IsSubclassOf( typeof( AbstractEntity ) ) ) continue; // If not abstract class
            var nullableEntityInstance = Activator.CreateInstance( type ); //Make new instance for this class
            if ( nullableEntityInstance == null ) continue;
            var entity = (AbstractEntity)nullableEntityInstance;
            AvailableEntities.Add( entity.GetType().Name.ToLower(), entity );
        }
    }
}