using Microsoft.AspNetCore.Mvc.Razor;
using Principal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
builder.Services.AddSingleton<ICompteur, Compteur>();
builder.Services.AddSingleton<IParticipants, Participants>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var supportedCultures = new[] { "fr-CA", "fr-FR", "fr", "en-CA", "en-US", "en", "ja" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRouting();

app.UseAuthorization();


app.UseRequestLocalization(localizationOptions);


app.MapGet("bonjour/{prenom}/{nom?}", (string prenom, string? nom) => $"Bonjour {prenom} {nom}");

app.MapGet($"date/{{annee:range({DateTime.Now.Year-10},{DateTime.Now.Year})}}/{{mois:int}}/{{jour:int}}", (int annee, int mois, int jour) => $"date: {annee}/{mois}/{jour}");


app.MapControllerRoute(
    name: "Accueil",
    pattern: "accueil/{action=Index}/{id?}",
    defaults: new { controller="Home"}    
    );

app.MapControllerRoute(
    name: "Accueil2",
    pattern: "accueil/prive/{id?}",
    defaults: new { controller = "Home", action="Privacy" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
