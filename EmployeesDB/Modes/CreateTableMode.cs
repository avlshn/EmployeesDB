using Microsoft.Data.SqlClient;
using static EmployeesDB.Constants;

namespace EmployeesDB;

public static class CreateTableMode
{
    public static async void CreateTable(string connectionString)
    {

        if (connectionString == null) return;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(CREATE_TABLE_COMMAND, connection);
            sqlCommand.ExecuteNonQuery();
        }


    }
}
