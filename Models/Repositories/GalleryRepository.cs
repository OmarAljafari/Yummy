namespace Yummy.Models.Repositories
{
    public class GalleryRepository:IRepository<Gallery>
    {
        public GalleryRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, Gallery entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Gallery entity)
        {
            Db.Gallery.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Gallery entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Gallery Find(int id)
        {
            return Db.Gallery.Find(id);
        }

        public void Update(int id, Gallery entity)
        {
            Db.Gallery.Update(entity);
            Db.SaveChanges();
        }

        public IList<Gallery> View()
        {
            return Db.Gallery.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Gallery> ViewFormClient()
        {
            return Db.Gallery.Where(x => x.IsDelete == false && x.IsActive).ToList();
        }
    }
}
