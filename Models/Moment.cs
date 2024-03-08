using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Moment:BaseEntity
    {
        public int MomentId { get; set; }
        [Display(Name ="Name")]
        public string MomentName { get; set;}
        
        [Display(Name = "Description")]

        public string MomentDescription { get; set;}
        [Display(Name = "Price")]

        public int MomentPrice { get; set; }
        [Display(Name = "Image")]

        public string MomentImage { get; set; }

    }
}
