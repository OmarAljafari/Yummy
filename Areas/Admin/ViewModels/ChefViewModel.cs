using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class ChefViewModel:BaseModelVM
    {
        [Required]
        [Display(Name ="Name")]
        public string ChefName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string ChefDescription { get; set; }
        [Required]
        [Display(Name = "Job")]
        public string ChefJob { get; set; }
        [Display(Name = "Image")]
        public string ChefImage { get; set; }
       
        [Display(Name ="File")]
        public IFormFile? File { get; set; }
    }
}
