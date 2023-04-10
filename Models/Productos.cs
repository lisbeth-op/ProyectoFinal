
using System.ComponentModel.DataAnnotations;
public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    public int RecetaId { get; set; }

    [Required(ErrorMessage = "Se debe agregar nombre al producto.")]
    [MinLength(2)]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    public double Precio { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]

    public int Existencia { get; set; }




}

