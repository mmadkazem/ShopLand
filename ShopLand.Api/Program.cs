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
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseShared();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

