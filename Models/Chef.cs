using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Chef:BaseEntity
    {
        public int ChefId { get; set; }
        [Display(Name ="Name")]
        public string ChefName { get; set; }
        [Display(Name = "Description")]

        public string ChefDescription { get; set; }
        [Display(Name = "Job")]

        public string ChefJob { get; set; }
        [Display(Name = "Image")]

        public string ChefImage { get; set; }
       
    }
}
