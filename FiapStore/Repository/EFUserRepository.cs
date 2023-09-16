using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FiapStore.Repository
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User GetUserByOrdes(int id)
        {
            return _context.User.Include(u => u.OrderList)
                    .Where(u => u.Id == id)
                    .ToList()
                    .Select(u =>
                    {
                        u.OrderList = u.OrderList.Select(o => new Order(o)).ToList();
                        return u;
                    }).FirstOrDefault();
        }

        public User GetByUserNamePassword(string userName, string password)
        {
            return _context.User.FirstOrDefault(u => u.UserName == userName && u.Passaword == password);

        }
    }
}
