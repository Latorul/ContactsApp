namespace ContactsApp.Model;

/// <summary>
/// Интерфейс для подмены метода генерации случайных значений.
/// </summary>
public interface IRandomize
{
    /// <summary>
    /// Генерирует псевдослучайное число в диапазоне от 0 до maxValue. 
    /// </summary>
    int Next(int maxValue);
    
    /// <summary>
    /// Генерирует псевдослучайное число в диапазоне от minValue до maxValue. 
    /// </summary>
    int Next(int minValue, int maxValue);
}