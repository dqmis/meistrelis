namespace meistrelis.Dtos.User
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool IsMechanic { get; set; }
        public string Phone { get; set; }
        public double Rating { get; set; }
    }
}