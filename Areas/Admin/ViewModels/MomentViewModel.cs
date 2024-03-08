using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class MomentViewModel:BaseModelVM
    {
        [Display(Name = "Name")]
        [Required]
        public string MomentName { get; set; }
      
        [Display(Name = "Description")]
        [Required]
        public string MomentDescription { get; set; }
        [Display(Name = "Price")]
        [Required]
        public int MomentPrice { get; set; }
        [Display(Name = "Image")]

        public string MomentImage { get; set; }
        [Display(Name ="File")]
        public IFormFile? File { get; set; }
    }
}
