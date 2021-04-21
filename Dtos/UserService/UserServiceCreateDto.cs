using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace meistrelis.Dtos.UserService
{
    public class UserServiceCreateDto
    {
        [Required]
        public string ServiceId { get; set; }
        [Required]
        public float Price { get; set; }
    }
}