namespace Yummy.Models.Repositories
{
    public class CategoryMenuRepository:IRepository<CategoryMenu>
    {
        public CategoryMenuRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, CategoryMenu entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(CategoryMenu entity)
        {
            Db.CategoryMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, CategoryMenu entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public CategoryMenu Find(int id)
        {
            return Db.CategoryMenu.Find(id);
        }

        public void Update(int id, CategoryMenu entity)
        {
            Db.CategoryMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<CategoryMenu> View()
        {
            return Db.CategoryMenu.Where(x => x.IsDelete == false).ToList();
        }

        public IList<CategoryMenu> ViewFormClient()
        {
            return Db.CategoryMenu.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}

