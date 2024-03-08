namespace Yummy.Models.Repositories
{
    public class AboutUsRepository : IRepository<AboutUs>
    {
        public AboutUsRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, AboutUs entity)
        {
            var data = Find(id);
            data.IsActive = ! data.IsActive;
            data.EditDate = entity.EditDate;    
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(AboutUs entity)
        {
            Db.AboutUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, AboutUs entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public AboutUs Find(int id)
        {
            return Db.AboutUs.Find(id);
        }

        public void Update(int id, AboutUs entity)
        {
            Db.AboutUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<AboutUs> View()
        {
            return Db.AboutUs.Where(x => x.IsDelete == false).ToList();
        }

        public IList<AboutUs> ViewFormClient()
        {
            return Db.AboutUs.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
