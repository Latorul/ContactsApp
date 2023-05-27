namespace ContactsApp.Model;

/// <summary>
/// Случайная генерация чисел.
/// </summary>
public class Randomizer : IRandomize
{
    /// <param name="maxValue">Максимальное допустимое значение.</param>
    /// <returns>Случайное число от 0 до maxValue.</returns>
    public int Next(int maxValue)
    {
        return new Random().Next(maxValue);
    }

    /// <param name="minValue">Минимальное допустимое значение.</param>
    /// <param name="maxValue">Максимальное допустимое значение.</param>
    /// <returns>Случайное число от minValue до maxValue.</returns>
    public int Next(int minValue, int maxValue)
    {
        return new Random().Next(minValue, maxValue);
    }
}