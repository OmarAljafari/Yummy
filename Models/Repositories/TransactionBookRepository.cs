namespace Yummy.Models.Repositories
{
    public class TransactionBookRepository:IRepository<TransactionBook>
    {
        public TransactionBookRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int id, TransactionBook entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionBook entity)
        {
            Db.TransactionBook.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionBook entity)
        {
            throw new NotImplementedException();
        }

        public TransactionBook Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TransactionBook entity)
        {
            throw new NotImplementedException();
        }

        public IList<TransactionBook> View()
        {
            return Db.TransactionBook.ToList();
        }

        public IList<TransactionBook> ViewFormClient()
        {
            throw new NotImplementedException();
        }
    }
}
