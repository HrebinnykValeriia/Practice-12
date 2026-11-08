namespace practice12;
using practice12.utis;
using static System.Console;

public record Patient(string FirstName, string LastName, int Age)
{
    public override string ToString()
    {
        return $"{FirstName} {LastName} ({Age} years old)";
    }
}

public class Hospital
{
    private PriorityQueue<Patient, int> Patients = new();
    private int priority = 0;
    public int Count => Patients.Count;
    public void AddPatient(Patient patient)
    {
        Patients.Enqueue(patient, priority++);
        WriteLine($"{patient.LastName} joined the queue");
    }

    public void RemovePatient()
    {
        if (Patients.Count == 0)
        {
            WriteLine("There are no patients in queue.");
            return;
        } 
        Patient patient = Patients.Dequeue();
        WriteLine($"{patient.FirstName} {patient.LastName} removed from the queue");
    }

    public void Print()
    {
        if (Patients.Count == 0){
            WriteLine("There are no patients in queue.");
            return;
        }
        
        WriteLine($"There are {Patients.Count} patients in queue.");
        var items = Patients.UnorderedItems.ToArray();
        for (int i = 0; i < items.Length - 1; i++)
        {
            for (int j = 0; j < items.Length - i - 1; j++)
            {
                if (items[j].Priority > items[j + 1].Priority)
                {
                    (items[j], items[j + 1]) = (items[j + 1], items[j]);
                }
            }
        }
        for (int i = 0; i < items.Length; i++)
        {
            WriteLine(items[i].Element);
        }
    }
    public static List<Patient> GenPatients(int count)
    {
        List<Patient> patients = new();
        for (int i = 0; i < count; i++)
        {
            patients.Add(EmployeeGen.GenPatient());
        }
        return patients;
    }
}