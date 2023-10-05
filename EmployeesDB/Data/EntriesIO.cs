using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Diagnostics;
using static EmployeesDB.Constants;

namespace EmployeesDB;

public class EntriesIO
{
    Stopwatch stopwatch = new Stopwatch();
    private List<Employee> employees = new List<Employee>();

    /// <summary>
    /// Чтение записей из БД, запрос передается в качестве парамерта
    /// </summary>
    public void ReadEntries(string sqlRequest)
    {
        employees.Clear();
        using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        {
            int optimization;
            if (sqlRequest == READ_ENTRIES_F) optimization = 1;
            else optimization = 0;

            connection.Open();
            stopwatch.Start();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sqlRequest;
            cmd.CommandTimeout = 0;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee(
                            reader.GetString(0 + optimization),
                            DateOnly.FromDateTime(reader.GetDateTime(1 + optimization)),
                            reader.GetString(2 + optimization)));
                    }
                }
            }
        }
        stopwatch.Stop();
    }

    /// <summary>
    /// Отправить все записи из списка в БД
    /// </summary>
    public void InsertEntries()
    {
        using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Open();
            foreach (Employee employee in employees)
            {
                employee.InsertEmployee(connection);
            }
        }
    }

    /// <summary>
    /// Перегрузка метода, которая пакетно отправляет данные в БД, принимая массив объектов. пункт 4.
    /// Для задания использую другую версию, которая отправляет данные из коллекции объекта.
    /// </summary>
    public void InsertEntries(List<Employee> employeesExternal)
    {
        using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Open();
            foreach (Employee employee in employeesExternal)
            {
                employee.InsertEmployee(connection);
            }
        }
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void OnScreen()
    {
        foreach (Employee e in employees) e.DataOnScreen();
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        Console.WriteLine($"{employees.Count} entries found");
    }
}
