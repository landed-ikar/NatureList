using System.ComponentModel.DataAnnotations;

namespace NatureListService.Models {
    public class LoginDTO {
        [Required(ErrorMessage = "User Name is required")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
