using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models.Request
{
    public class UpdateCategoryRequest
    {
        public int CategoryId { get; set; }
        [Required]
        public string NameCategory { get; set; }
    }
}
