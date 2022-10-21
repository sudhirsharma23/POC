This console application requires arguments.

Below are valid arguments:
/r : Recreate User table
/1 : Get with LINQ method
/2 : Get with LINQ syntax
/3 : Get with inline Stored Procedure
/4 : Get with Stored Procedure
/5 : Get with inline composite string
/6 : Get with parameterized query
/7 : Get with inline concatenated strings
/8 : Get with string interpolation

For arguments /1 through /8 above, 2 additional arguments for First Name and Last Name are required
	For example, to invoke the "Get with LINQ method", enter the arguments as below:
		/1 "John" "Smith"

If running from a command prompt, include the executable file as in the example below:
	EntityFrameworkSqlInjection.exe /1 "John" "Smith"

To test a method for SQL Injection vulnerability, you can try a combination of arguments as in the example below:
	/7 "John'; truncate table Users; --" "Smith"
