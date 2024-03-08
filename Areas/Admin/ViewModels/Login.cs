using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class Login
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
