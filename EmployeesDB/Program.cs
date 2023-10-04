using static EmployeesDB.Constants;

namespace EmployeesDB;

public class Program
{
    static void Main(string[] args)
    {
        //CreateTableMode.CreateTable(CONNECTION_STRING);
        EntriesIO entriesIO = new EntriesIO();
        //RNGEntriesMode.GenerateAllEntries(entriesIO);

        entriesIO.ReadEntries(READ_ENTRIES);
        entriesIO.OnScreen();


        //if (args.Length == 0) 
        //{
        //    Console.WriteLine("Invalid arguments.");
        //    return;
        //}
        //switch (args[0])
        //{
        //    case "1":
        //        CreateTableMode.CreateTable(CONNECTION_STRING);
        //        break;
        //    case "2":
        //        Employee employee = new Employee(args);
        //        using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        //        {
        //            connection.Open();
        //            employee.InsertEmployee(connection);
        //        }
        //        Console.WriteLine(employee.Age); 
        //        break;
        //    case "3":
        //        EntriesIO entriesIO = new();
        //        entriesIO.ReadEntries(READ_ENTRIES);
        //        entriesIO.OnScreen();
        //        entriesIO.InsertEntries();
        //        Console.WriteLine("Entries are copied");
        //        Console.WriteLine();
        //        entriesIO.ReadEntries(READ_ENTRIES);
        //        entriesIO.OnScreen();
        //        break;
        //    case "4":
        //        Console.WriteLine("Mode 4 selected");
        //        break;
        //    case "5":
        //        Console.WriteLine("Mode 5 selected");
        //        break;
        //    case "6":
        //        Console.WriteLine("Mode 6 selected");
        //        break;
        //    default: Console.WriteLine("Invalid mode. Select 1 to 6");
        //        break;
        //}
    }
}