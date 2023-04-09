
using System.ComponentModel.DataAnnotations;

public class DetalleOrdenDeProduccion
    {
    [Key]
    public int DetelleOrdenDeProduccionID { get; set; }
    [Required]
    public int OrdenProduccionId { get; set; }
    [Required]
    public int ProductoId { get; set; }
    [Required]
    public int Cantidad { get; set; }

}

