using System.ComponentModel.DataAnnotations;

public class MateriasPrimas
{
    [Key]
    public int MateriaPrimaId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public string Nombre { get; set; }

    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public int Existencia { get; set; }


}
