namespace Yummy.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public TransactionContactUsRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionContactUs entity)
        {
            Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public TransactionContactUs Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public IList<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.ToList();
        }

        public IList<TransactionContactUs> ViewFormClient()
        {
            throw new NotImplementedException();
        }
    }
}
