using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace FiapStore.Repository
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public IList<T> ListAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
