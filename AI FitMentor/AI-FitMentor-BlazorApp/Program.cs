using AI_FitMentor_BlazorApp.Components;
using AI.FitMentor.BlazorApp.Services.Classes;
using AI.FitMentor.BlazorApp.Services.Interfaces;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")) });
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAIFitMentorService,AIFitMentorService>();


builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();