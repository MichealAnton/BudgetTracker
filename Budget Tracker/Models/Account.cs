using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class Account
    {
        [Key]
        public int Account_Id { get; set; }
        [Required]
        public string Account_Name { get; set; }
        public string? Account_Notes { get; set;}
        [Required]
        public double Initial_Budget { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
    }
}
