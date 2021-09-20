using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo eh obrigatorio!")]
        [MaxLength(10, ErrorMessage = "Este campo deve conter no maximo 10 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter no minimo 5 caracteres")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no maximo 20 caracteres")]
        public string Description { get; set;}

        [Required(ErrorMessage = "Este campo eh obrigatorio!")]
        [Range(1.0, float.MaxValue, ErrorMessage = "Este campo deve ser maior que zero!")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Este campo eh obrigatorio!")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Invalida")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        
    }
}