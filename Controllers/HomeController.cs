using Microsoft.AspNetCore.Mvc;
using Yummy.Models;
using Yummy.Models.Repositories;
using Yummy.ViewModels;

namespace Yummy.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<FrontOfPage> frontOfPage,IRepository<AboutUs> aboutUs,IRepository<WhyChooseYum> whyChooseYum,IRepository<AdvantagesOfYum> advantagessOfYum,IRepository<Statistics> statistics,IRepository<SystemSetting> systemSetting,IRepository<CategoryMenu> categoryMenu,IRepository<ItemMenu> itemMenu,IRepository<WhatPeopleSay> whatPeopleSay,IRepository<Moment> moment,IRepository<Chef> chef,IRepository<SocialMedia> socialMedia,IRepository<TransactionBook> transactionBook,IRepository<Gallery> gallery,IRepository<MainMenu> mainMenu,IRepository<Information> information,IRepository<TransactionContactUs> transactionContactUs)
        {
            _FrontOfPage = frontOfPage;
            _AboutUs = aboutUs;
            _WhyChooseYum = whyChooseYum;
            _AdvantagessOfYum = advantagessOfYum;
            _Statistics = statistics;
            _SystemSetting = systemSetting;
            _CategoryMenu = categoryMenu;
            _ItemMenu = itemMenu;
            _WhatPeopleSay = whatPeopleSay;
            _Moment = moment;
            _Chef = chef;
            _SocialMedia = socialMedia;
            _TransactionBook = transactionBook;
            _Gallery = gallery;
            _MainMenu = mainMenu;
            _Information = information;
            _TransactionContactUs = transactionContactUs;
        }

        public IRepository<FrontOfPage> _FrontOfPage { get; }
        public IRepository<AboutUs> _AboutUs { get; }
        public IRepository<WhyChooseYum> _WhyChooseYum { get; }
        public IRepository<AdvantagesOfYum> _AdvantagessOfYum { get; }
        public IRepository<Statistics> _Statistics { get; }
        public IRepository<SystemSetting> _SystemSetting { get; }
        public IRepository<CategoryMenu> _CategoryMenu { get; }
        public IRepository<ItemMenu> _ItemMenu { get; }
        public IRepository<WhatPeopleSay> _WhatPeopleSay { get; }
        public IRepository<Moment> _Moment { get; }
        public IRepository<Chef> _Chef { get; }
        public IRepository<SocialMedia> _SocialMedia { get; }
        public IRepository<TransactionBook> _TransactionBook { get; }
        public IRepository<Gallery> _Gallery { get; }
        public IRepository<MainMenu> _MainMenu { get; }
        public IRepository<Information> _Information { get; }
        public IRepository<TransactionContactUs> _TransactionContactUs { get; }

        public IActionResult Index()
        {
            var obj = new HomeViewModel
            {
                FrontOfPage = _FrontOfPage.ViewFormClient(),
                AboutUs = _AboutUs.ViewFormClient(),
                WhyChooseYum = _WhyChooseYum.ViewFormClient(),
                AdvantagesOfYum = _AdvantagessOfYum.ViewFormClient(),
                Statistics = _Statistics.ViewFormClient(),
                SystemSetting = _SystemSetting.Find(2),
                CategoryMenu = _CategoryMenu.ViewFormClient(),
                ItemMenu = _ItemMenu.ViewFormClient(),
                WhatPeopleSay = _WhatPeopleSay.ViewFormClient(),
                Moment = _Moment.ViewFormClient(),
                Chef = _Chef.ViewFormClient(),
                SocialMedia = _SocialMedia.ViewFormClient(),
                Gallery = _Gallery.ViewFormClient(),
                MainMenu = _MainMenu.ViewFormClient(),
                Information = _Information.ViewFormClient(),
               
            };
            return View(obj);
        }


        [HttpPost]
        public IActionResult TransactionBook(HomeViewModel collection)
        {
            var obj = new TransactionBook
            {
                TransactionBookDate =collection.TransactionBook.TransactionBookDate,
                TransactionBookEmail =collection.TransactionBook.TransactionBookEmail,
                TransactionBookMessage =collection.TransactionBook.TransactionBookMessage,
                TransactionBookName =collection.TransactionBook.TransactionBookName,
                TransactionBookPhone =collection.TransactionBook.TransactionBookPhone,
                TransactionBookTime =collection.TransactionBook.TransactionBookTime,
                TransactionBookNumberOfPeople = collection.TransactionBook.TransactionBookNumberOfPeople,
            };
            _TransactionBook.Add(obj);
            TempData["message"] = "Your booking request was sent. We will call back or send an Email to confirm your reservation. Thank you!";
            return RedirectToAction("Index");
            //omar changes
        }

        [HttpPost]
        public IActionResult TransactionContactUs(HomeViewModel collection)
        {
            var obj = new TransactionContactUs
            {
                TransactionContactUsEmail = collection.TransactionContactUs.TransactionContactUsEmail,
                TransactionContactUsMessage = collection.TransactionContactUs.TransactionContactUsMessage,
                TransactionContactUsName = collection.TransactionContactUs.TransactionContactUsName,
                TransactionContactUsSubject = collection.TransactionContactUs.TransactionContactUsSubject
            };
            _TransactionContactUs.Add(obj);
            TempData["message"] = "Your message has been sent. Thank you!";
            return RedirectToAction(nameof(Index));
        }
    }
}
