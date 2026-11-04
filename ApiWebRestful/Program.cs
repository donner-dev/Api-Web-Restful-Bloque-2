using ApiWebRestful.Business_Layer.Services;
using ApiWebRestful.Data_Access_Layer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();


builder.Services.AddScoped<IProductoService, ProductoService>();
//entre () van valores. Entre <> van tipos. Vos le decis "trabaja con estos tipos"

//cada registro une una interfaz con su clase concreta:
//Controller pide IProductoService -> .NET le da ProductoService
//
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
//el coso basicamente une la interfaz con su coso concreto asi cuando uso la interfaz en otro lado (como en el controller) sabe COMO debe implementar esos metodos
//pero porque no uso directamente el coso concreto entonces T_T ???


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
  app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
