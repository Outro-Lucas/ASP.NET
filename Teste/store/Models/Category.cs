using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Este campo eh obrigatorio!")]
        [MaxLength(10, ErrorMessage = "Este campo deve conter no maximo 10 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter no minimo 5 caracteres")]
        public string Name { get; set; }
    }

}