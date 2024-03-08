using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class AboutUsViewModel:BaseModelVM
    {
        [Display(Name = "Image 1")]
        public string AboutUsImage1 { get; set; }
        [Display(Name = "Image 2")]
        public string AboutUsImage2 { get; set; }
        [Display(Name = "Paragraph 1 ")]
        public string AboutUsParagraph1 { get; set; }
        [Display(Name = "Paragraph 2 ")]
        public string AboutUsParagraph2 { get; set; }
        [Display(Name = "Point 1 ")]
        public string AboutUsPoint1 { get; set; }
        [Display(Name = "Point 2 ")]
        public string AboutUsPoint2 { get; set; }
        [Display(Name = "Point 3 ")]
        public string AboutUsPoint3 { get; set; }
        [Display(Name = "Link")]
        public string AboutUsLink { get; set; }
        [Display(Name = "Title")]
        public string AboutUsTitle { get; set; }
        [Display(Name = "Phone Note")]
        public string AboutUsPhoneNote { get; set; }
        [Display(Name ="File 1")]
        public IFormFile? File1 { get; set; }
        [Display(Name = "File 2")]
       
        public IFormFile? File2 { get; set; }

    }
}
