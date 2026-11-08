using practice12.models;
using practice12.utis;
using System.Collections.Generic;
using static System.Console;

namespace practice12.Services;

public class ServicesListEmployee
{
    public List <Employee> Employees { get; set; } = new List <Employee>();

    public ServicesListEmployee(List<Employee> employees)
    {
        Employees = employees;
    }

    public void AddEmployee(Employee employee)
    {
        if (!Employees.Contains(employee))
        {
            Employees.Add(employee);
        }
    }

    public string RemoveEmployee(int id)
    {
        // return( Employees.Remove(employee)) ?$"{employee.FirstName} {employee.LastName} was removed" :
        //     $"Error: {employee.FirstName} {employee.LastName} was not found";
        if(id<0 || id>=Employees.Count)
        {
            return $"Error: {id} was not found";
        }
        // Employees.Remove(Employees[id]);
        Employees.RemoveAt(id);
        return $"Employee was successfully removed";
    }
    public void ShowEmployees()
    {
        int i = 1;
        foreach (Employee employee in Employees)
        {
            WriteLine($"\n{i++}. {employee}");
        }
    }

    public string EditEmployee(int id)
    {
        if (id < 0 || id >= Employees.Count)
        {
            return $"Error: was not found";
        }
        Employee employee = Employees[id];
        WriteLine("Enter First Name: ");
        string firstName = ReadLine() ?? "";
        WriteLine("Enter Last Name: ");
        string lastName = ReadLine() ?? "";
        WriteLine("Enter Position: ");
        string position = ReadLine() ?? "";
        WriteLine("Enter Salary: ");
        
        if (!int.TryParse(ReadLine(), out int salary))
        {
            return "Invalid salary";
        }
        
        WriteLine("Enter age: ");
        if (!int.TryParse(ReadLine(), out int age))
        {
            return "Invalid salary";
        }
        
        WriteLine("Enter email: ");
        string email = ReadLine() ?? "";
        Employees[id] = employee with { FirstName = firstName, LastName = lastName, Position = position, Salary = salary, Age = age, Email = email };
        return $"Employee was successfully updated";
    }

    public void SortByFirstName()
    {
        Employees.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
    }

    public void SortBySalary()
    {
        Employees.Sort((x, y) => y.Salary - x.Salary);
    }

    public void SortByAge()
    {
        Employees.Sort((x, y) => y.Age - x.Age);
    }

    public string SearchByEmail()
    {
        WriteLine("Enter Email: ");
        string inputEmail = ReadLine() ?? "";
        foreach(Employee employee in Employees){
            if (employee.Email.Contains(inputEmail))
            {
                return employee.FirstName + " " + employee.LastName;
            }
        }
        return $"{inputEmail} not found";
    }

    public void SearchByLastName()
    {
        WriteLine("Enter last Name: ");
        string inputName =  ReadLine()??"";
        bool found = false;

        foreach (Employee employee in Employees )
        {
            if (employee.LastName.Contains(inputName))
            {
                WriteLine($"{employee.LastName} was found: {employee}");
                found = true;
            }
        }

        if (!found)
        {
            WriteLine($"{inputName} not found");
        }
    }

    public void SearchByPosition()
    {
        WriteLine("Enter Position: ");
        string positionInput =  ReadLine() ?? "";
        bool found = false;

        foreach (Employee employee in Employees)
        {
            if (employee.Position.Contains(positionInput))
            {
                WriteLine(employee.FirstName + " " + employee.LastName); 
                found = true;
            }
        }

        if (!found)
        {
           WriteLine( $"{positionInput} not found");
        }
    }
}