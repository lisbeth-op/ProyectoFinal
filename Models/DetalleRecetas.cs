using System.ComponentModel.DataAnnotations;

public class DetalleRecetas
   {
    [Key]
    public int DetalleRecetaId { get; set; }
    [Required]
    public int RecetaId { get; set; }
    [Required]
    public int MateriaPrimaId { get; set; }
    [Required]
    public int Cantidad { get; set; }

}

