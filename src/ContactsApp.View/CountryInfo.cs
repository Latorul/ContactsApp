namespace ContactsApp.View;

/// <summary>
/// Содержит информацию о странах: название, буквенный код, телефонный код.
/// </summary>
public class CountryInfo
{
    /// <summary>
    /// Название страны.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Буквенный код.
    /// </summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// Телефонный код.
    /// </summary>
    public string PhoneCode { get; init; } = string.Empty;


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