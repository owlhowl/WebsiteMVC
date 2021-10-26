using System.ComponentModel.DataAnnotations;

namespace WebsiteMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
