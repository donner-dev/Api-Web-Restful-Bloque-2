using ApiWebRestful.Business_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

//"Hacia arriba" habla en DTOs, "hacia abajo" habla en Entidades (Models)
namespace ApiWebRestful.Business_Layer.Services {
  public interface IProductoService {
    //Que necesita recibir el service? Que le devuelve al Controller para que elija una respuesta http?
    List<ProductoDto> ObtenerTodos();  //GET 
    ProductoDto? ObtenerPorId(int id); //GET(ID)

    ProductoDto Agregar(CreateProductoDto producto); //POST
    //devuelve el DTO creado para que pase al Body con POST?

    bool EliminarPorId(int id); //DELETE(ID)
    //el controller necesita saber si se elimino o no, para devolver 404 o 204, 
    
    ProductoDto? ActualizarPorId(int id, CreateProductoDto productoActualizado); //PUT(ID)

  }
}
