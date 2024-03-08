using Microsoft.EntityFrameworkCore;

namespace Yummy.Models.Repositories
{
    public class ItemMenuRepository:IRepository<ItemMenu>
    {
        public ItemMenuRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, ItemMenu entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(ItemMenu entity)
        {
            Db.ItemMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, ItemMenu entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public ItemMenu Find(int id)
        {
            return Db.ItemMenu.Include(x => x.CategoryMenu).SingleOrDefault(x => x.ItemMenuId == id);
        }

        public void Update(int id, ItemMenu entity)
        {
            Db.ItemMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<ItemMenu> View()
        {
            return Db.ItemMenu.Include(x => x.CategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public IList<ItemMenu> ViewFormClient()
        {
            return Db.ItemMenu.Include(x => x.CategoryMenu).Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
