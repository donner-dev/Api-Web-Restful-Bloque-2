using ApiWebRestful.Business_Layer.DTOs;
using ApiWebRestful.Data_Access_Layer.Repositories;
using ApiWebRestful.Data_Access_Layer.Models;
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
      return new ProductoDto {
        Id = producto.Id,
        Nombre = producto.Nombre,
        Precio = producto.Precio,
        Categoria = producto.Categoria,
       };
    }
    //===============================


    public List<ProductoDto> ObtenerTodos() {
      List<ProductoDto> productDtoList = new List<ProductoDto>();
      //obtener la lista de productos de alguna forma 
      //for each producto in productlist, mapToDto(producto) y agregar a productDtoList
      var productList = servicerepo.ObtenerTodos();
      foreach (var producto in productList) {
        if (producto != null) {
          var productoDto = MapToDto(producto);
          productDtoList.Add(productoDto);
        }
      }

      return productDtoList;
    }

    public ProductoDto? ObtenerPorId(int id) {
      var product = servicerepo.ObtenerPorId(id);
      if (product == null) {
        return null;
      }
      return MapToDto(product);
    }



    public ProductoDto Agregar(CreateProductoDto producto) {
      Producto newprod = new Producto {
        Id = servicerepo.ObtenerSiguienteId(),
        Nombre = producto.Nombre,
        Precio = producto.Precio,
        Categoria = producto.Categoria,
        Activo = true
      };
      servicerepo.Agregar(newprod);
      return MapToDto(newprod);
    }

    public bool EliminarPorId(int id) {
      Producto deleted = servicerepo.EliminarPorId(id);
      if (deleted == null) {
        return false;
      }
      return true;
    }

    public ProductoDto? ActualizarPorId(int id, CreateProductoDto productoActualizado) {

      Producto product = servicerepo.ObtenerPorId(id); //verifico que exista el producto a actualizar
      if (product == null) {
        return null;
      }
      Producto updated = new Producto {
        Id = product.Id,
        Nombre = productoActualizado.Nombre,
        Precio = productoActualizado.Precio,
        Categoria = productoActualizado.Categoria,
        Activo = product.Activo
      };
      var guardado=servicerepo.ActualizarPorId(id, updated);
      if (guardado == null) { return null; }
      return MapToDto(guardado);
    }

  }

}

