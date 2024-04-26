using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Budget_Tracker.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        [Required]
        public string User_Name { get; set;}
        [Required]
        public string User_Email { get; set;}
        [Required]
        public string User_Passowrd { get;set;}
        [Display(Name = "Image")]
        [DefaultValue("E:\\Budget Tracker\\Budget Tracker\\wwwroot\\images\\ProfilePicture.jpeg")]
        public string User_Pic { get; set; }

    }
}
