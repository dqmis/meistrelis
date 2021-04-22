using System.Text.Json.Serialization;

namespace meistrelis.Dtos.UserService
{
    public class UserServiceReadDto
    {
        public string MechanicFullname{ get; set; }
        public string MechanicEmail { get; set; }
        public string MechanicPhone { get; set; }
        public string ServiceTitle { get; set; }
        public float Price { get; set; }
    }
}