using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
