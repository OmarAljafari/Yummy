using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class MainMenu:BaseEntity
    {
        public int MainMenuId { get; set; }
        [Display(Name = "Icon URL")]
        public string MainMenuIconUrl { get; set; }

    }
}
