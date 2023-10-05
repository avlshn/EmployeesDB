using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using static EmployeesDB.Constants;

namespace EmployeesDB;

public class Program
{
    static void Main(string[] args)
    {
        EntriesIO entriesIO = new EntriesIO();

        if (args.Length == 0)
        {
            Console.WriteLine("Invalid arguments.");
            return;
        }
        switch (args[0])
        {
            case "1":
                try
                {
                    CreateTableMode.CreateTable();
                }
                catch (Exception ex)
                {
                     Console.WriteLine(ex.Message);
                }
                break;
            case "2":
                Employee employee = new Employee(args);
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    employee.InsertEmployee(connection);
                }
                break;
            case "3":
                entriesIO.ReadEntries(READ_ENTRIES);
                entriesIO.OnScreen();
                break;
            case "4":
                try
                {
                    RNGEntriesMode.GenerateAllEntries(entriesIO);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case "5":
                entriesIO.ReadEntries(READ_ENTRIES_F);
                entriesIO.OnScreen();
                break;
            case "6":
                entriesIO.ReadEntries(READ_ENTRIES_OPTIMIZED);
                entriesIO.OnScreen();
                break;
            default:
                Console.WriteLine("Invalid mode. Select 1 to 6");
                break;
        }
    }
}