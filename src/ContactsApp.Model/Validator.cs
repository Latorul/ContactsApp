namespace ContactsApp.Model;

/// <summary>
/// Сервисный класс для проверки введённых значений.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Шаблон номера телефона. <para/>
    /// Начинается с кода страны. Через пробел три цифры в скобках.<br/>
    /// Потом ещё один пробел и три цифры без скобок.<br/>
    /// Следующий блок может повторяться от одного до трёх раз и состоит из разделителя и двух цифр.
    /// Разделителем может быть либо пробел, либо дефис.<br/>
    /// В конце через пробел может стоять одна цифра.
    /// <code>
    /// +1 (234) 567 89
    /// +1 (234) 567-89
    /// +1 (234) 567 89 0
    /// +1 (234) 567-89 0
    /// +12 (345) 678 90 12 3
    /// +12 (345) 678 90-12 3
    /// +12 (345) 678-90 12 3
    /// +12 (345) 678-90-12 3
    /// +123 (456) 789 01 23 45
    /// +123 (456) 789 01 23-45
    /// +123 (456) 789 01-23-45
    /// +123 (456) 789-01-23-45
    /// +1234 (567) 890 12 34 56 7
    /// +1234 (567) 890 12-34-56 7
    /// +1234 (567) 890-12-34 56 7
    /// +1234 (567) 890-12-34-56 7
    /// </code>
    /// </summary>
    private static readonly Regex Regex =
        new(@"^\+\d{1,4} \(\d{3}\) \d{3}(( |-)\d{2}){1,3}( \d{1}){0,1} *$");

    /// <summary>
    /// Самый ранний год даты рождения.
    /// </summary>
    private const int MinDateOfBirthYear = 1900;

    
    public static IDateTime DateTime { get; set; }

    /// <summary>
    /// Проверяет длину полученной строки.
    /// </summary>
    /// <param name="value">Строка для проверки.</param>
    /// <param name="maxLength">Максимальная допустимая длина строки.</param>
    /// <param name="field">Название поля.</param>
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
    /// <param name="value">Дата для проверки.</param>
    public static void AssertOnDateGap(DateTime value)
    {
        if (value.Year < MinDateOfBirthYear)
        {
            throw new ArgumentException(
                $"Date of birth can't be earlier than {MinDateOfBirthYear} year.");
        }

        if (value > DateTime.Today)
        {
            throw new ArgumentException(
                "Date of birth can't be later then the current day.");
        }
    }

    /// <summary>
    /// Проверяет введённый номер телефона на соответствие формату.
    /// </summary>
    /// <param name="value">Номер телефона.</param>
    public static void AssertOnPhoneNumberFormat(string value)
    {
        if (!Regex.IsMatch(value))
        {
            throw new ArgumentException(
                "Phone number must be written in one of these formats:\n" +
                "+1 (123) 456 78\n" +
                "+12 (123) 456 78 9\n" +
                "+12 (123) 456 78-90\n" +
                "+123 (123) 456 78-90 1\n" +
                "+1234 (123) 456 78-90-12\n" +
                "+1234 (123) 456 78-90-12 3\n");
        }
    }
}