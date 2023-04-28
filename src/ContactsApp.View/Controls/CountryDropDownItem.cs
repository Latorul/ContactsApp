namespace ContactsApp.View.Controls;

/// <summary>
/// Элемент в выпадающем списке <see cref="CountrySelector"/>.
/// </summary>
public sealed class CountryDropDownItem
{
    /// <summary>
    /// Размеры изображения флага.
    /// </summary>
    private readonly Size _flagSize = new Size(21, 15);

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
    /// Возвращает буквенный код страны.
    /// </summary>
    /// <returns>Буквенный код.</returns>
    public override string ToString() => CountryInfo.Code;
}