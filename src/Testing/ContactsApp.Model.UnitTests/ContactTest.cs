using System.Diagnostics;

namespace ContactsApp.Model.UnitTests;

[TestFixture]
public class ContactTest
{
    [Test(Description = "Проверка конструктора без параметров.")]
    public void EmptyConstructor()
    {
        string expectedFullName = null;
        string expectedEmail = null;
        string expectedPhoneNumber = null;
        var expectedDateOfBirth = DateTime.Today;
        string expectedVkId = null;

        var contact = new Contact();

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
    public void ConstructorWithParameters()
    {
        var expectedFullName = "Логинова Мирослава Артёмовна";
        var expectedEmail = "loginova@mail.expected";
        var expectedPhoneNumber = "+1 (234) 567 89";
        var expectedDateOfBirth = new DateTime(1993, 9, 19);
        var expectedVkId = "https://vk.com/loginova";

        var contact = new Contact(
            expectedFullName, expectedEmail, expectedPhoneNumber, expectedDateOfBirth, expectedVkId);

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
    public void CloneContact()
    {
        var expectedFullName = "Логинова Мирослава Артёмовна";
        var expectedEmail = "loginova@mail.expected";
        var expectedPhoneNumber = "+1 (234) 567 89";
        var expectedDateOfBirth = new DateTime(1993, 9, 19);
        var expectedVkId = "https://vk.com/loginova";
        var contact = new Contact(
            expectedFullName, expectedEmail, expectedPhoneNumber, expectedDateOfBirth, expectedVkId);
        
        var clone = (Contact)contact.Clone();

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
}