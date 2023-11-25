using AI_FitMentor_Lib.DataModels;
using AI_FitMentor_Lib.Services.Interfaces;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;

namespace AI_FitMentor_Lib.Services.Classes;

public class WorkoutPlanner : IWorkoutPlanner
{
    private OpenAIClient _openAiClient;
    private IConfiguration _configuration;

    public WorkoutPlanner(IConfiguration configuration)
    {
        this._configuration = configuration;
        
        string proxyUrlSTR =  _configuration.GetValue<string>("OpenAiSettings:endpoint");
        string key = _configuration.GetValue<string>("OpenAiSettings:key");
        
        Uri proxyUrl = new(proxyUrlSTR + "/v1/api");

        AzureKeyCredential token = new(key + _configuration.GetValue<string>("OpenAiSettings:GithubAlias"));

        OpenAIClient openAIClient = new(proxyUrl, token);

        this._openAiClient = openAIClient;
    }
    
    public async Task<string> Generate(PersonDataModel person)
    {
        ChatCompletionsOptions completionOptions = new() {
            MaxTokens=2048,
            Temperature=0.7f,
            NucleusSamplingFactor= 0.95f,
            DeploymentName = "gpt-35-turbo"
        };
        
        completionOptions.Messages.Add(new ChatMessage(ChatRole.System, _configuration.GetValue<string>("OpenAiSettings:ChatRole")));
        
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "Hi, my sex is: " + person.Sex + ", my weight is: " + person.Weight + ", My height is: " + person.Height +"and My goals is " + person.MyGoals));
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "I'll be able to use only the following Equipments " + person.GetEquipments()));
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "I want to target only the following muscles " + person.GetMuscles()));
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "I will train in or at the " + person.Place.Name));
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "I want my training plan to be  " + person.Plan.Name + "I want to train " + person.Plan.DaysPerWeek + " times per week and I want the session duration to be around " + person.Plan.MinsPerSession + " minuets per session"));
        completionOptions.Messages.Add(new ChatMessage(ChatRole.User, "I want my workout type to be " + person.WorkoutType.Name));
        
        var response = await _openAiClient.GetChatCompletionsAsync(completionOptions);

        string plan = response.Value.Choices[0].Message.Content;

        return plan;
    }
}