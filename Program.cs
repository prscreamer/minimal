var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();
var httpPort = app.Configuration["HttpPort"] ?? "5000";
var httpsPort = app.Configuration["HttpsPort"] ?? "5001";

app.UseHttpLogging();
app.Urls.Add($"http://*:{httpPort}");
app.Urls.Add($"https://*:{httpsPort}");

app.MapGet("/", () => String.Format("It's now {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
app.MapGet("/test", () => String.Format("Test started {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));

app.Run();
