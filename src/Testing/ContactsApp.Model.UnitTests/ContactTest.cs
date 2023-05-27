using System.Diagnostics;

namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ContactTest
{
    [Test(Description = "Проверка конструктора без параметров.")]
    public void EmptyConstructor_CreatedEmptyContact()
    {
        // Setup
        string expectedFullName = null!;
        string expectedEmail = null!;
        string expectedPhoneNumber = null!;
        var expectedDateOfBirth = DateTime.Today;
        string expectedVkId = null!;

        // Act
        var contact = new Contact();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(contact.FullName, Is.EqualTo(expectedFullName));
            Assert.That(contact.Email, Is.EqualTo(expectedEmail));
            Assert.That(contact.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
            Assert.That(contact.DateOfBirth, Is.EqualTo(expectedDateOfBirth));
            Assert.That(contact.VkId, Is.EqualTo(expectedVkId));
        });
    }

    [Test(Description = "Проверка конструктора с параметрами.")]
    public void ConstructorWithParameters_CreatedFilledContact()
    {
        // Setup
        var expectedFullName = "Логинова Мирослава Артёмовна";
        var expectedEmail = "loginova@mail.expected";
        var expectedPhoneNumber = "+1 (234) 567 89";
        var expectedDateOfBirth = new DateTime(1993, 9, 19);
        var expectedVkId = "https://vk.com/loginova";

        // Act
        var contact = new Contact(
            expectedFullName, expectedEmail, expectedPhoneNumber, expectedDateOfBirth, expectedVkId);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(contact.FullName, Is.EqualTo(expectedFullName));
            Assert.That(contact.Email, Is.EqualTo(expectedEmail));
            Assert.That(contact.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
            Assert.That(contact.DateOfBirth, Is.EqualTo(expectedDateOfBirth));
            Assert.That(contact.VkId, Is.EqualTo(expectedVkId));
        });
    }

    [Test(Description = "Проверка метода клонирования.")]
    public void CloneContact_ReturnSameContact()
    {
        // Setup
        var expectedFullName = "Логинова Мирослава Артёмовна";
        var expectedEmail = "loginova@mail.expected";
        var expectedPhoneNumber = "+1 (234) 567 89";
        var expectedDateOfBirth = new DateTime(1993, 9, 19);
        var expectedVkId = "https://vk.com/loginova";
        var contact = new Contact(
            expectedFullName, expectedEmail, expectedPhoneNumber, expectedDateOfBirth, expectedVkId);

        // Act
        var clone = (Contact)contact.Clone();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(clone, Is.Not.EqualTo(contact));
            Assert.That(clone.FullName, Is.EqualTo(expectedFullName));
            Assert.That(clone.Email, Is.EqualTo(expectedEmail));
            Assert.That(clone.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
            Assert.That(clone.DateOfBirth, Is.EqualTo(expectedDateOfBirth));
            Assert.That(clone.VkId, Is.EqualTo(expectedVkId));
        });
    }

    [Test(Description = "Проверка присвоения короткого имени.")]
    public void FullName_SetShortString_StringSet()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var expectedFullName = "John Doe";

        // Act
        contact.FullName = "john doe";
        var actualFullName = contact.FullName;

        // Assert
        Assert.That(expectedFullName, Is.EqualTo(actualFullName));
    }

    [Test(Description = "Проверка присвоения имени, выходящего за ограничение по символам.")]
    public void FullName_SetLongString_ThrowArgumentException()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var longFullName =
            "Hubert Blaine Wolfeschlegelsteinhausenbergerdorff, Sr." +
            "Hubert Blaine Wolfeschlegelsteinhausenbergerdorff, Sr.";

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                contact.FullName = longFullName,
            "Должно выбрасывать исключение при присвоении в FullName строки длиннее, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка присвоения короткой электронной почты.")]
    public void Email_SetShortString_StringSet()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var expectedEmail = "johndoe@mail.com";

        // Act
        contact.Email = expectedEmail;
        var actualEmail = contact.Email;

        // Assert
        Assert.That(expectedEmail, Is.EqualTo(actualEmail));
    }

    [Test(Description = "Проверка присвоения электронной почты, выходящей за ограничение по символам.")]
    public void Email_SetLongString_ThrowArgumentException()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var longEmail =
            "emailemailemailemailemailemailemailemail" +
            "emailemailemailemailemailemailemailemail" +
            "emailemailemailemailemailemailemailemail";

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                contact.Email = longEmail,
            "Должно выбрасывать исключение при присвоении в Email строки длиннее, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка присвоения номера телефона в правильном формате.")]
    [TestCase("+1 (234) 567-89")]
    [TestCase("+12 (345) 678 90 12 3")]
    [TestCase("+123 (456) 789 01-23-45")]
    [TestCase("+1234 (567) 890-12 34-56 7")]
    public void PhoneNumber_SetCorrectPhoneNumber_PhoneNumberSet(string expectedPhoneNumber)
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();

        // Act
        contact.PhoneNumber = expectedPhoneNumber;
        var actualPhoneNumber = contact.PhoneNumber;

        // Assert
        Assert.That(expectedPhoneNumber, Is.EqualTo(actualPhoneNumber));
    }

    [Test(Description = "Проверка присвоения неправильного номера телефона.")]
    [TestCase("+1 (234) 5678-9")]
    [TestCase("+12 345 678 90 12 3")]
    [TestCase("+123 (456) 789 01-23-45 67")]
    [TestCase("+12345 (678) 901-23 45-67 8")]
    public void PhoneNumber_SetInCorrectPhoneNumber_ThrowArgumentException(string incorrectPhoneNumber)
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        
        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                contact.PhoneNumber = incorrectPhoneNumber,
            "Должно выбрасывать исключение при присвоении в PhoneNumber номера телефона, " +
            "который не соответствует шаблону.");
    }
    
    [Test(Description = "Проверка присвоения даты рождения, входящей в разрешённый диапазон.")]
    [TestCase("1900-1-1", TestName = "Проверка нижней разрешённой границы даты.")]
    [TestCase("2002-10-16", TestName = "Проверка даты разрешённой между границами.")]
    public void DateOfBirth_SetCorrectDate_DateSet(DateTime expectedDateOfBirth)
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();

        // Act
        contact.DateOfBirth = expectedDateOfBirth;
        var actualDateOfBirth = contact.DateOfBirth;

        // Assert
        Assert.That(expectedDateOfBirth, Is.EqualTo(actualDateOfBirth));
    }
    
    [Test(Description = "Проверка присвоения сегодняшнего дня в дату рождения.")]
    public void DateOfBirth_SetToday_DateSet()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var expectedDateOfBirth = DateTime.Today;

        // Act
        contact.DateOfBirth = expectedDateOfBirth;
        var actualDateOfBirth = contact.DateOfBirth;

        // Assert
        Assert.That(expectedDateOfBirth, Is.EqualTo(actualDateOfBirth));
    }

    [Test(Description = "Проверка присвоения даты рождения, выходящей за разрешённый диапазон")]
    [TestCase("1899-12-31", TestName = "Проверка нижней границы даты.")]
    [TestCase("9999-12-31", TestName = "Проверка верхней границы даты.")]
    public void DateOfBirth_SetInCorrectDate_ThrowArgumentException(DateTime incorrectDateOfBirth)
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                contact.DateOfBirth = incorrectDateOfBirth,
            "Должно выбрасывать исключение при присвоении в DateOfBirth строки длиннее, " +
            "чем указанное максимальное значение.");
    }

    [Test(Description = "Проверка присвоения короткого ID ВКонтакте.")]
    public void VkId_SetShortString_StringSet()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var expectedVkId = "https://vk.com/vkid";

        // Act
        contact.VkId = expectedVkId;
        var actualEmail = contact.VkId;

        // Assert
        Assert.That(expectedVkId, Is.EqualTo(actualEmail));
    }

    [Test(Description = "Проверка присвоения ID ВКонтакте, выходящего за ограничение по символам.")]
    public void VkId_SetLongString_ThrowArgumentException()
    {
        // Setup
        ContactFactory.Random = new FakeRandomizer();
        var contact = ContactFactory.CreateContact();
        var longVkId =
            "vkidvkidvkidvkidvkidvkidvkidvkidvkidvkid" +
            "vkidvkidvkidvkidvkidvkidvkidvkidvkidvkid" +
            "vkidvkidvkidvkidvkidvkidvkidvkidvkidvkid";

        // Assert
        Assert.Throws<ArgumentException>(() =>
                // Act
                contact.VkId = longVkId,
            "Должно выбрасывать исключение при присвоении в VkId строки длиннее, " +
            "чем указанное максимальное значение.");
    }
}