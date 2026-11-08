using practice12.utis;
using practice12.models;
using practice12.Services;


namespace practice12;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        //task 1
        List<Employee> employees = EmployeeGen.GenEmployeeS(10);
        ServicesListEmployee serviceList = new(employees);
        string menu = """
                      Оберіть операцію:
                      0. Вихід
                      1. Додати співробітників
                      2. Видалити співробітників
                      3. Змінити інформацію
                      4. Пошук за параметрами
                      5. Сортування за параметрами
                      6. Показати усіх співробітників
                      """;
        do
        {
            Clear();
            WriteLine(menu);
        if (!int.TryParse(ReadLine(), out int choice))
        {
            WriteLine("Invalid input");
            ReadKey();
            continue;
        }
            if (choice == 0)
            {
                WriteLine("Допобачення!");
                break;
            }
            switch (choice)
            {
                case 1:
                {
                    serviceList.AddEmployee(new Employee(
                        EmployeeGen.GenFirstName(),
                        EmployeeGen.GenLastName(),
                        EmployeeGen.GenPosition(),
                        EmployeeGen.GenAge(),
                        EmployeeGen.GenSalary(),
                        EmployeeGen.GenEmail()
                    ));
                    break;
                }
                case 2:
                {
                    serviceList.ShowEmployees();
                    WriteLine("Оберіть співробітника для видалення: ");
                    choice = int.Parse(ReadLine() ?? "0");
                    WriteLine(serviceList.RemoveEmployee(choice-1));
                    break;
                }
                case 3:
                {
                    serviceList.ShowEmployees();
                    WriteLine("Оберіть співробітника для редагування: ");
                    choice = int.Parse(ReadLine() ?? "0");
                    WriteLine(serviceList.EditEmployee(choice-1));
                    break;
                }
                case 4:
                {
                    WriteLine("Оберіть параметр для пошуку:\n1. Призвіще\n2. Поссада\n3. Пошта\n");
                    int choice1 = int.Parse(ReadLine() ?? "0");
                    switch (choice1)
                    {
                        case 1: 
                            serviceList.SearchByLastName();
                            break;
                        case 2:
                            serviceList.SearchByPosition();
                            break;
                        case 3:
                            WriteLine(serviceList.SearchByEmail());
                            break;
                        default:
                            WriteLine("Неправильний ввід");
                            break;
                    }
                    break;
                }
                case 5:
                {
                    WriteLine("Оберіть параметр для сортування:\n1. Ім'я\n2. Зарплатня\n3. Вік\n");
                    int choice1 = int.Parse(ReadLine() ?? "0");
                    switch (choice1)
                    {
                        case 1:
                            WriteLine("Default: ");
                            serviceList.ShowEmployees();
                            WriteLine("Sorted: ");
                            serviceList.SortByFirstName();
                            serviceList.ShowEmployees();
                            break;
                        case 2:
                            WriteLine("Default: ");
                            serviceList.ShowEmployees();
                            WriteLine("Sorted: ");
                            serviceList.SortBySalary();
                            serviceList.ShowEmployees();
                            break;
                        case 3:
                            WriteLine("Default: ");
                            serviceList.ShowEmployees();
                            WriteLine("Sorted: ");
                            serviceList.SortByAge();
                            serviceList.ShowEmployees();
                            break;
                        default:
                            WriteLine("Неправильний ввід");
                            break;
                    }
                    break;
                }
                case 6:
                {
                    serviceList.ShowEmployees();
                    break;  
                }
                default:
                {
                    WriteLine("Invalid choice");
                    break;  
                }
                    
            }
            ReadKey();
        } while (true);
        
        //task 2
         LinkedList<Book> books = BookGen.GenBooks(10);
         ServicesListBook  serviceListBook = new(books);
         string menuBook = """
                       Оберіть операцію:
                       0. Вихід
                       1. Додати книжку
                       2. Видалити кнжку
                       3. Змінити інформацію
                       4. Пошук за параметрами
                       5. Показати усі книжки
                       """;
         do
         {
             Clear();
             WriteLine(menuBook);
             int choiceBook = int.Parse(ReadLine() ?? "0");
             if (choiceBook == 0)
             {
                 WriteLine("Допобачення!");
                 break;
                 
             }
             switch (choiceBook)
             {
                 case 1:
                 {
                     WriteLine("""
                               Виберіть опцію для додавання:
                               1. У початок 
                               2. У кінець
                               3. У бажану позицію

                               Введіть вибір: 
                               """);
                     if (!int.TryParse(ReadLine(), out int miniChoice))
                     {
                         WriteLine("Invalid input");
                         ReadKey();
                         continue;
                     }                    
                     switch (miniChoice)
                     {
                         case 1:
                         {
                             serviceListBook.AddBookBegin(new Book(
                                 BookGen.GenTitle(),
                                 BookGen.GenAuthor(),
                                 BookGen.GenGenre(),
                                 BookGen.GenYear()
                             ));
                             break;
                         }
                         case 2:
                         {
                             serviceListBook.AddBookEnd(new Book(
                                 BookGen.GenTitle(),
                                 BookGen.GenAuthor(),
                                 BookGen.GenGenre(),
                                 BookGen.GenYear()
                             ));
                             break;
                         }
                         case 3:
                         {
                             WriteLine("Введіть бажане місце: ");
                             int num = int.Parse(ReadLine() ?? "0");
                             serviceListBook.AddBook(num, new Book(
                                 BookGen.GenTitle(),
                                 BookGen.GenAuthor(),
                                 BookGen.GenGenre(),
                                 BookGen.GenYear()
                             ));
                             break;
                         }
                     }
                     break;
                 }
                 case 2:
                     WriteLine("""
                               Виберіть опцію для видалення:
                               1. У початок 
                               2. У кінець
                               3. У бажану позицію

                               Введіть вибір: 
                               """);
                     int miniCh = int.Parse(ReadLine() ?? "0");
                     switch (miniCh)
                     {
                         case 1:
                             WriteLine(serviceListBook.RemoveBookBegin());
                             break;
                         case 2:
                             WriteLine(serviceListBook.RemoveBookEnd());
                             break;
                         case 3:
                             serviceListBook.ShowBooks();
                             WriteLine("Оберіть книжку для видалення: ");
                             int num = int.Parse(ReadLine() ?? "0");
                             WriteLine(serviceListBook.RemoveBook(num));
                             break;
                     }
                     break;
                 case 3:
                 {
                     serviceListBook.ShowBooks();
                     WriteLine("Оберіть книжку для редагування: ");
                     int num = int.Parse(ReadLine() ?? "0");
                     WriteLine(serviceListBook.EditBook(num));
                     break;
                 }
                 case 4:
                 {
                     WriteLine("Оберіть параметр для пошуку:\n1. Ім'я автора\n2. Назва книги\n3. Жанр\n4. Рік випуску\nВаш вибір: ");
                     int num = int.Parse(ReadLine() ?? "0");
                     switch (num)
                     {
                         case 1:
                             serviceListBook.SearchByAuthor();
                             break;
                         case 2:
                             serviceListBook.SearchByTitle();
                             break;
                         case 3:
                             serviceListBook.SearchByGenre();
                             break;
                         case 4:
                             serviceListBook.SearchByYear();
                             break;
                     }
                     break;
                 }
                 case 5:
                     serviceListBook.ShowBooks();
                     break;
                 default:
                     WriteLine("Invalid choice");
                     break;
             }
             ReadKey();
         } while (true);
        
        // task 3
        Hospital hospital = new Hospital();
        List<Patient> patients = Hospital.GenPatients(10);
        foreach (Patient patient in patients)
        {
            hospital.AddPatient(patient);
        }
        string menuH = """
                      HOSPITAL MENU
                      0. Exit
                      1. Add patient
                      2. Doctor accepts patient
                      3. Show queue
                      Enter your choice:
                      """;

        do
        {
            Clear();
            WriteLine(menuH);

            if (!int.TryParse(ReadLine(), out int choice))
            {
                WriteLine("Invalid input");
                ReadKey();
                continue;
            }

            switch (choice)
            {
                case 0:
                    WriteLine("Goodbye!");
                    return;

                case 1:
                    Patient newPatient = EmployeeGen.GenPatient();
                    hospital.AddPatient(newPatient);
                    break;

                case 2:
                   hospital.RemovePatient();
                    break;

                case 3:
                    hospital.Print();
                    break;

                default:
                    WriteLine("Invalid choice");
                    break;
            }
            ReadKey();
        } while (true);
    }
}