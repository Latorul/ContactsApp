namespace ContactsApp.Model;

/// <summary>
/// Контакт.
/// </summary>
public class Contact : ICloneable
{
    /// <summary>
    /// Допустимые символы для номера телефона.
    /// </summary>
    private const string ValidPhoneNumberChars = "1234567890 +-()";

    /// <summary>
    /// Максимальная длина для ФИО.
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
    /// Самый ранний год даты рождения.
    /// </summary>
    private const int MinDateOfBirthYear = 1900;

    /// <summary>
    /// Фио.
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
    private DateTime _dateOfBirth;

    /// <summary>
    /// Ссылка на ВКонтакте.
    /// </summary>
    private string _vkId;


    /// <summary>
    /// Возвращает или задаёт ФИО.
    /// </summary>
    public string FullName
    {
        get => _fullName;
        set
        {
            Validator.AssertOnStringLength(value, MaxFullNameLength, nameof(FullName));

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            //todo разобраться с ирландскими МакКтото / McKtoto
            //value.ToLower() предотвращает написание ФИО полностью заглавными буквами
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
            if (value.Any(c => !ValidPhoneNumberChars.Contains(c)))
            {
                //todo поменять сообщение на "номер телефона должен быть в таком формате +7 (900) 123 45-67"
                throw new ArgumentException(
                    "Номер телефона может содержать только цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’");
            }

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
            Validator.AssertOnDateGap(value, MinDateOfBirthYear);
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

    /// <summary>
    /// Конструктор класса <see cref="Contact"/>
    /// </summary>
    public Contact() : this("", "", "", DateTime.Today, "")
    {
    }

    /// <summary>
    /// Конструктор класса <see cref="Contact"/>.
    /// </summary>
    /// <param name="fullName">ФИО.</param>
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