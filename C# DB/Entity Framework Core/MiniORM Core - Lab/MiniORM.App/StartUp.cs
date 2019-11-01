namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=MiniORM;Integrated Security=true";
            
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employees
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
}
