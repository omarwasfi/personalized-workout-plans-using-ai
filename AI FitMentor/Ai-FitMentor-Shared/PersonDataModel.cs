namespace Ai_FitMentor_Shared;

public class PersonDataModel
{
    public string Gender { get; set; }
    public string Weight { get; set; }
    public string Height { get; set; }
    
    public List<EquipmentDataModel> Equipments { get; set; }
    public List<MusclesDataModel> Muscles { get; set; }
    public PlaceDataModel Place { get; set; }
    public PlanDataModel Plan { get; set; }
    public WorkoutTypeDataModel WorkoutType { get; set; }

    public string  MyGoals { get; set; }
    
    public string GetEquipments()
    {
        string result = "";
        foreach (EquipmentDataModel equipment in Equipments)
        {
            result += ", " + equipment.Name + " ";
        }

        return result;
    }
    
    public string GetMuscles()
    {
        string result = "";
        foreach (MusclesDataModel musclesDataModel in Muscles)
        {
            result += ", " + musclesDataModel.Name + " ";
        }

        return result;
    }
    
    
}