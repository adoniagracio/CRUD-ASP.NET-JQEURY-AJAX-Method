using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Models
{
    public class Category {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(255)]
        public string NameCategory { get; set; }

        public int UserId { get; set; }
    }
}
