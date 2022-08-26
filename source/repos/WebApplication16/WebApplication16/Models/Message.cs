using System.ComponentModel.DataAnnotations;

namespace WebApplication16.Models
{
    public class Message
    {
        [Key]
        public int IdMessage { get; set; }
        [Required]
        [Range(1,300, ErrorMessage = "This field cannot be empty")]
        public string TextMessage { get; set; }
  
    }
}
