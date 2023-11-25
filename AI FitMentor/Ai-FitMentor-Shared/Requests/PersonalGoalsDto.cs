using System.ComponentModel.DataAnnotations;

namespace Ai_FitMentor_Shared.Requests;

public class PersonalGoalsDto
{
    [Required(ErrorMessage = "Please fill your personal goals")]
    [MinLength(3,ErrorMessage = "Please fill your personal goals")]
    public string MyGoals { get; set; }
    
    public List<MusclesDataModel> TargetedMuscles { get; set; }
    
    public WorkoutTypeDataModel WorkoutType { get; set; }

    public string Gender { get; set; }
    
    [Required(ErrorMessage = "Please enter your weight")]
    [MinLength(1,ErrorMessage = "Please enter your weight")]
    public string Weight { get; set; }
    
    [Required(ErrorMessage = "Please enter your Height")]
    [MinLength(1,ErrorMessage = "Please enter your Height")]
    public string Height { get; set; }
    
}