namespace Yummy.Models.Repositories
{
    public class SocialMediaRepository:IRepository<SocialMedia>
    {
        public SocialMediaRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, SocialMedia entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(SocialMedia entity)
        {
            Db.SocialMedia.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, SocialMedia entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public SocialMedia Find(int id)
        {
            return Db.SocialMedia.Find(id);
        }

        public void Update(int id, SocialMedia entity)
        {
            Db.SocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public IList<SocialMedia> View()
        {
            return Db.SocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public IList<SocialMedia> ViewFormClient()
        {
            return Db.SocialMedia.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
