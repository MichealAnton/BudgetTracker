using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        //  [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; }

      //  [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; }

        //  [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; }

      //  [NotMapped]
        
    }
}
