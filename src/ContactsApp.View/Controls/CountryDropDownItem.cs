namespace ContactsApp.View.Controls;

/// <summary>
/// Элемент в выпадающем списке <see cref="CountrySelector"/>.<para/>
/// https://stackoverflow.com/a/9706102/18739226
/// </summary>
public sealed class CountryDropDownItem
{
    /// <summary>
    /// Размеры изображения флага.
    /// </summary>
    private readonly Size _flagSize = new(21, 15);

    /// <summary>
    /// Флаг страны.
    /// </summary>
    public Image Image { get; }
    
    /// <summary>
    /// Информация о стране.
    /// </summary>
    public CountryInfo CountryInfo { get; }


    /// <summary>
    /// Конструктор класса <see cref="CountryDropDownItem"/>.
    /// </summary>
    /// <param name="countryInfo">Информация о стране.</param>
    public CountryDropDownItem(CountryInfo countryInfo)
    {
        CountryInfo = countryInfo;
        Image = new Bitmap(
            (Image)Properties.Resources.ResourceManager.GetObject(CountryInfo.Code)!,
            _flagSize);
    }

    /// <summary>
    /// Возвращает телефонный код страны.
    /// </summary>
    /// <returns>Телефонный код.</returns>
    public override string ToString() => CountryInfo.PhoneCode;
}