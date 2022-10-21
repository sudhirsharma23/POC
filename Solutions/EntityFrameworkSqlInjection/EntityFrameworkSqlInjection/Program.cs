using Newtonsoft.Json;
using System;

namespace EntityFrameworkSqlInjection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments supplied. Below are valid arguments:\r\n/r : Recreate User table\r\n/1 : Get with LINQ method\r\n/2 : Get with LINQ syntax\r\n" +
                    "/3: Get with inline Stored Procedure\r\n/4: Get with Stored Procedure\r\n/5: Get with inline composite string\r\n" +
                    "/6: Get with parameterized query\r\n/7: Get with inline concatenated strings\r\n/8: Get with string interpolation");
                return;
            }

            if (args[0] != "/r" && args.Length < 3)
            {
                Console.WriteLine("Missing first name and last name parameters: e.g. /1 \"John\" \"Smith\"");
                return;
            }

            var context = new SqlInjectionDemoEntities();
            var provider = new UserFetch(context);
            var user = new User();
            Console.WriteLine("Users table before call:\r\n{0}\r\n", JsonConvert.SerializeObject(context.Users));

            switch (args[0])
            {
                case "/r":  // recreate Users table
                    var userCreate = new UserCreate(context);
                    userCreate.Create(new User
                    {
                        FirstName = "Dennis",
                        LastName = "Miranda",
                        Email = "dmiranda@firstam.com"
                    });
                    userCreate.Create(new User
                    {
                        FirstName = "Gary",
                        LastName = "Knutson",
                        Email = "gknutson@firstam.com"
                    }); userCreate.Create(new User
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Email = "jsmith@firstam.com"
                    });
                    break;
                // Test each method below for SQL injection
                case "/1":
                    user = provider.GetWithLinqMethod(args[1], args[2]);
                    break;
                case "/2":
                    user = provider.GetWithLinqSyntax(args[1], args[2]);
                    break;
                case "/3":
                    user = provider.GetWithInlineSP(args[1], args[2]);
                    break;
                case "/4":
                    user = provider.GetWithSPMethod(args[1], args[2]);
                    break;
                case "/5":
                    user = provider.GetWithInlineComposite(args[1], args[2]);
                    break;
                case "/6":
                    user = provider.GetWithParameterized(args[1], args[2]);
                    break;
                case "/7":
                    user = provider.GetWithInlineConcat(args[1], args[2]);
                    break;
                case "/8":
                    user = provider.GetWithInterpolation(args[1], args[2]);
                    break;
                default:
                    Console.WriteLine("Invalid argument");
                    break;
            }

            Console.WriteLine("Method call response:\r\n{0}\r\n", JsonConvert.SerializeObject(user));
            Console.WriteLine("Users table after call:\r\n{0}", JsonConvert.SerializeObject(context.Users));
        }
    }
}
