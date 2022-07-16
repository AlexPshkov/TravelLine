using System.Text;

namespace SQL_Task_2.storage.entities;

public abstract class AbstractEntity: ICloneable
{
    /**
     * Identifier for entity
     */
    public int UUID;
    
    protected AbstractEntity( int uuid )
    {
        UUID = uuid;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach ( var fieldInfo in GetType().GetFields() ) 
            stringBuilder.Append( fieldInfo.Name ).Append( ": " ).Append( fieldInfo.GetValue( this ) ).Append( "   " );
        return stringBuilder.ToString();
    }
}