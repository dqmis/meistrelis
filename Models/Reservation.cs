using System;
using System.ComponentModel.DataAnnotations;

namespace meistrelis.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        public int UserId;
        public int ServiceId;

        public User User;
        public UserService Service;
    }
}