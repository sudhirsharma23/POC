using System.Data.SqlClient;
using System.Linq;

namespace EntityFrameworkSqlInjection
{
    internal class UserFetch
    {
        private readonly SqlInjectionDemoEntities _userContext;

        public UserFetch(SqlInjectionDemoEntities userContext)
        {
            _userContext = userContext;
        }

        public User GetWithLinqMethod(string firstName, string lastName)
        {
            return _userContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public User GetWithLinqSyntax(string firstName, string lastName)
        {
            IQueryable<User> query = from user in _userContext.Users
                                     where user.FirstName == firstName && user.LastName == lastName
                                     select user;

            return query.FirstOrDefault();
        }

        public User GetWithSPMethod(string firstName, string lastName)
        {
            return _userContext.spGetUserByName(firstName, lastName).FirstOrDefault();
        }

        public User GetWithInlineSP(string firstName, string lastName)
        {
            return _userContext.Users.SqlQuery("EXEC dbo.spGetUserByName {0},{1}", firstName, lastName).FirstOrDefault();
        }

        public User GetWithInlineComposite(string firstName, string lastName)
        {
            return _userContext.Users.SqlQuery("Select * from Users where FirstName = {0} and LastName = {1}", firstName, lastName).FirstOrDefault();
        }

        // Vulnerable to SQL Injection: Never combine user input with Entity SQL command text
        public User GetWithInlineConcat(string firstName, string lastName)
        {
            return _userContext.Users.SqlQuery("Select * from Users where FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
        }

        // Vulnerable to SQL Injection: Do not use string interpolation as shown below
        public User GetWithInterpolation(string firstName, string lastName)
        {
            _userContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);  // exposes generated SQL statement
            firstName = Encode(firstName);
            lastName = Encode(lastName);

            var query = $"Select * from Users where FirstName = '{firstName}' and LastName = '{lastName}'";

            return _userContext.Users.SqlQuery(query).FirstOrDefault();
        }

        public User GetWithParameterized(string firstName, string lastName)
        {
            _userContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);  // exposes generated SQL statement
            var query = $"Select * from Users where FirstName = @firstName and LastName = @lastName";
            var parameters = new SqlParameter[] {
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName)
            };

            return _userContext.Users.SqlQuery(query, parameters).FirstOrDefault();
        }

        public bool IsLocked(string firstName, string lastName)
        {
            using (var ctx = new SqlInjectionDemoEntities())
            {
                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);  // exposes generated SQL statement
                User titlePortLookup = ctx.Users.Where(row => row.FirstName == firstName && row.LastName == lastName).FirstOrDefault();

                if (titlePortLookup != null)
                {
                    return lastName == titlePortLookup.LastName;
                }
            }
            return false;
        }

        private string Encode(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? input : System.Net.WebUtility.HtmlEncode(input);
        }
    }
}
