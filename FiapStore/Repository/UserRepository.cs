using FiapStore.Entity;
using FiapStore.Interface;

namespace FiapStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private IList<User> _users = new List<User>();

        public IList<User> ListUser()
        {
            return _users;
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public void InsertUser(User user)
        {
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var userUpdate = GetUser(user.Id);
            if (userUpdate != null)
                userUpdate.Name = user.Name;
        }

        public void DeleteUser(int id)
        {
            _users.Remove(GetUser(id));
        }
    }
}
