using FiapStore.DTO;

namespace FiapStore.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> OrderList { get; set; }

        public User() { }

        public User(UpdateUserDTO updateUserDTO)
        {
            Id = updateUserDTO.Id;
            Name = updateUserDTO.Name;
        }
        public User(InsertUserDTO insertUserDTO) 
        {
            Name = insertUserDTO.Name;
        }


    }
}
