using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class SocialMedia:BaseEntity
    {
        public int SocialMediaId { get; set; }
        [Display(Name ="Link")]
        public string SocialMediaLink { get; set; }
        [Display(Name = "Redirect")]

        public string SocialMediaRedirect { get; set; }
        [Display(Name = "Icon")]

        public string SocialMediaIcon { get; set; }
    }
}
