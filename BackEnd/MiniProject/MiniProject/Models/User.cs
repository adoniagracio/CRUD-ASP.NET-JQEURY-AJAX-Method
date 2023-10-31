using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(255)]
        public string userName { get; set; }
        [MaxLength(255)]
        public string useremail { get; set; }
        [MaxLength(255)]
        public string userpassword { get; set; }

    }
}
