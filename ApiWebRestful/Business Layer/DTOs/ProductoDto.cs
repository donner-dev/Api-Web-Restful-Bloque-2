namespace ApiWebRestful.Business_Layer.DTOs {


  //Los DTOs van en la capa de negocio porque el Service es el que hace 
  //la traducción entre entidad y DTO
  //el controlador solo habla con DTOs.



  public class ProductoDto {  //Este es el DTO SALIDA, lo llena el service, tiene Id para buscar y coso, no necesita validaciones
    //pensalo como que cosas son necesarias para que el front pueda mostrar la info del producto, y no mas
    //Los endpoints no deben retornar la entidad directa, sino este DTO proyectado.
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }
    //public bool Activo { get; set; } ?
  }
}
