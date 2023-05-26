namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ValidatorTest
{
    [Test(Description = "Проверка пустой строки, не выходящей за пределы заданного значения.")]
    [TestCase("", TestName = "Проверка пустой строки.")]
    [TestCase("Короткая строка", TestName = "Проверка короткой строки.")]
    [TestCase("В этой строке содержится ровно сто символов, что является " +
              "максимально допустимой длиной для проверки",
        TestName = "Проверка строки максимально допустимой длины.")]
    public void AssertOnStringLength_ShortString(string shortString)
    {
        // Setup
        var maxLength = 100;
        var fieldName = nameof(shortString);

        // Assert
        Assert.DoesNotThrow(() =>
                // Act
                Validator.AssertOnStringLength(shortString, maxLength, fieldName),
            "Не должно выбрасывать исключение при передаче строки короче или равной по длине, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка длины строки, выходящей за пределы заданного значения.")]
    public void AssertOnStringLength_LongString()
    {
        // Setup
        var maxLength = 100;
        var longString = "Длинная строка, которая очевидно длиннее 100 символов - " +
                         "присвоение такой строки наверняка должно вызывать исключение";
        var fieldName = nameof(longString);

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                Validator.AssertOnStringLength(longString, maxLength, fieldName),
            "Должно выбрасывать исключение при передаче строки строго длиннее, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка более ранней даты, чем 1900 год.")]
    public void AssertOnDateGap_TooEarly()
    {
        // Setup
        var earlyDate = new DateTime(1899, 12, 31);

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act 
                Validator.AssertOnDateGap(earlyDate),
            "Должно выбрасывать исключение при передаче более ранней даты, чем указанный год.");
    }

    [Test(Description = "Проверка будущей даты.")]
    public void AssertOnDateGap_Future()
    {
        // Setup
        var tomorrow = DateTime.Today.AddDays(1);

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act 
                Validator.AssertOnDateGap(tomorrow),
            "Должно выбрасывать исключение при передаче даты позже, чем сегодняшний день.");
    }

    [Test(Description = "Проверка даты между 1900 годом и сегодняшней.")]
    public void AssertOnDateGap_CorrectDate(
        [ValueSource(nameof(GetCorrectDates))] DateTime correctDate)
    {
        // Assert
        Assert.DoesNotThrow(() =>
                // Act
                Validator.AssertOnDateGap(correctDate),
            "Не должно выбрасывать исключение при передаче даты между 1900 годом и сегодняшней.");
    }

    [Test(Description = "Проверка номера телефона правильного формата."), Combinatorial]
    public void AssertOnPhoneNumberFormat_CorrectFormat(
        [Values("+1 ", "+12 ", "+123 ", "+1234 ")]
        string code,
        [Values("(123) 456")] string mainBody,
        [Values(" 12", "-12")] string firstDual,
        [Values("", " 12", "-12")] string secondDual,
        [Values("", " 12", "-12")] string thirdDual,
        [Values("", " 1")] string single,
        [Values("", " ")] string space)
    {
        // Setup
        var correctPhoneNumber =
            code + mainBody + firstDual + secondDual + thirdDual + single + space;

        // Assert
        Assert.DoesNotThrow(() =>
                // Act
                Validator.AssertOnPhoneNumberFormat(correctPhoneNumber),
            "Не должно выбрасывать исключение при передаче номера телефона в корректном формате."
        );
    }

    [Test(Description = "Проверка номера телефона неправильного формата."), Combinatorial]
    public void AssertOnPhoneNumberFormat_IncorrectFormat(
        [Values("1 ", "+ ", "+123", "+12345 ")] string code,
        [Values("(123) 456", "123 456", "(123)456")] string mainBody,
        [Values("12", "-123")] string firstDual,
        [Values("12", "-12")] string secondDual,
        [Values(" 12", "12")] string thirdDual,
        [Values(" 12")] string single,
        [Values("1")] string space)
    {
        // Setup
        var incorrectPhoneNumber =
            code + mainBody + firstDual + secondDual + thirdDual + single + space;
        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act 
                Validator.AssertOnPhoneNumberFormat(incorrectPhoneNumber),
            "Должно выбрасывать исключение при передаче номера телефона в некорректном формате.");
    }

    /// <summary>
    /// Возвращает даты, входящие в диапазон разрешённых дат.
    /// </summary>
    /// <returns>Список дат.</returns>
    private static IEnumerable<DateTime> GetCorrectDates()
    {
        yield return new DateTime(1900, 1, 1);
        yield return new DateTime(2000, 2, 28);
        yield return DateTime.Today;
    }
}