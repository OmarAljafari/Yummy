using Yummy.Models;

namespace Yummy.ViewModels
{
    public class HomeViewModel
    {
        public IList<FrontOfPage>  FrontOfPage { get; set; }
        public IList<AboutUs> AboutUs { get; set; }
        public IList<WhyChooseYum> WhyChooseYum { get; set; }
        public IList<AdvantagesOfYum> AdvantagesOfYum { get; set; }
        public IList<Statistics> Statistics { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public IList<CategoryMenu> CategoryMenu { get; set; }
        public IList<ItemMenu> ItemMenu { get; set; }
        public IList<WhatPeopleSay> WhatPeopleSay { get; set; }
        public IList<Moment> Moment { get; set; }
        public IList<Chef> Chef { get; set; }
        public IList<SocialMedia> SocialMedia { get; set; }
        public TransactionBook TransactionBook { get; set; }
        public IList<Gallery> Gallery { get; set; }
        public IList<MainMenu> MainMenu { get; set; }
        public IList<Information> Information { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }
    }
}
