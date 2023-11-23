using System.Text.Json;
using AI_FitMentor_Lib.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AI_FitMentor_Lib.DbContext;

public class AIFitMentorDB
{
    private IConfiguration _configuration;
    private readonly IHostingEnvironment _hostingEnvironment;

    public AIFitMentorDB(IConfiguration configuration,IHostingEnvironment hostingEnvironment)
    {
        this._configuration = configuration;
        this._hostingEnvironment = hostingEnvironment;

        LoadDefaults();
    }

    public async Task LoadDefaults()
    {
        await loadEquipments();
        await loadMuscles();
        await loadPlaces();
        await loadPlans();
        await loadTypse();
    }
    public List<EquipmentDataModel> Equipments { get; set; }
    public List<MusclesDataModel> Muscles { get; set; }
    public List<PlaceDataModel> Places { get; set; }
    public List<PlanDataModel> Plans { get; set; }
    public List<TypeDataModel> Typse { get; set; }


    private async Task loadEquipments()
    {
        Equipments = new List<EquipmentDataModel>();
        using FileStream stream = File.OpenRead(_hostingEnvironment.WebRootPath + _configuration.GetValue<string>("EquipmentsPath"));
        
        List<string> EquipmentsJSON = await JsonSerializer.DeserializeAsync<List<string>>(stream);

        foreach (string equipment in EquipmentsJSON)
        {
            this.Equipments.Add(new EquipmentDataModel(){Name = equipment});
        }
    }
    
    private async Task loadMuscles()
    {
        Muscles = new List<MusclesDataModel>();
        using FileStream stream = File.OpenRead(_hostingEnvironment.WebRootPath + _configuration.GetValue<string>("MusclesPath"));
        
        List<string> MusclesJSON = await JsonSerializer.DeserializeAsync<List<string>>(stream);

        foreach (string muscle in MusclesJSON)
        {
            this.Muscles.Add(new MusclesDataModel(){Name = muscle});
        }
    }
    
    private async Task loadPlaces()
    {
        Places = new List<PlaceDataModel>();
        using FileStream stream = File.OpenRead(_hostingEnvironment.WebRootPath + _configuration.GetValue<string>("PlacesPath"));
        
        List<string> PlacesJSON = await JsonSerializer.DeserializeAsync<List<string>>(stream);

        foreach (string place in PlacesJSON)
        {
            this.Places.Add(new PlaceDataModel(){Name = place});
        }
    }
    
    private async Task loadPlans()
    {
        Plans = new List<PlanDataModel>();
        using FileStream stream = File.OpenRead(_hostingEnvironment.WebRootPath + _configuration.GetValue<string>("PlansPath"));
        
        List<string> PlansJSON = await JsonSerializer.DeserializeAsync<List<string>>(stream);

        foreach (string plan in PlansJSON)
        {
            this.Plans.Add(new PlanDataModel(){Name = plan});
        }
    }
    
    private async Task loadTypse()
    {
        Typse = new List<TypeDataModel>();
        using FileStream stream = File.OpenRead(_hostingEnvironment.WebRootPath + _configuration.GetValue<string>("TypsePath"));
        
        List<string> TypseJSON = await JsonSerializer.DeserializeAsync<List<string>>(stream);

        foreach (string type in TypseJSON)
        {
            this.Plans.Add(new PlanDataModel(){Name = type});
        }
    }
    
}