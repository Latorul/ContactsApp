namespace ContactsApp.Model;

/// <summary>
/// Настоящий DateTime.
/// </summary>
public class RealDateTime : IDateTime
{
    /// <summary>
    /// Задаёт настоящий сегодняшний день.
    /// </summary>
    public DateTime Today => DateTime.Today;
}