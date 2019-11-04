namespace SoftUni
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Data;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var selectedEmployees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in selectedEmployees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var resultArray = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var e in resultArray)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Employee targetEmployee = context.Employees.First(e => e.LastName == "Nakov");

            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            targetEmployee.Address = newAddress;
            context.SaveChanges();

            var result = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var r in result)
            {
                sb.AppendLine(r);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var selectedEmployees = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    ProjectInfo = e.EmployeesProjects
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            ProjectStartDate = p.Project.StartDate,
                            ProjectEndDate = p.Project.EndDate
                        })
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var e in selectedEmployees)
            {
                sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                foreach (var p in e.ProjectInfo)
                {
                    var startDate = p.ProjectStartDate
                        .ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = p.ProjectEndDate == null
                        ? "not finished"
                        : p.ProjectEndDate.Value.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var selectedAddresses = context.Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var address in selectedAddresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    JobTitle = e.JobTitle,
                    ProjectsNames = e.EmployeesProjects
                        .Select(ep => new
                        {
                            Name = ep.Project.Name
                        })
                        .OrderBy(ep => ep.Name)
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeName} - {employee.JobTitle}");

                foreach (var project in employee.ProjectsNames)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            FullName = e.FirstName + " " + e.LastName,
                            JobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var project in projects)
            {
                var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(startDate);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToArray();

            List<Employee> updatedEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12M;
                context.SaveChanges();
                updatedEmployees.Add(employee);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var employee in updatedEmployees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    FullName = e.FirstName + " " + e.LastName,
                    Salary = e.Salary,
                    JobTitle = e.JobTitle
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProjectToDelete = context.EmployeesProjects.Where(e => e.ProjectId == 2).ToArray();

            foreach (var projectToDeleteFromTable in employeeProjectToDelete)
            {
                context.Remove(projectToDeleteFromTable);
            }

            var projectToDelete = context.Projects.Find(2);
            context.Remove(projectToDelete);

            context.SaveChanges();

            var selectedProjects = context.Projects
                .Select(e => new
                {
                    Name = e.Name
                })
                .Take(10);

            StringBuilder sb = new StringBuilder();
            foreach (var project in selectedProjects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            const string townName = "Seattle";

            var employeeAddressesToSetToNull = context.Employees
                .Where(a => a.Address.Town.Name == townName)
                .ToArray();

            foreach (var employeeAddress in employeeAddressesToSetToNull)
            {
                employeeAddress.AddressId = null;
            }

            var addressesToDelete = context.Addresses
                .Where(e => e.Town.Name == townName)
                .ToArray();

            int countOfDeletedAddresses = 0;

            foreach (var address in addressesToDelete)
            {
                context.Remove(address);
                countOfDeletedAddresses++;
            }

            var townObject = context.Towns
                .First(t => t.Name == townName);

            context.Remove(townObject);

            context.SaveChanges();

            return $"{countOfDeletedAddresses} addresses in Seattle were deleted";
        }
    }
}
