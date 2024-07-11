using System.ComponentModel.DataAnnotations;

namespace ProyectoEjemploMod10.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get;set; }

        [Required(ErrorMessage = "El nombe es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre del departamento")]

        public string Nombre { get; set; } = string.Empty;
    }

}
