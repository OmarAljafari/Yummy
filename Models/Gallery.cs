using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Gallery:BaseEntity
    {
        public int GalleryId { get; set; }
        
        [Display(Name = "Image")]

        public string GalleryImage { get; set; }
    }
}
