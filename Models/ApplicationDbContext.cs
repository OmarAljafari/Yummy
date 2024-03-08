using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Yummy.Models
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<AboutUs> AboutUs { get; set; } 
        public DbSet<AdvantagesOfYum> AdvantagesOfYum { get; set; } = null!;
        public DbSet<CategoryMenu> CategoryMenu { get; set; } = null!;
        public DbSet<Chef> Chef { get; set; } = null!;
        public DbSet<FrontOfPage> FrontOfPage { get; set; } = null!;
        public DbSet<Gallery> Gallery { get; set; } = null!;
        public DbSet<Information> Information { get; set; } = null!;
        public DbSet<ItemMenu> ItemMenu { get; set; } = null!;
        public DbSet<MainMenu> MainMenu { get; set; } = null!;
        public DbSet<Moment> Moment { get; set; } = null!;
        public DbSet<SocialMedia> SocialMedia { get; set; } = null!;
        public DbSet<Statistics> Statistics { get; set; } = null!;
        public DbSet<SystemSetting> SystemSetting { get; set; } = null!;
        public DbSet<TransactionBook> TransactionBook { get; set; } = null!;
        public DbSet<TransactionContactUs> TransactionContactUs { get; set; } = null!;
        public DbSet<WhatPeopleSay> WhatPeopleSay { get; set; } = null!;
        public DbSet<WhyChooseYum> WhyChooseYum { get; set; } = null!;

    }
}
