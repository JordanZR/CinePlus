using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cinePlus.Models
{
    public class UsuarioModel
    {
        // Propiedad Id
        public int Id { get; set; }
        [Required]

        [DisplayName("User Name")]
        // Propiedad Name
        public string Name { get; set; }
        [Required]

        // Propiedad Email
        public string Email { get; set; }

    }
}
