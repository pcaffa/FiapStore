using FiapStore.DTO;
using FiapStore.Enums;

namespace FiapStore.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Passaword { get; set; }
        public PermissionType Permission{ get; set; }  

        public ICollection<Order> OrderList { get; set; }

        public User() { }

        
        public User(InsertUserDTO insertUserDTO) 
        {
            Name = insertUserDTO.Name;
            UserName = insertUserDTO.UserName;
            Passaword = insertUserDTO.Passaword;
            Permission = insertUserDTO.Permission;
        }

        public User(UpdateUserDTO updateUserDTO)
        {
            Id = updateUserDTO.Id;
            Name = updateUserDTO.Name;
        }


    }
}
