namespace ContactsApp.Model;

/// <summary>
/// Класс для работы со списком всех контактов.
/// </summary>
public class Project
{
    /// <summary>
    /// Возвращает список всех контактов.
    /// </summary>
    public List<Contact> Contacts { get; init; }

    /// <summary>
    /// Конструктор класса <see cref="Project"/>.
    /// </summary>
    public Project() : this(new List<Contact>())
    {
    }

    /// <summary>
    /// Конструктор класса <see cref="Project"/>.
    /// </summary>
    /// <param name="contacts">Список контактов.</param>
    public Project(List<Contact> contacts)
    {
        Contacts = contacts;
    }


    /// <summary>
    /// Возвращает отсортированный список контактов.
    /// </summary>
    /// <param name="contacts">Список контактов для сортировки.</param>
    public List<Contact> SortByFullName(List<Contact> contacts)
    {
        return contacts.OrderBy(c => c.FullName).ToList();
    }

    /// <summary>
    /// Возвращает список контактов, у которых сегодня день рождения.
    /// </summary>
    /// <param name="contacts">Список контактов.</param>
    public List<Contact> FindBirthDayContacts(List<Contact> contacts)
    {
        return contacts.FindAll(c =>
            c.DateOfBirth.Month == DateTime.Today.Month &&
            c.DateOfBirth.Day == DateTime.Today.Day);
    }

    /// <summary>
    /// Возвращает все контакты, у которых есть вхождение подстроки в любом из полей.
    /// </summary>
    /// <param name="contacts">Список контактов.</param>
    /// <param name="substring">Строка для поиска.</param>
    public List<Contact> FindBySubstring(List<Contact> contacts, string substring)
    {
        substring = substring.ToLower();
        return contacts.FindAll(c => c.FullName.ToLower().Contains(substring) ||
                                     c.Email.ToLower().Contains(substring) ||
                                     c.PhoneNumber.ToLower().Contains(substring) ||
                                     c.VkId.ToLower().Contains(substring) ||
                                     c.DateOfBirth.ToString().ToLower().Contains(substring));
    }
}