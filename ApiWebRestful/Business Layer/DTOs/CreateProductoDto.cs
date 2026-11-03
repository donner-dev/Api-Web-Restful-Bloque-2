using System.ComponentModel.DataAnnotations;

//un DTO solo tiene propiedades. No hay metodos. (DATA) transfer object
//solo lo que el de afuera necesita mandar o ver.

//las validaciones van en el DTO de entrada, porque es lo que llega de afuera y hay uqe revisarlo



namespace ApiWebRestful.Business_Layer.DTOs {
  public class CreateProductoDto {
    //Este es el DTO ENTRADA, lo llena el controlador, tiene validaciones para que no se rompa nada, no tiene Id porque no hace falta
    [Required]
    [StringLength(100,MinimumLength =3)]
    public string Nombre { get; set; }


    [Required]
    [Range(0, double.MaxValue,MinimumIsExclusive =true )]
    public decimal Precio { get; set; }


    [Required]
    public string Categoria { get; set; }
  }
}
