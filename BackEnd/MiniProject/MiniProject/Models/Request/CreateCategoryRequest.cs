using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models.Request
{
    public class CreateCategoryRequest
    {
        public int CategoryId { get; set; }
        [Required]
        public string NameCategory { get; set; }
        public int UserId { get; set; }
    }
}
