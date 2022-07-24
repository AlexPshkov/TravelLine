using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI_ORM.storage.entities;

public abstract class AbstractEntity: ICloneable
{
    /**
     * Identifier for entity
     */
    [Key]
    public int Uuid { get; set; }

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