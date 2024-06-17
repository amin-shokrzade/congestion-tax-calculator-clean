using Application;
using Ardalis.GuardClauses;
using Infrastructure;
using Website;
using Website.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddWebServices();


const string corsPolicyName = "CongestionTaxCalculatorCORS";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
    builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var useUrl = builder.Configuration.GetValue<string>("CongestionTaxCalculatorSecurity:UseUrl");

Guard.Against.Null(useUrl, message: "UseUrl not found.");

builder.WebHost.UseUrls(useUrl);

var app = builder.Build();

app.UseCors(corsPolicyName);



if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.UseAuthentication();

app.UseAuthorization();

app.Run();

public partial class Program { }