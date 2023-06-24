namespace ContactsApp.Model.Services;

/// <summary>
/// Настоящий DateTime.
/// </summary>
public class Dater : IDater
{
    /// <summary>
    /// Задаёт настоящий сегодняшний день.
    /// </summary>
    public DateTime Today => DateTime.Today;
}