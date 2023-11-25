using Ai_FitMentor_Shared;
namespace AI_FitMentor_Lib.Services.Interfaces;

public interface IWorkoutPlanner
{
    public Task<string> Generate(PersonDataModel person);
    
}