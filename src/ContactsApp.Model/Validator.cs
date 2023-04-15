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
}
