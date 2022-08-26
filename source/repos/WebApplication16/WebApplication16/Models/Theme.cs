using System.ComponentModel.DataAnnotations;

namespace WebApplication16.Models
{
    public class Theme
    {
        [Key]
        public int IdTheme { get; set; }
        [Required]
        public string NameTheme { get; set; }

    }
}
