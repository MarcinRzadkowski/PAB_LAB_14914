using SoapCore;
using SoapServers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseSoapEndpoint<IUserService>("/UserService.asmx", new SoapEncoderOptions());

app.Run();
