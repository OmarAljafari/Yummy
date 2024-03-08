using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class FrontOfPage:BaseEntity
    {
        public int FrontOfPageId { get; set; }
        [Display(Name = "Title")]
        public string FrontOfPageTitle { get; set; }
        [Display(Name = "Description")]
        public string FrontOfPageDescription { get; set; }
        [Display(Name = "Link1")]
        public string FrontOfPageLink1 { get; set; }
        [Display(Name = "Link2")]
        public string FrontOfPageLink2 { get; set; }
        [Display(Name = "Image")]
        public string FrontOfPageImage { get; set; }


    }
}
