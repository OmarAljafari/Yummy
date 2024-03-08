using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class WhyChooseYum:BaseEntity
    {
        public int WhyChooseYumId { get; set; }
        [Display(Name ="Title")]
        public string WhyChooseYumTitle { get; set; }
        [Display(Name = "Description")]

        public string WhyChooseYumDescription { get; set; }
        [Display(Name ="Link")]

        public string WhyChooseYumLink { get; set; }

    }
}
