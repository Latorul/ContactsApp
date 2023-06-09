namespace ContactsApp.Model;

/// <summary>
/// Подменённый DateTime. 
/// </summary>
public class FakeDateTime : IDateTime
{
    /// <summary>
    /// Задаёт ненастоящий сегодняшний день.
    /// </summary>
    public DateTime Today => new(2003, 12, 11);
}