using WebAPI_SDK.Services;

var builder = WebApplication.CreateBuilder(args);

//Marcelo Modesto de Lima Junior CB3015823
//Bruna Helena Silva Santos      CB3016111

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<AtividadesService>(s => new AtividadesService("http://localhost:5095/api", new HttpClient()));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Atividades}/{action=Index}/{id?}");

app.Run();
