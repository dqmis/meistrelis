using System.ComponentModel.DataAnnotations;

namespace meistrelis.Dtos.User 
{
    public class UserUpdateDto
    {
        public string Password { get; set; }
        public bool IsMechanic { get; set; }
        public string Phone { get; set; }
    }
}