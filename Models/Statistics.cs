using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Statistics:BaseEntity
    {
        public int StatisticsId { get; set; }
        [Display(Name ="Name")]
        public string StatisticsName { get; set;}
        [Display(Name = "Number")]

        public int StatisticsNumber { get; set; }
    }
}
