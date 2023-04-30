namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ValidatorTest
{
    [Test(Description = "Проверка пустой строки, не выходящей за пределы заданного значения.")]
    [TestCase("", TestName = "Проверка пустой строки")]
    [TestCase("Короткая строка", TestName = "Проверка короткой строки")]
    [TestCase("В этой строке содержится ровно сто символов, что является " +
              "максимально допустимой длиной для проверки",
        TestName = "Проверка строки максимально допустимой длины")]
    public void AssertOnStringLength_ShortString(string shortString)
    {
        var maxLength = 100;
        var fieldName = nameof(shortString);

        Assert.DoesNotThrow(
            () => Validator.AssertOnStringLength(shortString, maxLength, fieldName),
            "Не должно выбрасывать исключение при передаче строки короче или равной по длине, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка длины строки, выходящей за пределы заданного значения.")]
    public void AssertOnStringLength_LongString()
    {
        var maxLength = 100;
        var longString = "Длинная строка, которая очевидно длиннее 100 символов - " +
                         "присвоение такой строки наверняка должно вызывать исключение";
        var fieldName = nameof(longString);

        Assert.Throws<ArgumentException>(
            () => Validator.AssertOnStringLength(longString, maxLength, fieldName),
            "Должно выбрасывать исключение при передаче строки строго длиннее, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка более ранней даты, чем 1900 год.")]
    public void AssertOnDateGap_TooEarly()
    {
        var earlyDate = new DateTime(1899, 12, 31);

        Assert.Throws<ArgumentException>(
            () => Validator.AssertOnDateGap(earlyDate),
            "Должно выбрасывать исключение при передаче более ранней даты, чем указанный год.");
    }

    [Test(Description = "Проверка будущей даты.")]
    public void AssertOnDateGap_Future()
    {
        var tomorrow = DateTime.Today.AddDays(1);

        Assert.Throws<ArgumentException>(
            () => Validator.AssertOnDateGap(tomorrow),
            "Должно выбрасывать исключение при передаче даты позже, чем сегодняшний день.");
    }

    [Test(Description = "Проверка даты между 1900 годом и сегодняшней.")]
    public void AssertOnDateGap_CorrectDate(
        [ValueSource(nameof(GetCorrectDates))] DateTime correctDate)
    {
        Assert.DoesNotThrow(
            () => Validator.AssertOnDateGap(correctDate),
            "Не должно выбрасывать исключение при передаче даты между 1900 годом и сегодняшней.");
    }

    [Test]
    [Ignore("Нет реализации теста")]
    public void AssertOnPhoneNumberFormat_CorrectFormat()
    {
        
    }

    [Test]
    [Ignore("Нет реализации теста")]
    public void AssertOnPhoneNumberFormat_IncorrectFormat()
    {
        
    }
    
    
    private static IEnumerable<DateTime> GetCorrectDates()
    {
        yield return new DateTime(1900, 1, 1);
        yield return DateTime.Today;
        yield return new DateTime(2000, 2, 28);
    }
}