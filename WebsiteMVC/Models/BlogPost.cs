using System.ComponentModel.DataAnnotations;

namespace WebsiteMVC.Models
{
    public class BlogPost
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Не указан заголовок")]
        [StringLength(60, ErrorMessage = "Слишком длинный заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Нет содержимого")]
        public string Content { get; set; }
        public System.DateTime Date { get; set; }
    }
}
