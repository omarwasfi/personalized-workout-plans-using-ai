using System.Reflection;
using AI_FitMentor_Lib.DbContext;
using AI_FitMentor_Lib.Services.Classes;
using AI_FitMentor_Lib.Services.Interfaces;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AI Fit mentor API",
        Description = "The server side api",
        TermsOfService = new Uri("https://omarwasfi.com"),
        Contact = new OpenApiContact
        {
            Name = "Omar Wasfi",
            Email = "contact@omwasfi.com",
            Url = new Uri("https://omarwasfi.com"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://omarwasfi.com"),
        }
    });
    
});




builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<AIFitMentorDB>();
builder.Services.AddSingleton<IWorkoutPlanner,WorkoutPlanner>();


var app = builder.Build();

app.Urls.Add( builder.Configuration.GetValue<string>("httpUrl"));
app.Urls.Add(builder.Configuration.GetValue<string>("httpsUrl"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

