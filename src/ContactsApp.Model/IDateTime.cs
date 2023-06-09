namespace ContactsApp.Model;

/// <summary>
/// Интерфейс для подмены сегодняшнего дня.
/// </summary>
public interface IDateTime
{
    /// <summary>
    /// Задаёт дату сегодняшнего дня.
    /// </summary>
    DateTime Today { get; }
}