namespace Yummy.Models.Repositories
{
    public class StatisticsRepository:IRepository<Statistics>
    {
        public StatisticsRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, Statistics entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Statistics entity)
        {
            Db.Statistics.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Statistics entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Statistics Find(int id)
        {
            return Db.Statistics.Find(id);
        }

        public void Update(int id, Statistics entity)
        {
            Db.Statistics.Update(entity);
            Db.SaveChanges();
        }

        public IList<Statistics> View()
        {
            return Db.Statistics.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Statistics> ViewFormClient()
        {
            return Db.Statistics.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
