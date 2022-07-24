using SQL_Task_2.storage.entities.implementation;

namespace SQL_Task_2.commands.implementation;

public class GetCitizenCommand : AbstractCommand
{
    public override void Run( string[] args )
    {
        List<Citizen> citizens = SimpleSQLProgram.GetStorageRepository().GetCitizensInSkyscrapers().Result;
        
        WriteColorLine($"============ [List of Citizens in houses with floorsNumber >= 10] ============");
        citizens.ForEach( citizen => WriteColorLine(citizen.ToString()));
        WriteColorLine($"==============================================================="); 
    }

    public override string GetLabel()
    {
        return "get-citizen-skyscrapers"; //Command name
    } 
    
    public override string GetHelp()
    {
        return "Gets list of citizens in houses with floorsNumber >= 10"; //Command info
    } 
    
    public override string GetUsage()
    {
        return "get-citizen-skyscrapers"; //Command usage
    }
}