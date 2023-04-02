using System.Globalization;

namespace ContactsApp.Model;

/*- Класс «Контакт» с полями «Полное имя», «e-mail», «Номер телефона», «Дата рож-
дения», «e-mail», «ID ВКонтакте». Все поля доступны для изменений. Полное имя и e-mail
ограничены 100 символами каждое, ID Вконтакте ограничен 50 символами. Первая буква в
фамилии и имени должна преобразовываться к верхнему регистру. Дата рождения не может
быть более текущей даты и не может быть менее 1900 года. Номер телефона может содер-
жать только цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’. Допустимы контакты с одинаковыми именами.
Реализует интерфейс ICloneable.

 ArgumentException.*/

public class Contact : ICloneable
{
    private static readonly string VALIDPHONENUMBERCHARS = "1234567890 +-()";

    private string _fullName;

    public string FullName
    {
        get { return _fullName; }
        set
        {
            if (value.Length > 100)
            {
                throw new ArgumentException("ФИО не может быть длиннее 100 символов");
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            _fullName = textInfo.ToTitleCase(value);
        }
    }

    private string _email;

    public string Email
    {
        get { return _email; }
        set
        {
            if (value.Length > 100)
            {
                throw new ArgumentException("E-mail не может быть длиннее 100 символов");
            }
            _email = value;
        }
    }

    private string _phoneNumber;

    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            foreach (char c in value)
            {
                if (!VALIDPHONENUMBERCHARS.Contains(c))
                {
                    throw new ArgumentException("Номер телефона может содержать только цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’");
                }
            }

            _phoneNumber = value;
        }
    }

    private DateTime _dateOfBirth;

    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set
        {
            if(value.CompareTo(DateTime.Now) > 0)
            {
                throw new ArgumentException("Дата рождения не может быть более текущей даты");
            }
            if (value.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new ArgumentException("Дата рождения не может быть менее 1900 года");
            }

            _dateOfBirth = value;
        }
    }

    private string _vkId;

    public string VkId
    {
        get { return _vkId; }
        set
        {
            if (value.Length > 50)
            {
                throw new ArgumentException("ID ВКонтакте не может быть длиннее 50-ти символов");
            }
            _vkId = value;
        }
    }

    public Contact()
    {
        
    }

    public Contact(string fullname, string email, string phjoneNumber, DateTime dateOfBirth, string vkId)
    {
        FullName = fullname;
        Email = email;
        PhoneNumber = phjoneNumber;
        DateOfBirth = dateOfBirth;
        _vkId = vkId;
    }



    public object Clone()
    {
        return new Contact(FullName, Email, PhoneNumber, DateOfBirth, VkId);
    }
}
