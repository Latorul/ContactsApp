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

    [Test]
    [Ignore("Нет реализации теста.")]
    public void AssertOnPhoneNumberFormat_CorrectFormat()
    {
    }

    [Test]
    [Ignore("Нет реализации теста.")]
    public void AssertOnPhoneNumberFormat_IncorrectFormat()
    {
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