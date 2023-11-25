using System.ComponentModel.DataAnnotations;

namespace Ai_FitMentor_Shared.Requests;

public class AvailabilityDto
{
    public PlaceDataModel Place { get; set; }
    public PlanDataModel Plan { get; set; }
    
    [Required(ErrorMessage = "Please selected the available equipments")]
    public List<EquipmentDataModel> Equipments { get; set; }

    
}