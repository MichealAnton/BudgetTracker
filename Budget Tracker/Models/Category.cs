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
        public string Category_Name { get; set;}
        [Required]
        public double budget { get; set;}
        [Required]
        public Type Type { get; set;}
        public string? Icon { get; set;}

    }
}
