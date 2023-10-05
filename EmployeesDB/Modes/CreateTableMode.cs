using Microsoft.Data.SqlClient;
using static EmployeesDB.Constants;

namespace EmployeesDB;

public static class CreateTableMode
{
    public static void CreateTable()
    {

        using SqlConnection connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand(CREATE_TABLE_COMMAND, connection);
        sqlCommand.ExecuteNonQuery();
        Console.WriteLine("Table created.");
    }
}
