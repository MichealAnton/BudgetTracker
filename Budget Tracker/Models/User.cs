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
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string User_Name { get; set;}
        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string User_Email { get; set;}
        [Required(ErrorMessage = "Please enter a password.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?/\\~-]).{6,}$",
        ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special Char, and be at least 6 characters long.")]
        [DataType(DataType.Password)]
        public string User_Passowrd { get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("User_Passowrd", ErrorMessage = "not match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Image")]
        [DefaultValue("ProfilePicture.jpeg")]
        public string User_Pic { get; set; }

    }
}
