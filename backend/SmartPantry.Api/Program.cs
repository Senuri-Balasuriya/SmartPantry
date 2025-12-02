using Microsoft.EntityFrameworkCore;
using SmartPantry.Api.Mappings;
using SmartPantry.Api.Repositories;
using SmartPantry.Api.Repositories.Interfaces;
using SmartPantry.Api.Services;
using SmartPantry.Api.Services.Interfaces;
using SmartPantry.Api.Data;
using SmartPantry.API.Data;
using SmartPantry.API.Repositories;
using SmartPantry.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register Repositories
builder.Services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
builder.Services.AddScoped<IGroceryRepository, GroceryRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISmartShoppingRepository, SmartShoppingRepository>();


// Register Services
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddScoped<ISmartShoppingService, SmartShoppingService>();


// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
