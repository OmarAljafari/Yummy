namespace Yummy.Models.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T entity);  
        public void Update(int id,T entity);
        public void Delete(int id,T entity);
        public T Find(int id);
        public IList<T> View();
        public IList<T> ViewFormClient();
        public void Active (int id,T entity);
    }
}
