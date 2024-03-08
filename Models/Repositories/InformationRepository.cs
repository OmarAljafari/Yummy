namespace Yummy.Models.Repositories
{
    public class InformationRepository:IRepository<Information>
    {
        public InformationRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, Information entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Information entity)
        {
            Db.Information.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Information entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Information Find(int id)
        {
            return Db.Information.Find(id);
        }

        public void Update(int id, Information entity)
        {
            Db.Information.Update(entity);
            Db.SaveChanges();
        }

        public IList<Information> View()
        {
            return Db.Information.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Information> ViewFormClient()
        {
            return Db.Information.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
