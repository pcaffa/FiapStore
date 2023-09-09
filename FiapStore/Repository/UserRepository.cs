using Dapper;
using FiapStore.Entity;
using FiapStore.Interface;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class UserRepository : DapperRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Delete(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM [User] WHERE Id = @Id";
            dbconnection.Execute(query, new { Id = id});
        }

        public override User GetById(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [User]  WHERE Id = @Id";
            return dbconnection.Query<User>(query, new { Id = id }).FirstOrDefault();
        }

        public override void Insert(User user)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO [User] (Name) VALUES (@Name)";
            dbconnection.Query(query, user);
        }

        public override IList<User> ListAll()
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [User]";
            return dbconnection.Query<User>(query).ToList();
        }

        public override void Update(User user)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "UPDATE [User] SET Name = @Name WHERE Id = @Id";
            dbconnection.Query(query, user);
        }

        public User GetUserByOrdes(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT " +
                            "U.Id, " +
	                        "U.Name, " + 
	                        "O.Id, " +
	                        "O.ProductName, " +
	                        "O.UserId " +
                            "FROM[User] U " +
                        "LEFT JOIN[Order] O " +
                            "ON U.Id = O.UserId " +
                        "WHERE U.Id = @Id";

           var result = new Dictionary<int, User>();
            var parameters = new { Id = id };

            dbconnection.Query<User, Order, User>(query,
                (user, order) =>
                {
                    if (!result.TryGetValue(user.Id, out var userExist))
                    {
                        userExist = user;
                        userExist.OrderList = new List<Order>();
                        result.Add(user.Id, userExist);
                    }

                    if (order != null)
                        userExist.OrderList.Add(order);

                    return userExist;
                }, parameters, splitOn: "Id");

            return result.Values.FirstOrDefault();
        }
    }
}
