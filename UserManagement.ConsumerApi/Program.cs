using UserManagement.Application;
using UserManagement.ConsumerApi;
using UserManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Configuration
        .AddJsonFile(
            "appsettings.json",
            optional: false,
            reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{builder.Environment.EnvironmentName}.json",
            optional: true,
            reloadOnChange: false)
        .AddEnvironmentVariables()
    .Build();

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration, builder.Configuration.GetValue<string>)
        .AddApi();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


