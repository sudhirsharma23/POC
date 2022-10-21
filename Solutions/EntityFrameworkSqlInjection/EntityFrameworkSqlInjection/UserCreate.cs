using System.Data.SqlClient;

namespace EntityFrameworkSqlInjection
{
    public class UserCreate
    {
        private readonly SqlInjectionDemoEntities _userContext;

        public UserCreate(SqlInjectionDemoEntities userContext)
        {
            _userContext = userContext;
        }

        public void Create(User user)
        {
            var query = "INSERT Users (FirstName, LastName, Email)" +
                    " VALUES (@firstname, @lastname, @email)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@firstname", user.FirstName),
                new SqlParameter("@lastname", user.LastName),
                new SqlParameter("@email", user.Email)
            };

            _ = _userContext.Database.ExecuteSqlCommand(query, parameters);
        }
    }
}
