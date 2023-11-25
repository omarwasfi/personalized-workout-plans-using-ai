using Ai_FitMentor_Shared;
using AI.FitMentor.BlazorApp.Services.Interfaces;

namespace AI.FitMentor.BlazorApp.Services.Classes;

public class AIFitMentorService : IAIFitMentorService
{
    private IHttpService _httpService;

    public AIFitMentorService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<ResultStrDto> GeneratePlan(PersonDataModel personDataModel)
    {
        return await _httpService.Post<ResultStrDto>("AIFitMentor/GeneratePlan",personDataModel);
    }

    public async Task<List<EquipmentDataModel>> GetEquipments()
    {
        return await _httpService.Get<List<EquipmentDataModel>>("AIFitMentor/GetEquipments");
    }

    public async Task<List<MusclesDataModel>> GetMuscles()
    {
        return await _httpService.Get<List<MusclesDataModel>>("AIFitMentor/GetMuscles");
    }

    public async Task<List<PlaceDataModel>> GetPlaces()
    {
        return await _httpService.Get<List<PlaceDataModel>>("AIFitMentor/GetPlaces");
    }

    public async Task<List<PlanDataModel>> GetPlans()
    {
        return await _httpService.Get<List<PlanDataModel>>("AIFitMentor/GetPlans");
    }

    public async Task<List<WorkoutTypeDataModel>> GetTypes()
    {
        return await _httpService.Get<List<WorkoutTypeDataModel>>("AIFitMentor/GetTypes");
    }
}