using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meistrelis.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Fullname { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
        
        [Required]
        public bool IsMechanic { get; set; }
        
        public ICollection<UserService> UserServices { get; set; }
        public ICollection<UserRating> ReviewedUsers { get; set; }
        public ICollection<UserRating> UserRatings { get; set; }
    }
}