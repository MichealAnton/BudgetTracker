using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int Transaction_Id { get; set; }
        [Required]
        public string Transaction_Value { get; set;}
        [Required]
        public DateTime Date { get; set;}= DateTime.Now;
        public string? Transaction_Notes { get; set;}
        public int Account_Id { get; set; }
        [ForeignKey("Account_Id")]
        public virtual Account Account { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }


    }
}
