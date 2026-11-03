using ApiWebRestful.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiWebRestful.Data_Access_Layer.Repositories {
  public interface IProductoRepository {
    void Agregar(Producto productoplaceholder); //"Esto tiene que existir"
    //La convencion es repetir el nombre de la clase en minúscula pero va productoplaceholder asi no me pierdo por ahora
    int ObtenerSiguienteId();
    List<Producto> ObtenerTodos();
    //que devuelve   el nombre  (que recibe)
    //el metodo devuelve una lista de productos 
    Producto ObtenerPorId(int id);
    //devuelve producto,   ObtenerPorId(recibe id int)
    //claro fijate que las que no retornan nada se llaman void
    List<Producto> BuscarPorCategoria(string categoria);
    Producto EliminarPorId(int id);
    Producto ActualizarPorId(int id, Producto productoActualizado);
  }
}


//en una interfaz todo es public por default, no hace falta ponerlo, pero si lo pones no pasa nada.

