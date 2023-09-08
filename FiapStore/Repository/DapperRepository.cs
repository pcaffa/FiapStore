using FiapStore.Entity;
using FiapStore.Interface;

namespace FiapStore.Repository
{
    public abstract class DapperRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;
        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }

        public abstract void Delete(int id);

        public abstract T GetById(int id);

        public abstract void Insert(T user);

        public abstract IList<T> ListAll();

        public abstract void Update(T user);
       
    }
}
