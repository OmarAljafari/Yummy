using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class ItemMenu:BaseEntity
    {
        public int ItemMenuId { get; set; }
        [Display(Name = "Name")]
        public string ItemMenuName { get; set;}
        [Display(Name = "Breef")]
        public string ItemMenuBreef { get; set;}
        [Display(Name = "Price")]
        public double ItemMenuPrice { get; set; }
        [Display(Name = "Image")]
        public string ItemMenuImage { get; set; }
        [Display(Name ="Category")]
        public int CategoryMenuId { get; set; }
        public CategoryMenu? CategoryMenu { get; set; }
    }
}
