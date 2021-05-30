namespace meistrelis.Dtos.UserRating
{
    public class UserRatingsReadDto
    {
        public int RatedUserId { get; set; }
        public int ReviewerId { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
    }
}