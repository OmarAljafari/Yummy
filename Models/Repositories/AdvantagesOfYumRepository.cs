namespace Yummy.Models.Repositories
{
    public class AdvantagesOfYumRepository:IRepository<AdvantagesOfYum>
    {
        public AdvantagesOfYumRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, AdvantagesOfYum entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(AdvantagesOfYum entity)
        {
            Db.AdvantagesOfYum.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, AdvantagesOfYum entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public AdvantagesOfYum Find(int id)
        {
            return Db.AdvantagesOfYum.Find(id);
        }

        public void Update(int id, AdvantagesOfYum entity)
        {
            Db.AdvantagesOfYum.Update(entity);
            Db.SaveChanges();
        }

        public IList<AdvantagesOfYum> View()
        {
            return Db.AdvantagesOfYum.Where(x => x.IsDelete == false).ToList();
        }

        public IList<AdvantagesOfYum> ViewFormClient()
        {
            return Db.AdvantagesOfYum.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
