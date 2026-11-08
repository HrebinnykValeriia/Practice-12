namespace practice12.models
{
    public record  Employee(string FirstName, string LastName, string Position, int Age, int Salary, string Email)
    {
        public override string ToString()
        {
            return  $"{FirstName} {LastName} is {Age} years old. Earns {Salary}$ as {Position}.\n({Email}) ";
        }
    }
    
}

