using System.ComponentModel.DataAnnotations;

namespace PracticaFinalAPI.Models;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es requerida")]
    [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El precio es requerido")]
    [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
    [Display(Name = "Precio")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El stock es requerido")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0")]
    [Display(Name = "Stock")]
    public int Stock { get; set; }
}

