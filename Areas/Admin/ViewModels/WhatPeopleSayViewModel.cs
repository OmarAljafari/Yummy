using System.ComponentModel.DataAnnotations;

namespace Yummy.Areas.Admin.ViewModels
{
    public class WhatPeopleSayViewModel:BaseModelVM
    {
        [Display(Name = "Name")]
        public string WhatPeopleSayName { get; set; }
        [Display(Name = "Description")]

        public string WhatPeopleSayDescription { get; set; }
        [Display(Name = "Image")]

        public string WhatPeopleSayImage { get; set; }
        [Display(Name = "Job")]

        public string WhatPeopleSayJob { get; set; }
        [Display(Name = "Icon Start")]

        public string WhatPeopleSayIconStartOfDesc { get; set; }
        [Display(Name = "Icon End")]

        public string WhatPeopleSayIconEndOfDesc { get; set; }
        [Display(Name = "Icon Rate")]

        public string WhatPeopleSayIconRate { get; set; }
        
        [Display(Name = "File")]

        public IFormFile? File { get; set; }
    }
}
