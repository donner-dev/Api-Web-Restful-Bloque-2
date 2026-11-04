using Microsoft.AspNetCore.Mvc;
using ApiWebRestful.Business_Layer.DTOs;
using ApiWebRestful.Business_Layer.Services;

//Expone los Endpoints HTTP y tiene q retornar IActionResult (Ok, CreatedAtAction, BadRequest, NotFound, NoContent)


//controller nunca ve Producto, solo recibe CreateProductoDto y devuelve ProductoDto.

//cada metodo recibe el pedido, le piden el trabajo a Service, y segun lo que devuelve eligen la respuesta http.
namespace ApiWebRestful.Presentation_Layer.Controllers {


  [Route("api/[controller]")]
  [ApiController] //atributos que me hacen la vida mas facil
  public class ProductosController : ControllerBase {
    //inyeccion de dependencias, el controller no conoce el service, solo la interfaz
    private readonly IProductoService _prodService;

    public ProductosController(IProductoService productService) {
      _prodService = productService;
    }


    // GET: api/productos
    [HttpGet]
    public IActionResult ObtenerTodos() {
      var products = _prodService.ObtenerTodos();
      if (products == null || products.Count == 0) {
        return NotFound(new { Message = "No se encontraron productos" });
      }
      return Ok(products);
    }



    // GET api/productos/5
    [HttpGet("{id:int}")]
    public IActionResult ObtenerPorId(int id) {
      var product = _prodService.ObtenerPorId(id);
      if (product == null) {
        return NotFound(new {Message = $"Producto con ID {id} no encontrado"});
      }
      return Ok(product);
    }





    // POST api/productos
    [HttpPost]
    public IActionResult Agregar([FromBody] CreateProductoDto createproductodto) {
      if(createproductodto == null) {
        return BadRequest();
      }


      var nuevoproducto = _prodService.Agregar(createproductodto);
      return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoproducto.Id }, nuevoproducto);
    }
    
    



    // PUT api/productos/5
    [HttpPut("{id:int}")]
    //put tmb tiene que recibir CreateProductoDto porque el id no se lo pasan, y el activo tampoco, solo lo que viene de afuera. El service le asigna el id y el activo por default.
    public IActionResult ActualizarPorId(int id, [FromBody] CreateProductoDto updateproductodto) {
      if (updateproductodto == null) {
        return BadRequest();
      }

      var existingProduct = _prodService.ObtenerPorId(id);
      if (existingProduct == null) {
        return NotFound(new { Message = $"Producto con ID {id} no encontrado" });
      }

      // Actualizar las propiedades del producto existente
      existingProduct.Nombre = updateproductodto.Nombre;
      existingProduct.Precio = updateproductodto.Precio;
      existingProduct.Categoria = updateproductodto.Categoria;

      _prodService.ActualizarPorId(existingProduct.Id, existingProduct);
      return Ok(existingProduct);
    }




    // DELETE api/productos/5
    [HttpDelete("{id:int}")]
    public IActionResult EliminarPorId(int id) {
      var aEliminar = _prodService.EliminarPorId(id);
      if (aEliminar == false) {
        return NotFound(new { Message = $"Producto con ID {id} no encontrado" });
      }
      
      return NoContent();
    }



  }


}
