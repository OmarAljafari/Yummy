
using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class AdvantagesOfYum:BaseEntity
    {
        public int AdvantagesOfYumId { get; set; }
        [Display(Name ="Icon")]
        public string AdvantagesOfYumIcon { get; set; }
        [Display(Name = "Breef")]

        public string AdvantagesOfYumBreef { get; set; }
        [Display(Name = "Description")]

        public string AdvantagesOfYumDescription { get; set; }
    }
}
