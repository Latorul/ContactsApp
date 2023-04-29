namespace ContactsApp.View;

/// <summary>
/// Содержит методы по генерации данных.
/// </summary>
public static class ContactFactory
{
    /// <summary>
    /// Добавляет контакты для проверки работоспособности программы.
    /// </summary>
    public static void GenerateContacts(Project project)
    {
        project.Contacts.Add(
            new()
            {
                FullName = "Филатов Мирон",
                Email = "filatov@mail.ru",
                PhoneNumber = "+1 (234) 567-89",
                DateOfBirth = DateTime.Today,
                VkId = "https://vk.com/filatov"
            });
        project.Contacts.Add(
            new()
            {
                FullName = "Ткачев Артём",
                Email = "tkachev@mail.ru",
                PhoneNumber = "+1 (234) 567-89",
                DateOfBirth = DateTime.Today,
                VkId = "https://vk.com/tkachev"
            });
        project.Contacts.Add(
            new()
            {
                FullName = "Козин Марк",
                Email = "kozin@mail.ru",
                PhoneNumber = "+1 (234) 567-89",
                DateOfBirth = DateTime.Today,
                VkId = "https://vk.com/kozin"
            });
        project.Contacts.Add(
            new()
            {
                FullName = "Журавлев Владимир",
                Email = "zhuravlev@mail.ru",
                PhoneNumber = "+1 (234) 567-89",
                DateOfBirth = DateTime.Today,
                VkId = "https://vk.com/zhuravlev"
            });
        project.Contacts.Add(
            new()
            {
                FullName = "Белоусов Андрей",
                Email = "belousov@mail.ru",
                PhoneNumber = "+1 (234) 567-89",
                DateOfBirth = DateTime.Today,
                VkId = "https://vk.com/belousov"
            });
    }
}
