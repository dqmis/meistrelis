using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace meistrelis.Dtos.UserService
{
    public class UserServiceUpdateDto
    {
        [Required]
        public float Price { get; set; }
    }
}