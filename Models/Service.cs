using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meistrelis.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public ICollection<UserService> UserServices { get; set; }
    }
}