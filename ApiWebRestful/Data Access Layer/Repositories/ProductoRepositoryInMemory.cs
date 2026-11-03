using ApiWebRestful.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiWebRestful.Data_Access_Layer.Repositories {
  public class ProductoRepositoryInMemory : IProductoRepository {

    private List<Producto> productlist;  
    //private asi solo la tocan los metodos de esta clase (q igual es default en las clases ahre)
    
    public ProductoRepositoryInMemory() {  //constructor: no tiene tipo devuelto y se llama igual q la clase 

      //seed data
      //en este mundo ideal de seed data, los productos son bien baratos y no existe la inflacion <3 
      productlist = new List<Producto> { //inicializo, nueva instancia de lista prod, y nesteo inicializar 4 New Product
        new Producto { Id = 1, Nombre = "Jabón", Precio = 10.99m, Categoria = "Limpieza", Activo = true},
        new Producto { Id = 2, Nombre = "Arvejas", Precio = 5.99m, Categoria = "Alimentos", Activo = true},
        new Producto { Id = 3, Nombre = "Leche Proteica", Precio = 8.50m, Categoria = "Alimentos", Activo = true},
        new Producto { Id = 4, Nombre = "Detergente", Precio = 4.75m, Categoria = "Limpieza", Activo = false},
      }; 

    }


    //truquito implementar interfaz: seleccionar interfaz y luego CTRL + "."  -> implementar interfaz
    public void Agregar(Producto productoplaceholder) {
      if (productoplaceholder == null) {
        throw new ArgumentNullException(nameof(productoplaceholder));
      } //NO ME AGREGUES COSAS VACIAS, POR FAVOR, GRACIAS
      productlist.Add(productoplaceholder);
      
    }

    public int ObtenerSiguienteId() {
      int siguienteId = productlist.Count > 0 ? productlist.Max(p => p.Id) + 1 : 1;
      //si hay productos, el siguiente id es el maximo + 1, sino es 1
      return siguienteId;
      //o si no, productList.Last -> Select (x=> x.Id) + 1, pero eso es menos eficiente pq recorre toda la lista)
    }

    public List<Producto> BuscarPorCategoria(string categoria) {
      return productlist.Where(p => p.Categoria == categoria).ToList();
      //el where query devuelve IEnumerable tonce lo convierto a lista pq este metodo devuelve lista de prod
    }

    public Producto ObtenerPorId(int id) {
      return productlist.FirstOrDefault(p => p.Id == id); //me da el primer elemento q cumple la condicion, o null si no hay ninguno
    }

    public List<Producto> ObtenerTodos() {
      return productlist.OrderBy(x => x.Id).ToList();


      //podria hacer return productlist nomas pero ahí estoy pasando la lista entera como referencia y a futuro eso es un riesgo de vulnerabilidad
    }

    public Producto EliminarPorId(int id) {
      var productoAEliminar = ObtenerPorId(id);
      if (productoAEliminar != null) {
        productlist.Remove(productoAEliminar);
      }
      return productoAEliminar; //devuelvo el producto eliminado, o null si no se encontro
      //return NoContext();? pero ese va para los controladores claro
    }

    public Producto ActualizarPorId(int id, Producto productoActualizado) {
      if (productoActualizado == null) {
        throw new ArgumentNullException(nameof(productoActualizado));
      }
      var productoExistente = ObtenerPorId(id);
      if (productoExistente != null) {
        productoExistente.Nombre = productoActualizado.Nombre;
        productoExistente.Precio = productoActualizado.Precio;
        productoExistente.Categoria = productoActualizado.Categoria;
        productoExistente.Activo = productoActualizado.Activo;
      }
      return productoExistente; //devuelvo producto actualizado o null si no hay
    }

  }

}
