namespace Yummy.Models.Repositories
{
    public class FrontOfPageRepository:IRepository<FrontOfPage>
    {
        public FrontOfPageRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, FrontOfPage entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(FrontOfPage entity)
        {
            Db.FrontOfPage.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, FrontOfPage entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public FrontOfPage Find(int id)
        {
            return Db.FrontOfPage.Find(id);
        }

        public void Update(int id, FrontOfPage entity)
        {
            Db.FrontOfPage.Update(entity);
            Db.SaveChanges();
        }

        public IList<FrontOfPage> View()
        {
            return Db.FrontOfPage.Where(x => x.IsDelete == false).ToList();
        }

        public IList<FrontOfPage> ViewFormClient()
        {
            return Db.FrontOfPage.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
