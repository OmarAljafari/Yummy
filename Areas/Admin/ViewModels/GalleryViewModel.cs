using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class GalleryViewModel:BaseModelVM
    {
        
        [Display(Name = "Image")]
        public string GalleryImage { get; set; }
        [Display(Name = "File")]

        public IFormFile? File { get; set; }
    }
}
