using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models.Request
{
    public class LoginRequest
    {
        [Required]
        public string useremail { get; set; }
        [Required]
        public string userpassword { get; set; }

    }
}
