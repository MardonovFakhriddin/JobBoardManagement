// using Domain.Models;

using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Services;
using Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IContext,DapperContext>();
builder.Services.AddScoped<IApplicationService<Application>, ApplicationService>();
builder.Services.AddScoped<IJobService<Job>, JobService>();
builder.Services.AddScoped<IUserService<User>, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "JobBoardManagement"));
}

app.MapControllers();
app.Run();

