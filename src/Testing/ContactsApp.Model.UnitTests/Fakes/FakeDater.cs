namespace ContactsApp.Model.UnitTests.Fakes;

/// <summary>
/// Подменённый DateTime. 
/// </summary>
public class FakeDater : IDater
{
    /// <summary>
    /// Задаёт ненастоящий сегодняшний день.
    /// </summary>
    public DateTime Today => new(2003, 12, 11);
}