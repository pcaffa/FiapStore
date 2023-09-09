namespace FiapStore.Entity
{
    public class Order : BaseEntity
    {
        public string ProductName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
