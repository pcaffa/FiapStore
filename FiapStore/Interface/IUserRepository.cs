using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUserRepository
    {
        IList<User> ListUser();
        User GetUser(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
