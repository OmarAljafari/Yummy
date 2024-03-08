using System.ComponentModel.DataAnnotations;
using Yummy.Models;

namespace Yummy.Areas.Admin.ViewModels
{
    public class ItemMenuViewModel:BaseModelVM
    {
        [Display(Name = "Name")]
        [Required]
        public string ItemMenuName { get; set; }
        [Display(Name = "Breef")]
        [Required]
        public string ItemMenuBreef { get; set; }
        [Display(Name = "Price")]
        [Required]
        public double ItemMenuPrice { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string ItemMenuImage { get; set; }
        [Display(Name = "File")]
        public IFormFile? File { get; set; }
        [Display(Name = "Category")]
        [Required]
        public int CategoryMenuId { get; set; }
        public CategoryMenu? CategoryMenu { get; set; }
    }
}
