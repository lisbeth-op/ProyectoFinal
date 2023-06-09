﻿using System.ComponentModel.DataAnnotations;

public class MateriasPrimas
{
    [Key]
    public int MateriaPrimaId { get; set; }

    [Required(ErrorMessage = "Debe asignarle nombre a la materia prima.")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Se requiere un precio.")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public int Existencia { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;


}
