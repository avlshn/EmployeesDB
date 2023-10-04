using Microsoft.Data.SqlClient;
using static EmployeesDB.Constants;

namespace EmployeesDB;

/// <summary>
/// Класс сотрудника
/// </summary>
public class Employee
{


    #region Employee Properties

    private string _fullName;

    public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }

    private DateOnly _birth;

    public DateOnly Birth
    {
        get { return _birth; }
        set { _birth = value; }
    }

    private string _gender;

    public string Gender
    {
        get { return _gender; }
        set { _gender = value; }
    }

    public int Age
    {
        get
        {

            return GetAge();
        }
    }

    #endregion

    #region Constructors

    public Employee(string[] parameters)
    {
        if (parameters.Length >= 2) _fullName = parameters[1];
        else _fullName = "Default name";
        if (parameters.Length >= 3)
        {
            if (!DateOnly.TryParse(parameters[2], out _birth)) _birth = DateOnly.FromDateTime(DateTime.Now);
        }
        else _birth = DateOnly.FromDateTime(DateTime.Now);
        if (parameters.Length >= 4)
        {
            _gender = parameters[3];
        }
        else _gender = "Male";
    }

    public Employee(string name, DateOnly birth, string gender)
    {
        FullName = name;
        Birth = birth;
        Gender = gender;
    }

    #endregion

    public void InsertEmployee(SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand(INSERT_EMPLOYEE, connection);
        sqlCommand.Parameters.Add(new SqlParameter("@FullName", FullName));
        sqlCommand.Parameters.Add(new SqlParameter("@Birth", Birth));
        sqlCommand.Parameters.Add(new SqlParameter("@Gender", Gender));
        sqlCommand.ExecuteNonQuery();
    }

    public int GetAge()
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        int age = now.Year - Birth.Year;
        if (Birth > now.AddYears(-age)) age--;
        return age;
    }

    public void DataOnScreen()
    {
        Console.WriteLine("{0, -40} | {1, -12}  |  {2, -10}  |  {3, 5} ", FullName, Birth, Gender, Age);
    }
}
