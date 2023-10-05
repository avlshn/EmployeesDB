namespace EmployeesDB;

internal static class RNGEntriesMode
{
    public enum GenModes
    {
        small,
        capital,
        digit
    }

    public static Employee GenerateEntry()
    {
        Random rnd = new Random();

        string fullName = null;
        DateOnly Birth = new DateOnly();
        string gender;

        //Генерация фамилии
        fullName += GenerateWord(rnd.Next(4, 8));
        fullName += " ";

        //Генерация имени
        fullName += GenerateWord(rnd.Next(4, 8));
        fullName += " ";

        //Генерация отчества
        fullName += GenerateWord(rnd.Next(4, 8));

        //Выбор пола
        if (rnd.Next(2) == 0) gender = "Male";
        else gender = "Female";

        //Выбор даты рождения. Так как задача равномерного распределения не стоит, число рождения 
        //возьмем 1, а год и месяц определим случайно в диапазонах 1- 12 и 1923 - 2023.
        Birth = new DateOnly(rnd.Next(1923, 2024), rnd.Next(1, 13), 1);

        return new Employee(fullName, Birth, gender);
    }


    /// <summary>
    /// Генерация случайных записей и пакетная отправка, используя объект класса для работы с данными.
    /// </summary>
    /// <param name="entriesIO"> Объект класса работы с данными</param>
    public static void GenerateAllEntries(EntriesIO entriesIO)
    {
        Employee employeeF;
        for (int i = 0; i < 1000000; i++)
        {
            entriesIO.AddEmployee(GenerateEntry());
        }
        for (int i = 0; i < 100; i++)
        {
            employeeF = GenerateEntry();
            employeeF.FullName = employeeF.FullName.Remove(0, 1);
            employeeF.FullName = employeeF.FullName.Insert(0, "F");
            employeeF.Gender = "Male";
            entriesIO.AddEmployee(employeeF);
        }
        entriesIO.InsertEntries();
    }

    public static char GenerateSymbol(GenModes mode)
    {
        int lower;
        int upper;
        switch (mode)
        {
            case GenModes.small:
                lower = 97;
                upper = 123;
                break;
            case GenModes.capital:
                lower = 65;
                upper = 91;
                break;
            case GenModes.digit:
                lower = 48;
                upper = 58;
                break;
            default:
                throw new ArgumentException("Неверно выбран режим генерации символа.");
        }

        Random rnd = new Random();
        return (char)rnd.Next(lower, upper);
    }

    public static string GenerateWord(int count)
    {
        string word = null;
        word += GenerateSymbol(GenModes.capital);
        for (int i = 0; i <= count; i++)
            word += GenerateSymbol(GenModes.small);
        return word;
    }
}
