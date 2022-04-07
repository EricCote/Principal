using Principal.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICompteur, Compteur>();

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

app.UseRouting();

app.UseAuthorization();

app.MapGet("bonjour/{prenom}/{nom?}", (string prenom, string nom) => $"Bonjour {prenom} {nom}");

app.MapGet($"date/{{annee:range({DateTime.Now.Year},{DateTime.Now.Year+100})}}/{{mois:int}}/{{jour:int}}", (int annee, int mois, int jour) => $"date: {annee}/{mois}/{jour}");


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
