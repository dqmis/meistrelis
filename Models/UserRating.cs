using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meistrelis.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public int ReviewerId;
        public User Reviewer;

        public int RatedUserId;
        public User RatedUser;
    }
}