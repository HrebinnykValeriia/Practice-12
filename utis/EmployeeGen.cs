namespace practice12.utis;
using practice12.models;


public static class EmployeeGen
{
    private static string[] firstNames =
    {
        "John",
        "Jane",
        "Doe",
        "Joseph",
        "James",
        "Johnson",
        "William",
        "Jones",
        "Thomas",
        "Eric"
    };

    private static string[] lastNames =
    {
        "Smith",
        "Jones",
        "King",
        "William",
        "Johnson",
        "Basemmath",
        "Martirio",
        "Hristofor",
        "Rory",
        "Thalia"
    };

    private static string[] positions =
    {
        "Trainee",
        "Junior",
        "Senior",
        "Middle",
        "CEO"
    };

    private static string[] emails =
    {
        "email 1",
        "email 2",
        "email 3",
        "email 4",
        "email 5"
    };
    
    private const int MinSalary = 100;
    private const int MaxSalary = 100000;
    private const int MinAge = 18;
    private const int MaxAge = 60;
    
    static Random random = new();
    public static string GenFirstName()
    {
        return firstNames[random.Next(0,firstNames.Length)];
    }

    public static string GenLastName()
    {
        return lastNames[random.Next(0,lastNames.Length)];
    }

    public static string GenPosition()
    {
        return positions[random.Next(0,positions.Length)];
    }

    public static string GenEmail()
    {
        return emails[random.Next(0,emails.Length)]+random.Next()%100+"gmail.com";
    }

    public static int GenSalary()
    {
        return random.Next(MinSalary, MaxSalary);
    }
    public static int GenAge()
    {
        return random.Next(MinAge, MaxAge);
    }

    public static Employee GenEmployee()
    {
        return new Employee(GenFirstName(), GenLastName(), GenPosition(), GenAge(), GenSalary(),  GenEmail());
    }
    public static List<Employee> GenEmployeeS(int count)
    {
        List<Employee> list = new();
        for (int i = 0; i < count; ++i)
        {
            list.Add(GenEmployee());
        }
        return list;
    }
    public static Patient GenPatient()
    {
        return new Patient(GenFirstName(), GenLastName(),GenAge());
    }
}