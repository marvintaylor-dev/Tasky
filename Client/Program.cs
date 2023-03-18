global using Microsoft.AspNetCore.Components.Authorization;
global using Tasky.Client.Services.TagService;
global using Tasky.Client.Services.TaskService;
global using Tasky.Client.Services.MemberService;
global using Tasky.Client.Services.AuthService;
global using Tasky.Client.Services.SectionService;
global using Tasky.Client.Services.StatusService;
global using System.Net.Http.Json;
global using Tasky.Shared;
global using Tasky.Client.Services.EditSaveService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tasky.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IEditSaveService, EditSaveService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddOptions();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();



await builder.Build().RunAsync();
