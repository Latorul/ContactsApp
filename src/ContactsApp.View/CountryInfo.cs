namespace ContactsApp.View;

/// <summary>
/// Содержит информацию о странах: название, буквенный код, телефонный код.
/// </summary>
public class CountryInfo
{
    /// <summary>
    /// Название страны.
    /// </summary>
    public string Country { get; set; }
    
    /// <summary>
    /// Буквенный код.
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// Телефонный код.
    /// </summary>
    public string PhoneCode { get; set; }
    
    public string CountryLocal { get; set; }

    /// <summary>
    /// Конструктор класса <see cref="CountryInfo"/>.
    /// </summary>
    /// <param name="country">Название страны.</param>
    /// <param name="code">Буквенный код.</param>
    /// <param name="phoneCode">Телефонный код.</param>
    public CountryInfo(string country, string countryLocal, string code, string phoneCode)
    {
        Country = country;
        CountryLocal = countryLocal;
        Code = code;
        PhoneCode = phoneCode;
    }

    /// <summary>
    /// Загружает информацию о странах из файла.
    /// </summary>
    /// <returns>Список с информацией по каждой стране.</returns>
    public static List<CountryInfo> LoadInfo()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var info = Encoding.Default.GetString(Properties.Resources.countries);

        return JsonSerializer.Deserialize<List<CountryInfo>>(info, options)!;
    }
}