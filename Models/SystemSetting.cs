using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class SystemSetting:BaseEntity
    {
        public int SystemSettingId { get; set; }
        [Display(Name ="Logo")]
        public string SystemSettingLogo { get; set;}
        [Display(Name = "Image Book")]

        public string SystemSettingImageBook { get; set; }
        [Display(Name = "Image Statistics")]

        public string SystemSettingImageStatistics { get; set; }
        [Display(Name = "Title Book")]

        public string SystemSettingTitleBook { get; set; }
        [Display(Name = "Map")]

        public string SystemSettingMap { get; set; }
        [Display(Name = "Title Map")]

        public string SystemSettingTitleMap { get;set; }
        [Display(Name = "Copy Right")]

        public string SystemSettingCopyRight { get; set; }
        [Display(Name = "Title of chef")]

        public string ChefTitle { get; set; }
        [Display(Name = "Title of gallery")]
        public string GalleryTitle { get; set; }
        [Display(Name = "Title of moment")]

        public string MomentTitle { get; set; }
        [Display(Name = "Title of menu")]

        public string CategoryMenuTitle { get; set; }
        [Display(Name = "Title of What people Say")]

        public string WhatPeopleSayTitle { get; set; }
    }
}
