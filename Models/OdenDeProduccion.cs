using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrdenDeProducciones
    {
    [Key]
    public int OrdenDeProduccionId { get; set; }
    [Required(ErrorMessage = "Indique la fecha.")]
    public DateTime Fecha { get; set; }= DateTime.Now; //.ToString("dd/MM/yyyy")
    public decimal CostoTotal { get; set; }

    [ForeignKey("OrdenDeProduccionId")]
    public virtual List<DetalleOrdenDeProduccion> DetalleOrdenDeProduccions { get; set; } = new List<DetalleOrdenDeProduccion>();
}

