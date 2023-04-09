
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recetas
{
    [Key]
    public int RecetaId { get; set; }
    [Required]
    public int ProductoId { get; set; }

    [ForeignKey("RecetaId")]
    public List<DetalleRecetas> detalleRecetas { get; set; } = new List<DetalleRecetas>();

}
