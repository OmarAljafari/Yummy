namespace Yummy.Models.Repositories
{
    public class ChefRepository:IRepository<Chef>
    {
        public ChefRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, Chef entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Chef entity)
        {
            Db.Chef.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Chef entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Chef Find(int id)
        {
            return Db.Chef.Find(id);
        }

        public void Update(int id, Chef entity)
        {
            Db.Chef.Update(entity);
            Db.SaveChanges();
        }

        public IList<Chef> View()
        {
            return Db.Chef.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Chef> ViewFormClient()
        {
            return Db.Chef.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
