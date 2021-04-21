using System.ComponentModel.DataAnnotations;

namespace meistrelis.Dtos.UserRating
{
    public class UserRatingCreateDto
    {
        [Required]
        public string Score { get; set; }
        [Required]
        public float Description { get; set; }
    }
}