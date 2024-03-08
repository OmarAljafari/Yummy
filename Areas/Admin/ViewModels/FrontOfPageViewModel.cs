using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class FrontOfPageViewModel:BaseModelVM
    {
        [Required]
        [Display(Name ="Title")]
        public string FrontOfPageTitle { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string FrontOfPageDescription { get; set; }
        [Required]
        [Display(Name = "Link1")]
        public string FrontOfPageLink1 { get; set; }
        [Required]
        [Display(Name = "Link2")]
        public string FrontOfPageLink2 { get; set; }
        [Display(Name = "Image")]
        public string FrontOfPageImage { get; set; }
        [Display(Name = "File")]
        public IFormFile? File { get; set; }
    }
}
