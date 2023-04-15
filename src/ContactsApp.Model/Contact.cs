﻿using System.Globalization;

namespace ContactsApp.Model;

/// <summary>
/// Контакт.
/// </summary>
public class Contact : ICloneable
{
    /// <summary>
    /// Допустимые символы для номера телефона.
    /// </summary>
    private static readonly string ValidPhoneNumberChars = "1234567890 +-()";

    /// <summary>
    /// Макимальная длина для ФИО.
    /// </summary>
    private static readonly int MaxFullNameLength = 100;

    /// <summary>
    /// Макимальная длина для электроной почты.
    /// </summary>
    private static readonly int MaxEmailLength = 100;

    /// <summary>
    /// Макимальная длина для ссылки на ВКонтакте.
    /// </summary>
    private static readonly int MaxVkIdLength = 50;

    /// <summary>
    /// Фио.
    /// </summary>
    private string _fullName;

    /// <summary>
    /// Возвращает или задаёт ФИО.
    /// </summary>
    public string FullName
    {
        get { return _fullName; }
        set
        {
            if (value.Length > MaxFullNameLength)
            {
                throw new ArgumentException(
                    $"ФИО не может быть длиннее {MaxFullNameLength} символов");
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            //value.ToLower() предотвращает написание ФИО полностью заглавными буквами
            _fullName = textInfo.ToTitleCase(value.ToLower());
        }
    }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    private string _email;

    /// <summary>
    /// Возвращает или задаёт электронную почту.
    /// </summary>
    public string Email
    {
        get { return _email; }
        set
        {
            if (value.Length > MaxEmailLength)
            {
                throw new ArgumentException(
                    $"E-mail не может быть длиннее {MaxEmailLength} символов");
            }
            _email = value;
        }
    }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    private string _phoneNumber;

    /// <summary>
    /// Возвращает или задаёт номер телефона.
    /// </summary>
    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            foreach (char c in value)
            {
                if (!ValidPhoneNumberChars.Contains(c))
                {
                    throw new ArgumentException(
                        "Номер телефона может содержать только цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’");
                }
            }

            _phoneNumber = value;
        }
    }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    private DateTime _dateOfBirth;

    /// <summary>
    /// Возвращает или задаёт дату рождения.
    /// </summary>
    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set
        {
            if (value.CompareTo(DateTime.Now) > 0)
            {
                throw new ArgumentException(
                    "Дата рождения не может быть позже текущей даты");
            }
            if (value.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new ArgumentException(
                    "Дата рождения не может быть раньше 1900 года");
            }

            _dateOfBirth = value;
        }
    }

    /// <summary>
    /// Ссылка на ВКонтакте.
    /// </summary>
    private string _vkId;

    /// <summary>
    /// Возвращает или задаёт ссылку на ВКонтакте.
    /// </summary>
    public string VkId
    {
        get { return _vkId; }
        set
        {
            if (value.Length > MaxVkIdLength)
            {
                throw new ArgumentException(
                    $"ID ВКонтакте не может быть длиннее {MaxVkIdLength}-ти символов");
            }
            _vkId = value;
        }
    }

    /// <summary>
    /// Контструкор класса <see cref="Contact"/>.
    /// </summary>
    public Contact()
    {

    }

    /// <summary>
    /// Контструкор класса <see cref="Contact"/>.
    /// </summary>
    /// <param name="fullname">ФИО</param>
    /// <param name="email">Электроная почта</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="dateOfBirth">Дата рождения</param>
    /// <param name="vkId">Ссылка на ВКонтакте</param>
    public Contact(
        string fullname, 
        string email, 
        string phoneNumber, 
        DateTime dateOfBirth, 
        string vkId)
    {
        FullName = fullname;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        _vkId = vkId;
    }


    /// <summary>
    /// Возвращает копию контакта.
    /// </summary>
    public object Clone()
    {
        return new Contact(FullName, Email, PhoneNumber, DateOfBirth, VkId);
    }
}
