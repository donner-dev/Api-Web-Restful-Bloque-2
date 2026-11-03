using ApiWebRestful.Business_Layer.DTOs;
using ApiWebRestful.Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

//un service es un traductor
//Transforman entre Entidades y DTOs

//service tiene que conocer el repositorio para poder pedirle cosas, 
//y tiene que conocer los DTOs para poder devolverlos al controlador

namespace ApiWebRestful.Business_Layer.Services {
  public class ProductoService : IProductoService {

    private IProductoRepository servicerepo;

    public ProductoService(IProductoRepository repo) {
      servicerepo = repo;
    }

    //  transformar producto a productoDTO
    private ProductoDto MapToDto(Producto producto) {
      if (producto == null) {
        return null;
      }
      return new ProductoDto {
        Id = producto.Id,
        Nombre = producto.Nombre,
        Precio = producto.Precio,
        Categoria = producto.Categoria,
        Activo = false  //no quiero que el DTO tenga el campo Activo, asi que lo pongo en false
      };
    }
    //===============================


    public List<ProductoDto> ObtenerTodos() {
      List<ProductDto> productdtolist;
      return productdtolist;
    }


    public ProductoDto? ActualizarPorId(int id, CreateProductoDto productoActualizado) {
      throw new NotImplementedException();
    }

    public ProductoDto Agregar(CreateProductoDto producto) {
      throw new NotImplementedException();
    }

    public bool EliminarPorId(int id) {
      throw new NotImplementedException();
    }

    public ProductoDto? ObtenerPorId(int id) {
      throw new NotImplementedException();
    }

   
  }

}

