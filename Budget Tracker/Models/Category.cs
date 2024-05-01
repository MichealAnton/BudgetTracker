using System.ComponentModel.DataAnnotations;

namespace Budget_Tracker.Models
{
    public enum Type
    {
        Income , Expense
    }
    
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s_]{3,}$", ErrorMessage = "please enter at least 3 letters")]
        public string Category_Name { get; set;}
        [Required]
        [RegularExpression(@"^(?=.*[1-9])\d*\.?\d+$", ErrorMessage = "please enter at least one digit")]
        public double budget { get; set;}
        [Required]
        public Type Type { get; set;}
        public string? Icon { get; set;}

    }
}
