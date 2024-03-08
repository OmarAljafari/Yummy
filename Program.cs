using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Yummy.Models;
using Yummy.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
builder.Services.AddScoped<IRepository<TransactionBook>, TransactionBookRepository>();
builder.Services.AddScoped<IRepository<AboutUs>, AboutUsRepository>();
builder.Services.AddScoped<IRepository<AdvantagesOfYum>, AdvantagesOfYumRepository>();
builder.Services.AddScoped<IRepository<Chef>, ChefRepository>();
builder.Services.AddScoped<IRepository<CategoryMenu>, CategoryMenuRepository>();
builder.Services.AddScoped<IRepository<FrontOfPage>, FrontOfPageRepository>();
builder.Services.AddScoped<IRepository<Gallery>, GalleryRepository>();
builder.Services.AddScoped<IRepository<Information>, InformationRepository>();
builder.Services.AddScoped<IRepository<ItemMenu>, ItemMenuRepository>();
builder.Services.AddScoped<IRepository<MainMenu>, MainMenuRepository>();
builder.Services.AddScoped<IRepository<SocialMedia>, SocialMediaRepository>();
builder.Services.AddScoped<IRepository<Moment>, MomentRepository>();
builder.Services.AddScoped<IRepository<Statistics>, StatisticsRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<WhatPeopleSay>, WhatPeopleSayRepository>();
builder.Services.AddScoped<IRepository<WhyChooseYum>, WhyChooseYumRepository>();










builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Admin/Account/Login";
});




var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(Endpoint =>
{
    app.MapControllerRoute(
       name: "default1",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
       );
    app.MapControllerRoute(
        name:"default",
        pattern:"{controller=Home}/{action=Index}/{id?}"
        );
    
}

);


app.Run();
