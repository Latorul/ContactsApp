namespace ContactsApp.Model.UnitTests.Fakes;

/// <summary>
/// Псевдослучайная генерация чисел.
/// </summary>
public class FakeRandomizer : IRandomize
{
    /// <param name="maxValue">Максимальное допустимое значение.</param>
    /// <returns>Максимальное допустимое значение.</returns>
    public int Next(int maxValue)
    {
        return maxValue - 1;
    }

    /// <param name="minValue">Значение не влияет на результат.</param>
    /// <param name="maxValue">Максимальное допустимое значение.</param>
    /// <returns>Максимальное допустимое значение.</returns>
    public int Next(int minValue, int maxValue)
    {
        return maxValue - 1;
    }
}