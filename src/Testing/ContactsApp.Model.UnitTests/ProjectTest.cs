namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ProjectTest
{
    [Test(Description = "Проверка конструктора без параметров.")]
    public void EmptyConstructor_ProjectCreated()
    {
        // Setup
        var project =
            // Act
            new Project();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(project.Contacts, Is.Not.Null);
            Assert.That(project.Contacts, Has.Count.Zero);
        });
    }

    [Test(Description = "Проверка конструктора с заданным списком контактов.")]
    public void ConstructorWithParameter_ProjectCreated()
    {
        // Setup
        var expectedContacts = new List<Contact>();

        // Act
        var project = new Project(expectedContacts);

        // Assert
        Assert.That(project.Contacts, Is.EqualTo(expectedContacts));
    }

    [Test(Description = "Проверка геттера списка контактов.")]
    public void Contacts_ListReturned()
    {
        // Setup
        var expectedContacts = new List<Contact>();
        var project = new Project(expectedContacts);
        ContactFactory.Random = new FakeRandomizer();
        project.Contacts.Add(ContactFactory.CreateContact());

        // Act
        var actualContacts = project.Contacts;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualContacts, Has.Count.Not.Zero);
            Assert.That(expectedContacts, Is.EqualTo(actualContacts));
        });
    }

    [Test(Description = "Проверка сортировки списка контактов.")]
    public void SortByFullName_SortNotEmptyList_ListSorted()
    {
        // Setup
        var project = new Project();
        ContactFactory.Random = new FakeRandomizer();
        ContactFactory.GenerateContacts(project, 3);

        project.Contacts[0].FullName = "John Doe";
        project.Contacts[1].FullName = "Alice Smith";
        project.Contacts[2].FullName = "Bob Johnson";

        var expectedContacts = new List<Contact>()
        {
            project.Contacts[1],
            project.Contacts[2],
            project.Contacts[0],
        };

        // Act
        var actualContacts = project.SortByFullName(project.Contacts);

        // Assert
        CollectionAssert.AreEqual(expectedContacts, actualContacts);
    }

    [Test(Description = "Проверка поиска именинников.")]
    public void SearchBirthDayContacts_ThereAreBirthDayContacts_ReturnBirthDayContacts()
    {
        // Setup
        var project = new Project();
        ContactFactory.Random = new FakeRandomizer();
        ContactFactory.DateTime = new FakeDateTime();
        ContactFactory.GenerateContacts(project, 3);

        project.Contacts[0].DateOfBirth = Contact.DateTime.Today;
        project.Contacts[1].DateOfBirth = Contact.DateTime.Today.AddDays(-1);
        project.Contacts[2].DateOfBirth = Contact.DateTime.Today;

        var expectedContacts = new List<Contact>()
        {
            project.Contacts[0],
            project.Contacts[2]
        };

        // Act
        var actualContacts =
            project.SearchBirthDayContacts(project.Contacts, Contact.DateTime.Today);

        // Assert
        CollectionAssert.AreEqual(expectedContacts, actualContacts);
    }

    [Test(Description = "Проверка поиска контактов по подстроке.")]
    public void SearchBySubstring_ThereAreContactsWithSubstring_ReturnedContactsWithSubstring()
    {
        // Setup
        var contacts = new List<Contact>()
        {
            new("John Doe", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "VkId"),
            new("FullName", "johndoe@mail.com", "+1 (234) 567 89", new DateTime(1900, 1, 1), "vkId"),
            new("FullName", "Email", "+1 (234) 567 16", new DateTime(1900, 1, 1), "vkId"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(2002, 10, 16), "vkId"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "https://vk.com/johndoe"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "vkId"),
        };
        var project = new Project(contacts);

        var expectedContactsWithLettersSubstring = new List<Contact>()
        {
            project.Contacts[0],
            project.Contacts[1],
            project.Contacts[4]
        };
        var expectedContactsWithDigitsSubstring = new List<Contact>()
        {
            project.Contacts[2],
            project.Contacts[3]
        };

        // Act
        var actualContactsWithLettersSubstring = project.SearchBySubstring(project.Contacts, "Ohn");
        var actualContactsWithDigitsSubstring = project.SearchBySubstring(project.Contacts, "16");

        // Assert
        Assert.Multiple(() =>
        {
            CollectionAssert.AreEqual(
                expectedContactsWithLettersSubstring, actualContactsWithLettersSubstring);
            CollectionAssert.AreEqual(
                expectedContactsWithDigitsSubstring, actualContactsWithDigitsSubstring);
        });
    }
}