var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
{
    builder.Services
                .AddShared()
                .AddApplications()
                .AddInfrastructure(builder.Configuration)
                .AddApi(builder.Configuration);
}

var app = builder.Build();
// Configure the HTTP request pipeline.
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        var dbInitializer = app.Services.GetService<IDbInitializerService>();
        dbInitializer.Initialize();
        dbInitializer.SeedData();
    }
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseShared();
    if (app.Environment.IsDevelopment())
    {
        app.UseCors("CorsPolicy");
    }
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

