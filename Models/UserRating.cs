using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meistrelis.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public int Score { get; set; }

        public int ReviewerId;
        public int RatedUserId;

        public User Reviewer;
        public User RatedUser;
    }
}