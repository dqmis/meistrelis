using System.ComponentModel.DataAnnotations;

namespace meistrelis.Dtos.UserRating
{
    public class UserRatingCreateDto
    {
        [Required]
        public float Score { get; set; }
        [Required]
        public string Description { get; set; }
    }
}