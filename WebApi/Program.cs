using Application;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using Infrastructure;
using Infrastructure.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new MappingProfile(typeof(IApplicationDbContext).Assembly));
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occured while app initialization");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();
