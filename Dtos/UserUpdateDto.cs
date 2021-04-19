using System.ComponentModel.DataAnnotations;

namespace meistrelis.Dtos 
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Fullname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        public bool IsMechanic { get; set; }
    }
}