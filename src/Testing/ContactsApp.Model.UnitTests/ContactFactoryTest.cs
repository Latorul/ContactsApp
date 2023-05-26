namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ContactFactoryTest
{
    [Test(Description = "Проверка создания нового контакта со всеми заполненными полями.")]
    public void CreateContact_ReturnNewContact()
    {
        // Setup
        Contact actual =
            // Act
            ContactFactory.CreateContact();

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actual.FullName, Is.Not.Empty);
            Assert.That(actual.Email, Is.Not.Empty);
            Assert.That(actual.PhoneNumber, Is.Not.Empty);
            Assert.That(actual.DateOfBirth, Is.Not.EqualTo(default(DateTime)));
            Assert.That(actual.VkId, Is.Not.Empty);
        });
    }

    [Test(Description = "Проверка создания списка с некорректным количеством элементов.")]
    [TestCase(-1, 
        TestName = "Проверка создания списка контактов с отрицательным количеством элементов.")]
    [TestCase(0, 
        TestName = "Проверка создания списка контактов с нулевым количеством элементов.")]
    public void GenerateContacts_SetLessThanOneCount_ContactsNotAdded(int count)
    {
        // Setup
        var project = new Project();

        // Act
        ContactFactory.GenerateContacts(project, count);

        // Assert
        Assert.That(project.Contacts, Is.Not.Null);
        Assert.That(project.Contacts, Has.Count.Zero);
    }

    [Test(Description = "Проверка создания списка с корректным количеством элементов.")]
    [TestCase(1, TestName = "Проверка создания списка контактов с одним элементом.")]
    [TestCase(2, TestName = "Проверка создания списка контактов с несколькими элементами.")]
    public void GenerateContacts_SetPositiveCount_ContactsAdded(int count)
    {
        // Setup
        var project = new Project();

        // Act
        ContactFactory.GenerateContacts(project, count);

        // Assert
        Assert.That(project.Contacts, Is.Not.Null);
        Assert.That(project.Contacts, Has.Count.EqualTo(count));
    }

    [Test(Description = "Проверка создания списка контактов с количеством элементов по умолчанию.")]
    public void GenerateContacts_SetDefaultCount_ContactsAdded()
    {
        // Setup
        var project = new Project();

        // Act
        ContactFactory.GenerateContacts(project);

        // Assert
        Assert.That(project.Contacts, Is.Not.Null);
        Assert.That(project.Contacts, Has.Count.Not.Zero);
    }
}