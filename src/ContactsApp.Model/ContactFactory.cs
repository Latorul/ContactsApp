namespace ContactsApp.Model;

/// <summary>
/// Содержит методы по генерации данных.
/// </summary>
public static class ContactFactory
{
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

    private static readonly List<string> PhoneCodes = new();

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
    /// <param name="project"></param>
    /// <param name="count"></param>
    public static void GenerateContacts(Project project, int count = 5)
    {
        for (int i = 0; i < count; i++)
        {
            project.Contacts.Add(CreateContact());
        }
    }

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

    private static string GenerateFullName()
    {
        return FullNames[new Random().Next(FullNames.Count)];
    }

    private static string GenerateEmail()
    {
        return Emails[new Random().Next(Emails.Count)];
    }

    private static string GeneratePhoneNumber()
    {
        var phoneNumber = string.Empty;

        phoneNumber += PhoneCodes[new Random().Next(PhoneCodes.Count)];
        phoneNumber += " (" + new Random().Next(100, 1000) + ") " + new Random().Next(100, 1000);

        var dualCount = new Random().Next(1, 4);
        for (int i = 0; i < dualCount; i++)
        {
            var hyphenOrSpace = new Random().Next(2);
            if (hyphenOrSpace % 2 == 0)
            {
                phoneNumber += "-";
            }
            else
            {
                phoneNumber += " ";
            }

            phoneNumber += new Random().Next(10, 100);
        }

        var lastNumber = new Random().Next(-1, 10);
        return lastNumber == -1 ? phoneNumber : phoneNumber + " " + lastNumber;
    }

    /// <summary>
    /// https://stackoverflow.com/a/194870/18739226
    /// </summary>
    /// <returns></returns>
    private static DateTime GenerateDateOfBirth()
    {
        var start = new DateTime(1900, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(new Random().Next(range));
    }

    private static string GenerateVkId()
    {
        return VkId[new Random().Next(VkId.Count)];
    }
}