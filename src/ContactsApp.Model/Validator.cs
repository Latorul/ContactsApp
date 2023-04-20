namespace ContactsApp.Model;

/// <summary>
/// Сервисный класс для проверки введённых значений.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Проверяет длину полученной строки.
    /// </summary>
    /// <param name="value">Строка для проверки</param>
    /// <param name="maxLength">Максимальная допустимая длина строки</param>
    /// <param name="field">Название поля</param>
    public static void AssertOnStringLength(string value, int maxLength, string field)
    {
        if (value.Length > maxLength)
        {
            throw new ArgumentException(
                $"{field} can't be longer than {maxLength} symbols.");
        }
    }

    /// <summary>
    /// Проверяет дату рождения на вхождение в интервал от минимального года до сегодняшнего дня.
    /// </summary>
    /// <param name="value">Дата для проверки</param>
    /// <param name="minYear">Минимальный год</param>
    public static void AssertOnDateGap(DateTime value, int minYear)
    {
        if (value.Year < minYear)
        {
            throw new ArgumentException(
                $"Date of birth can't be earlier than {minYear} year.");
        }

        if (value > DateTime.Today)
        {
            throw new ArgumentException(
                "Date of birth can't be later then the current day.");
        }
    }
}
