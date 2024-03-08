namespace Yummy.Models.Repositories
{
    public class WhyChooseYumRepository:IRepository<WhyChooseYum>
    {
        public WhyChooseYumRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, WhyChooseYum entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(WhyChooseYum entity)
        {
            Db.WhyChooseYum.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, WhyChooseYum entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public WhyChooseYum Find(int id)
        {
            return Db.WhyChooseYum.Find(id);
        }

        public void Update(int id, WhyChooseYum entity)
        {
            Db.WhyChooseYum.Update(entity);
            Db.SaveChanges();
        }

        public IList<WhyChooseYum> View()
        {
            return Db.WhyChooseYum.Where(x => x.IsDelete == false).ToList();
        }

        public IList<WhyChooseYum> ViewFormClient()
        {
            return Db.WhyChooseYum.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
