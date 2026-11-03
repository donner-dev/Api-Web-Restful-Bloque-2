using Gestión_de_Productos_en_Consola.Models;
using Gestión_de_Productos_en_Consola.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//uhhh??

// Una tienda local necesita un prototipo simple para gestionar sus productos en memoria antes de migrar su sistema a una Web API. Deberás construir una solución de consola que modele los datos y permita realizar operaciones básicas sobre el catálogo.
Console.OutputEncoding = System.Text.Encoding.UTF8;
IProductoRepository repo = new ProductoRepositoryInMemory(); //?????????????instancio la clase q implementa la interfaz, y lo guardo en una variable de tipo interfaz
                                                     //repo compatible con cualquiera q tenga contrato IProductRepository
                                                     //asi el resto del codigo depende de la interfaz y no de la implementacion concreta, lo q es bueno pq si mañana cambio la implementacion no tengo q cambiar el resto del codigo

//pequeño menusito

int option = 0;
while (option != 5) {

  Console.WriteLine("░╔══════════════════════════════════════╗░");
  Console.WriteLine("░║                                      ║░");
  Console.WriteLine("░║    Consola de Gestión de Productos   ║░");
  Console.WriteLine("░║                                      ║░");
  Console.WriteLine("░╚══════════════════════════════════════╝░");
  Console.WriteLine("");
  Console.WriteLine("");
  Console.WriteLine("  ╬  [ Elija una opcion: ]  ╬");

  Console.WriteLine("       ──────────────────");
  Console.WriteLine("");
  Console.WriteLine("1.   Ver lista de productos");
  Console.WriteLine("2.   Buscar producto por ID");
  Console.WriteLine("3.   Filtrar productos por categoría");
  Console.WriteLine("4.   Agregar nuevo producto");
  Console.WriteLine("5.   Salir");

  Console.WriteLine("");
  Console.WriteLine("════════════════════════════════════════");
  string? entrada = Console.ReadLine();

  if (!int.TryParse(entrada, out option)) {
    Console.WriteLine("⚠ Ingrese un número válido.");
    continue;
  }
  Console.Clear(); //maybe?




  switch (option) {
    case 1:
      Console.WriteLine(" 🝊 Lista de todos los productos: 🜄");
      var showrepo = repo.ObtenerTodos();
      foreach (var producto in showrepo) {
        Console.WriteLine($"ID: {producto.Id} | Nombre: {producto.Nombre} | Categoría: {producto.Categoria} | Precio: $ {producto.Precio}");
      }

      break;

    case 2:
      Console.WriteLine("Ingrese el ID del producto a buscar:");
      string? idInput = Console.ReadLine();
      if (int.TryParse(idInput, out int id)) {
        var producto = repo.ObtenerPorId(id);
        if (producto != null) {
          Console.WriteLine($"ID: {producto.Id} | Nombre: {producto.Nombre} | Categoría: {producto.Categoria} | Precio: $ {producto.Precio}");
        } //incluso podria hacer un propio metodito para este formato de print producto  -> Product.PrintProd() o algo asi
        else {
          Console.WriteLine("⚠ Producto no encontrado.");
        }
      }
      else {
        Console.WriteLine("⚠Ingrese un ID válido.");
      }
      break;

    case 3:
      var categorias = repo.ObtenerTodos()
                              .Select(p => p.Categoria)
                                .Distinct()
                                  .ToList();

      Console.WriteLine("Categorías disponibles:");
      foreach (var c in categorias) {
        Console.WriteLine("- " + c);
      }
      Console.WriteLine("Ingrese categoría para filtrar productos:");
      string? categoriaInput = Console.ReadLine();
      if (!string.IsNullOrEmpty(categoriaInput)) {
        var productos = repo.BuscarPorCategoria(categoriaInput);
        if (productos.Any()) {
          Console.WriteLine("Productos encontrados:");
          foreach (var producto in productos) {
            Console.WriteLine($"ID: {producto.Id} | Nombre: {producto.Nombre} | Categoría: {producto.Categoria} | Precio: /$ {producto.Precio}");
          } //de nuevo. Product.ShowProduct() o algo asi para no repetir este formato de print
        }
        else {
          Console.WriteLine("No se encontraron productos en esa categoría.");
        }
      }
      else {
        Console.WriteLine("⚠ Ingrese una categoría válida.");
      }
      break;

    case 4:
      Console.WriteLine("Ingrese el nombre del nuevo producto:");
      string? nombre = Console.ReadLine();
      Console.WriteLine("Ingrese la categoría del nuevo producto:");
      string? categoria = Console.ReadLine();
      Console.WriteLine("Ingrese el precio del nuevo producto:");
      string? precioInput = Console.ReadLine();

      if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(categoria) && decimal.TryParse(precioInput, out decimal precio)) {
        var nuevoProducto = new Producto {
          Id = repo.ObtenerSiguienteId(),
          Nombre = nombre,
          Categoria = categoria,
          Precio = precio,
          Activo = true //asumo xd
        };
        repo.Agregar(nuevoProducto);
        Console.WriteLine("☑ Producto agregado exitosamente.");
      }
      else {
        Console.WriteLine("⨻ Ingrese datos válidos para el nuevo producto.");
      }
      break;

    case 5:

      Console.WriteLine("╔══════════════════════════════════════╗");
      Console.WriteLine("║   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ║");
      Console.WriteLine("║  ░░░░░░░░░░░░░░ CHAU! ░░░░░░░░░░░░░░ ║");
      Console.WriteLine("║   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ║");
      Console.WriteLine("╚══════════════════════════════════════╝");
      break;

    default:
      Console.WriteLine("Opcion invalida, elegir entre 1 y 5.");

      break;

  }
  Console.WriteLine("");
  Console.WriteLine("Presioná una tecla para continuar...");
  Console.ReadKey();
  Console.Clear();

}
