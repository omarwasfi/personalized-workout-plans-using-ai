using Ai_FitMentor_Shared;

namespace AI.FitMentor.BlazorApp.Services.Interfaces;

public interface IAIFitMentorService
{
    public Task<ResultStrDto> GeneratePlan(PersonDataModel personDataModel);
    public Task<List<EquipmentDataModel>>GetEquipments();
    
    public Task<List<MusclesDataModel>>GetMuscles();
    
    public Task<List<PlaceDataModel>>GetPlaces();

    public Task<List<PlanDataModel>>GetPlans();

    public Task<List<WorkoutTypeDataModel>>GetTypes();

    
}