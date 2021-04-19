using System.ComponentModel.DataAnnotations;

namespace meistrelis.Models
{
    public class Service
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
    }
}