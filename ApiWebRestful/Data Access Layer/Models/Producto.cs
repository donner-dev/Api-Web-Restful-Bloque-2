using System;
using System.Collections.Generic;
using System.Text;

namespace ApiWebRestful.Data_Access_Layer.Models {
  public class Producto {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }
    public bool Activo { get; set; }

  }
}

//Producto va en la capa de datos porque representa cómo se guarda un producto. Es el único que conoce el repositorio.