using FiapStore.Enums;

namespace FiapStore.DTO
{
    public class InsertUserDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Passaword { get; set; }
        public PermissionType Permission { get; set; }
    }
}
