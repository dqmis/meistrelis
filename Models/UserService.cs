namespace meistrelis.Models
{
    public class UserService
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        
        public User User { get; set; }
        public Service Service { get; set; }
        
        public float Price { get; set; }
    }
}