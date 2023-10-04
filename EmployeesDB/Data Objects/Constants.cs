﻿namespace EmployeesDB;

public class Constants
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    public const string CONNECTION_STRING = "Data Source=vlshn;Initial Catalog=Employees;Integrated Security=True;Encrypt=False;";

    //SQL-запросы
    #region SQL Commands

    /// <summary>
    /// Создание таблицы
    /// </summary>
    public const string CREATE_TABLE_COMMAND =
    "CREATE TABLE Employees (" +
    "ID int NOT NULL PRIMARY KEY IDENTITY," +
    "FullName varchar(40) NOT NULL," +
    "Birth DATE," +
    "Gender varchar(6)" +
    ");";

    /// <summary>
    /// Выборка всех сотрудников с уникальным значением ФИО и дата рождения.
    /// </summary>
    public const string READ_ENTRIES =
        "SELECT FullName, Birth, MAX(Gender) FROM Employees GROUP BY FullName, Birth ORDER BY FullName";

    public const string READ_ENTRIES_F =
        "SELECT * FROM Employees WHERE FullName LIKE 'F%' AND Gender = 'Male'";

    public const string READ_ENTRIES_OPTIMIZED =
        "SELECT FullName, Birth, Gender FROM Employees WHERE substring (fullname, 1, 1) ='F' AND Gender = 'Male'";

    /// <summary>
    /// Добавление сотрудника в таблицу
    /// </summary>
    public const string INSERT_EMPLOYEE =
            "INSERT INTO Employees (FullName, Birth, Gender) VALUES (@FullName, @Birth, @Gender)";


    #endregion

}
