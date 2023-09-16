using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByOrdes(int id);

        User GetByUserNamePassword(string userName, string password);
    }
}
