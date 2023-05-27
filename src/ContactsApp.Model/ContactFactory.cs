namespace ContactsApp.Model;

/// <summary>
/// Класс для генерации тестовых данных.
/// </summary>
public static class ContactFactory
{
    /// <summary>
    /// Список полных имён.
    /// </summary>
    private static readonly List<string> FullNames = new()
    {
        "Deborah Reeves",
        "John Brown",
        "Brian Jackson",
        "John Green",
        "Andrew Green",
        "Ryan Black",
        "Mary Jones",
        "Cindy Lewis",
        "Joan Chavez",
        "Martha King",
        "Bessie Ford",
        "Norman Jordan",
        "Linda Anderson",
        "Brian Flores",
        "Jessica Williams",
        "Tyrone Williams"
    };

    /// <summary>
    /// Список электронных почт.
    /// </summary>
    private static readonly List<string> Emails = new()
    {
        "deborahreeves@mail.com",
        "johnbrown@mail.com",
        "brianjackson@mail.com",
        "johngreen@mail.com",
        "andrewgreen@mail.com",
        "ryanblack@mail.com",
        "maryjones@mail.com",
        "cindylewis@mail.com",
        "joanchavez@mail.com",
        "marthaking@mail.com",
        "bessieford@mail.com",
        "normanjordan@mail.com",
        "lindaanderson@mail.com",
        "brianflores@mail.com",
        "jessicawilliams@mail.com",
        "tyronewilliams@mail.com"
    };

    /// <summary>
    /// Список ссылок на ВКонтакте.
    /// </summary>
    private static readonly List<string> VkId = new()
    {
        "https://vk.com/deborahreeves",
        "https://vk.com/johnbrown",
        "https://vk.com/brianjackson",
        "https://vk.com/johngreen",
        "https://vk.com/andrewgreen",
        "https://vk.com/ryanblack",
        "https://vk.com/maryjones",
        "https://vk.com/cindylewis",
        "https://vk.com/joanchavez",
        "https://vk.com/marthaking",
        "https://vk.com/bessieford",
        "https://vk.com/normanjordan",
        "https://vk.com/lindaanderson",
        "https://vk.com/brianflores",
        "https://vk.com/jessicawilliams",
        "https://vk.com/tyronewilliams"
    };

    /// <summary>
    /// Список для кодов номеров телефона.
    /// </summary>
    private static readonly List<string> PhoneCodes = new();

    public static IRandomize Random { get; set; }

    /// <summary>
    /// Конструктор класса <see cref="ContactFactory"/>.
    /// </summary>
    static ContactFactory()
    {
        var document = JsonDocument.Parse(Properties.Resources.countries);
        var root = document.RootElement;

        foreach (JsonElement element in root.EnumerateArray())
        {
            element.TryGetProperty("PhoneCode", out JsonElement phoneCodeElement);
            PhoneCodes.Add(phoneCodeElement.GetString());
        }
    }

    /// <summary>
    /// Добавляет контакты для проверки работоспособности программы.
    /// </summary>
    /// <param name="project">Проект, в список которого будут добавлены контакты.</param>
    /// <param name="count">Количество добавляемых контактов.</param>
    public static void GenerateContacts(Project project, int count = 5)
    {
        for (int i = 0; i < count; i++)
        {
            project.Contacts.Add(CreateContact());
        }
    }

    /// <summary>
    /// Создаёт экземпляр класса <see cref="Contact"/>.
    /// </summary>
    /// <returns>Один контакт.</returns>
    public static Contact CreateContact()
    {
        return new Contact
        {
            FullName = GenerateFullName(),
            Email = GenerateEmail(),
            PhoneNumber = GeneratePhoneNumber(),
            DateOfBirth = GenerateDateOfBirth(),
            VkId = GenerateVkId()
        };
    }

    /// <summary>
    /// Генерирует полное имя.
    /// </summary>
    /// <returns>Случайно выбранное имя из списка.</returns>
    private static string GenerateFullName()
    {
        return FullNames[Random.Next(FullNames.Count)];
    }

    /// <summary>
    /// Генерирует электронную почту.
    /// </summary>
    /// <returns>Случайно выбранную электронную почту из списка.</returns>
    private static string GenerateEmail()
    {
        return Emails[Random.Next(Emails.Count)];
    }

    /// <summary>
    /// Генерирует номер телефона.
    /// </summary>
    /// <returns>Случайно сгенерированный номер телефона.</returns>
    private static string GeneratePhoneNumber()
    {
        var phoneNumber = string.Empty;

        phoneNumber += PhoneCodes[Random.Next(PhoneCodes.Count)];
        phoneNumber += " (" + Random.Next(100, 1000) + ") " + Random.Next(100, 1000);

        var dualCount = Random.Next(1, 4);
        for (int i = 0; i < dualCount; i++)
        {
            var hyphenOrSpace = Random.Next(2);
            if (hyphenOrSpace % 2 == 0)
            {
                phoneNumber += "-";
            }
            else
            {
                phoneNumber += " ";
            }

            phoneNumber += Random.Next(10, 100);
        }

        var lastNumber = Random.Next(-1, 10);
        return lastNumber == -1 ? phoneNumber : phoneNumber + " " + lastNumber;
    }

    /// <summary>
    /// Генерирует дату рождения.
    /// https://stackoverflow.com/a/194870/18739226
    /// </summary>
    /// <returns>Случайно сгенерированная дата рождения между
    /// 1900.01.01 и сегодняшним днём.</returns>
    private static DateTime GenerateDateOfBirth()
    {
        var start = new DateTime(1900, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(Random.Next(range));
    }

    /// <summary>
    /// Генерирует ссылку на ВКонтакте.
    /// </summary>
    /// <returns>Случайно выбранную ссылку из списка.</returns>
    private static string GenerateVkId()
    {
        return VkId[Random.Next(VkId.Count)];
    }
}