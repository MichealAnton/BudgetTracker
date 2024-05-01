using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class Account
    {
        [Key]
        public int Account_Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s_]{3,}$", ErrorMessage = "please enter at least 3 letters")]
        public string Account_Name { get; set; }
        public string? Account_Notes { get; set;}
        [Required]
        [RegularExpression(@"^(?=.*[1-9])\d*\.?\d+$", ErrorMessage = "please enter at least one digit")]
        public double Initial_Budget { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
    }
}
