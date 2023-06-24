namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ProjectTests
{
    [Test(Description = "Проверка конструктора без параметров.")]
    public void EmptyConstructor_ProjectCreated()
    {
        // Act
        var project = new Project();

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
        ContactFactory.DateTime = new FakeDater();
        project.Contacts.Add(ContactFactory.CreateContact());

        // Act
        var actualContacts = project.Contacts;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualContacts, Is.Not.Empty);
            Assert.That(expectedContacts, Is.EqualTo(actualContacts));
        });
    }

    [Test(Description = "Проверка сортировки списка контактов.")]
    public void SortByFullName_SortNotEmptyList_ListSorted()
    {
        // Setup
        var project = new Project();
        ContactFactory.Random = new FakeRandomizer();
        ContactFactory.DateTime = new FakeDater();
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

    [Test(Description = "Проверка сортировки пустого списка контактов.")]
    public void SortByFullName_SortEmptyList_ListStillEmpty()
    {
        // Setup
        var project = new Project();
        var expectedContacts = new List<Contact>();

        // Act
        var actualContacts = project.SortByFullName(project.Contacts);

        // Assert
        CollectionAssert.AreEqual(expectedContacts, actualContacts);
    }

    [Test(Description = "Проверка сортировки отсутствующего списка контактов.")]
    public void SortByFullName_SortNullList_ThrowsArgumentNullException()
    {
        // Setup
        var project = new Project(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(
            () =>
                // Act
                project.SortByFullName(project.Contacts),
            "Должно выбрасываться ArgumentNullException при передачи null в качестве списка контактов."
        );
    }

    [Test(Description = "Проверка поиска именинников.")]
    public void SearchBirthDayContacts_ThereAreBirthDayContacts_ReturnBirthDayContacts()
    {
        // Setup
        var project = FillProjectWithBirthDayContacts();

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

    [Test(Description = "Проверка поиска именинников без совпадения дат.")]
    public void SearchBirthDayContacts_ThereAreNotBirthDayContacts_ReturnEmptyList()
    {
        // Setup
        var project = FillProjectWithBirthDayContacts();

        // Act
        var actualContacts =
            project.SearchBirthDayContacts(project.Contacts, new DateTime(1900, 1, 1));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualContacts, Is.Not.Null);
            Assert.That(actualContacts, Is.Empty);
        });
    }

    [Test(Description = "Проверка поиска именинников в пустом списке.")]
    public void SearchBirthDayContacts_EmptyList_ReturnEmptyList()
    {
        // Setup
        var project = new Project();
        var expectedContacts = new List<Contact>();

        // Act
        var actualContacts =
            project.SearchBirthDayContacts(project.Contacts, Contact.DateTime.Today);

        // Assert
        CollectionAssert.AreEqual(expectedContacts, actualContacts);
    }

    [Test(Description = "Проверка поиска именинников в отсутствующем списке.")]
    public void SearchBirthDayContacts_NullList_ThrowsNullReferenceException()
    {
        // Setup
        var project = new Project(null!);

        // Assert
        Assert.Throws<NullReferenceException>(
            () =>
                // Act
                project.SearchBirthDayContacts(project.Contacts, Contact.DateTime.Today),
            "Должно выбрасываться NullReferenceException при передачи null в качестве списка контактов."
        );
    }

    [Test(Description = "Проверка поиска контактов по подстроке.")]
    public void SearchBySubstring_ThereAreContactsWithSubstring_ReturnedContactsWithSubstring()
    {
        // Setup
        var project = FillProjectWithContacts();

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

    [Test(Description = "Проверка поиска контактов по не совпадающей подстроке.")]
    public void SearchBySubstring_ThereAreNotContactsWithSubstring_ReturnedEmptyList()
    {
        // Setup
        var project = FillProjectWithContacts();

        // Act
        var actual = project.SearchBySubstring(project.Contacts, "It not empty");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
        });
    }

    [Test(Description = "Проверка поиска контактов по пустой подстроке.")]
    public void SearchBySubstring_EmptySubstring_ReturnedSameList()
    {
        // Setup
        var project = FillProjectWithContacts();
        var expected = project.Contacts;

        // Act
        var actual = project.SearchBySubstring(project.Contacts, "");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            CollectionAssert.AreEqual(expected, actual);
        });
    }

    [Test(Description = "Проверка поиска контактов по подстроке в пустом списке.")]
    public void SearchBySubstring_EmptyList_ReturnedEmptyList()
    {
        // Setup
        var project = new Project();

        // Act
        var actual = project.SearchBySubstring(project.Contacts, "Something");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
        });
    }

    [Test(Description = "Проверка поиска контактов по отсутствующей подстроке.")]
    public void SearchBySubstring_NullSubstring_ThrowNullReferenceException()
    {
        // Setup
        var project = FillProjectWithContacts();

        // Assert
        Assert.Throws<NullReferenceException>(() =>
            // Act
            project.SearchBySubstring(project.Contacts, null!),
            "Должно выбрасываться NullReferenceException при передачи null в качестве подстроки."
        );
    }

    [Test(Description = "Проверка поиска контактов по подстроке в отсутствующем списке.")]
    public void SearchBySubstring_NullList_ThrowNullReferenceException()
    {
        // Setup
        var project = new Project(null!);

        // Assert
        Assert.Throws<NullReferenceException>(() =>
            // Act
            project.SearchBySubstring(project.Contacts, "Something"),
            "Должно выбрасываться NullReferenceException при передачи null в качестве списка контактов."
        );
    }

    /// <summary>
    /// Заполняет список контактов данными для поиска по подстроке.
    /// </summary>
    /// <returns>Проект со списком заполненных контактов.</returns>
    private Project FillProjectWithContacts()
    {
        var contacts = new List<Contact>()
        {
            new("John Doe", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "VkId"),
            new("FullName", "johndoe@mail.com", "+1 (234) 567 89", new DateTime(1900, 1, 1), "vkId"),
            new("FullName", "Email", "+1 (234) 567 16", new DateTime(1900, 1, 1), "vkId"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(2002, 10, 16), "vkId"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "https://vk.com/johndoe"),
            new("FullName", "Email", "+1 (234) 567 89", new DateTime(1900, 1, 1), "vkId"),
        };
        return new Project(contacts);
    }
    
    /// <summary>
    /// Заполняет список контактов данными для поиска именинников.
    /// </summary>
    /// <returns>Проект со списком заполненных контактов.</returns>
    private Project FillProjectWithBirthDayContacts()
    {
        var project = new Project();
        ContactFactory.Random = new FakeRandomizer();
        ContactFactory.DateTime = new FakeDater();
        ContactFactory.GenerateContacts(project, 3);

        project.Contacts[0].DateOfBirth = Contact.DateTime.Today;
        project.Contacts[1].DateOfBirth = Contact.DateTime.Today.AddDays(-1);
        project.Contacts[2].DateOfBirth = Contact.DateTime.Today;
        
        return project;
    }
}