using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Information:BaseEntity
    {
        public int InformationId { get; set; }
        [Display(Name ="Name")]
        public string InformationName { get; set;}
        [Display(Name = "Description")]

        public string InformationDescription { get; set;}
        [Display(Name = "Redirect")]

        public string InformationRedirect { get; set; }
        [Display(Name = "Icon")]

        public string InformationIcon { get; set; }
    }
}
