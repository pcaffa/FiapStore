using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByOrdes(int id);
    }
}
