namespace ContactsApp.Model;

/// <summary>
/// Контакт.
/// </summary>
public class Contact : ICloneable
{
    /// <summary>
    /// Максимальная длина для полного имени.
    /// </summary>
    private const int MaxFullNameLength = 100;

    /// <summary>
    /// Максимальная длина для электронной почты.
    /// </summary>
    private const int MaxEmailLength = 100;

    /// <summary>
    /// Максимальная длина для ссылки на ВКонтакте.
    /// </summary>
    private const int MaxVkIdLength = 50;

    /// <summary>
    /// Полное имя.
    /// </summary>
    private string _fullName;

    /// <summary>
    /// Электронная почта.
    /// </summary>
    private string _email;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    private string _phoneNumber;

    /// <summary>
    /// Дата рождения.
    /// </summary>
    private DateTime _dateOfBirth = DateTime.Today;

    /// <summary>
    /// Ссылка на ВКонтакте.
    /// </summary>
    private string _vkId;


    public static IDateTime DateTime { get; set; }

    /// <summary>
    /// Возвращает или задаёт полное имя.
    /// </summary>
    public string FullName
    {
        get => _fullName;
        set
        {
            Validator.AssertOnStringLength(value, MaxFullNameLength, nameof(FullName));

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            //value.ToLower() предотвращает написание полного имени полностью заглавными буквами
            _fullName = textInfo.ToTitleCase(value.ToLower());
        }
    }

    /// <summary>
    /// Возвращает или задаёт электронную почту.
    /// </summary>
    public string Email
    {
        get => _email;
        set
        {
            Validator.AssertOnStringLength(value, MaxEmailLength, nameof(Email));
            _email = value;
        }
    }

    /// <summary>
    /// Возвращает или задаёт номер телефона.
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            Validator.AssertOnPhoneNumberFormat(value);
            _phoneNumber = value;
        }
    }

    /// <summary>
    /// Возвращает или задаёт дату рождения.
    /// </summary>
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            Validator.DateTime = DateTime;
            Validator.AssertOnDateGap(value);
            _dateOfBirth = value;
        }
    }

    /// <summary>
    /// Возвращает или задаёт ссылку на ВКонтакте.
    /// </summary>
    public string VkId
    {
        get => _vkId;
        set
        {
            Validator.AssertOnStringLength(value, MaxVkIdLength, nameof(VkId));
            _vkId = value;
        }
    }

    static Contact()
    {
        DateTime ??= new RealDateTime();
    }

    /// <summary>
    /// Конструктор класса <see cref="Contact"/>.
    /// </summary>
    public Contact()
    {
    }

    /// <summary>
    /// Конструктор класса <see cref="Contact"/>.
    /// </summary>
    /// <param name="fullName">Полное имя.</param>
    /// <param name="email">Электронная почта.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="dateOfBirth">Дата рождения.</param>
    /// <param name="vkId">Ссылка на ВКонтакте.</param>
    public Contact(
        string fullName,
        string email,
        string phoneNumber,
        DateTime dateOfBirth,
        string vkId)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        VkId = vkId;
    }


    /// <summary>
    /// Возвращает копию контакта.
    /// </summary>
    public object Clone()
    {
        return new Contact(FullName, Email, PhoneNumber, DateOfBirth, VkId);
    }
}