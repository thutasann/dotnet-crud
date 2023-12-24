using dotnet_crud.Repositories;
using dotnet_crud.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICrudSL, CrudSL>();
builder.Services.AddScoped<ICrudRL, CrudRL>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

