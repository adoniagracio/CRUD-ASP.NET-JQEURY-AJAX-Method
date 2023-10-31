using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models.Request
{
    public class RegisterRequest
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string useremail { get; set; }
        [Required]
        public string userpassword { get; set; }
    }
}
