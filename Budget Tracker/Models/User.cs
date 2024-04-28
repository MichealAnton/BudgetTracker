using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }
        [Required]
        public string User_Name { get; set;}
        [Required]
        public string User_Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string User_Passowrd { get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("User_Passowrd", ErrorMessage = "not match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Image")]
        [DefaultValue("E:\\Budget Tracker\\Budget Tracker\\wwwroot\\images\\ProfilePicture.jpeg")]
        public string User_Pic { get; set; }

    }
}
