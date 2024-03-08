using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Yummy.Areas.Admin.ViewModels
{
    public class Register
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirem Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The password is not matched")]
        public string ConfiremPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }
        public string? EditUser { get; set; }
        public DateTime? EditDate { get; set; }

    }
}
