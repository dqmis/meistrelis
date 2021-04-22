using System.ComponentModel.DataAnnotations;

namespace meistrelis.Dtos.User 
{
    public class UserCreateDto
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
        [MaxLength(15)]
        public string Phone { get; set; }
        [Required]
        public bool IsMechanic { get; set; }
    }
}