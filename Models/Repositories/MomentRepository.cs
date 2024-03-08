namespace Yummy.Models.Repositories
{
    public class MomentRepository:IRepository<Moment>
    {
        public MomentRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, Moment entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Moment entity)
        {
            Db.Moment.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Moment entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Moment Find(int id)
        {
            return Db.Moment.Find(id);
        }

        public void Update(int id, Moment entity)
        {
            Db.Moment.Update(entity);
            Db.SaveChanges();
        }

        public IList<Moment> View()
        {
            return Db.Moment.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Moment> ViewFormClient()
        {
            return Db.Moment.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
