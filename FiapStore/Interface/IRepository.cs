namespace FiapStore.Interface
{
    public interface IRepository<T> where T : class
    {
        IList<T> ListAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
