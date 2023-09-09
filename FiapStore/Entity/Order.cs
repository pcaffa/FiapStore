namespace FiapStore.Entity
{
    public class Order : BaseEntity
    {
        public string ProductName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public Order() { }

        public Order(Order order) 
        {
            ProductName=order.ProductName;
            UserId=order.UserId;
            User = order.User;
        }


    }
}
