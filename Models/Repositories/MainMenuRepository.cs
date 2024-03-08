namespace Yummy.Models.Repositories
{
    public class MainMenuRepository:IRepository<MainMenu>
    {
        public MainMenuRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, MainMenu entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MainMenu entity)
        {
            Db.MainMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MainMenu entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MainMenu Find(int id)
        {
            return Db.MainMenu.Find(id);
        }

        public void Update(int id, MainMenu entity)
        {
            Db.MainMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MainMenu> View()
        {
            return Db.MainMenu.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MainMenu> ViewFormClient()
        {
            return Db.MainMenu.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
