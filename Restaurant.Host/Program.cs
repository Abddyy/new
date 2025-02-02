using Restaurant.Application;
using Restaurant.Contracts.Interfaces;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddControllers();
builder.Services.AddScoped<IFoodService, FoodService>();  

var app = builder.Build();

 if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
