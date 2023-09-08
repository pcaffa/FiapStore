namespace FiapStore.Interface
{
    public interface IRepository<T> where T : class
    {
        IList<T> ListAll();
        T GetById(int id);
        void Insert(T user);
        void Update(T user);
        void Delete(int id);
    }
}
