namespace Yummy.Models.Repositories
{
    public class SystemSettingRepository:IRepository<SystemSetting>
    {
        public SystemSettingRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, SystemSetting entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(SystemSetting entity)
        {
            Db.SystemSetting.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, SystemSetting entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public SystemSetting Find(int id)
        {
            return Db.SystemSetting.Find(id);
        }

        public void Update(int id, SystemSetting entity)
        {
            Db.SystemSetting.Update(entity);
            Db.SaveChanges();
        }

        public IList<SystemSetting> View()
        {
            return Db.SystemSetting.Where(x => x.IsDelete == false).ToList();
        }

        public IList<SystemSetting> ViewFormClient()
        {
            return Db.SystemSetting.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
