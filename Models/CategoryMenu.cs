using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Yummy.Models
{
    public class CategoryMenu:BaseEntity
    {
        public int CategoryMenuId { get; set; }
        [Display(Name ="Category")]
        public string CategoryMenuName { get; set;}
      
    }
}
