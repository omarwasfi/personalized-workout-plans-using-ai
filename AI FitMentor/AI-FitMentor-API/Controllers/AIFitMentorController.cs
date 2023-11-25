using AI_FitMentor_Lib.DataModels;
using Microsoft.AspNetCore.Mvc;
using AI_FitMentor_Lib.DbContext;
using AI_FitMentor_Lib.Services.Classes;
using AI_FitMentor_Lib.Services.Interfaces;

namespace AI_FitMentor_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AIFitMentorController : ControllerBase
{
    public AIFitMentorDB _AiFitMentorDb { get; set; }
    public IWorkoutPlanner _WorkoutPlanner { get; set; }

    public AIFitMentorController(AIFitMentorDB aiFitMentor,IWorkoutPlanner workoutPlanner)
    {
        this._AiFitMentorDb = aiFitMentor;
        this._WorkoutPlanner = workoutPlanner;
    }

    [HttpPost]
    [Route("GetPlan")]
    public async Task<ActionResult<string>> GetPlan(PersonDataModel person)
    {
        try
        {
            return await this._WorkoutPlanner.Generate(person);
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }

    
    [HttpGet]
    [Route("GetEquipments")]
    public async Task<ActionResult<List<EquipmentDataModel>>> GetEquipments()
    {
        try
        {
            return this._AiFitMentorDb.Equipments;
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }
    
    [HttpGet]
    [Route("GetMuscles")]
    public async Task<ActionResult<List<MusclesDataModel>>> GetMuscles()
    {
        try
        {
            return this._AiFitMentorDb.Muscles;
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }
    
    
    [HttpGet]
    [Route("GetPlaces")]
    public async Task<ActionResult<List<PlaceDataModel>>> GetPlaces()
    {
        try
        {
            return this._AiFitMentorDb.Places;
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }
    
    [HttpGet]
    [Route("GetPlans")]
    public async Task<ActionResult<List<PlanDataModel>>> GetPlans()
    {
        try
        {
            return this._AiFitMentorDb.Plans;
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }
    
    [HttpGet]
    [Route("GetTypes")]
    public async Task<ActionResult<List<WorkoutTypeDataModel>>> GetTypes()
    {
        try
        {
            return this._AiFitMentorDb.Typse;
        }
        catch
        {
            return BadRequest("Unrecognized error");

        }
    }
    
    
    
    
}