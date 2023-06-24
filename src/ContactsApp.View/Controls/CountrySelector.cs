namespace ContactsApp.View.Controls;

/// <summary>
/// Выпадающий список, элементы которого содержат флаг и название страны.<para/>
/// https://stackoverflow.com/a/9706102/18739226
/// </summary>
public sealed class CountrySelector : ComboBox
{
    /// <summary>
    /// Отступ от краёв до флага.
    /// </summary>
    private const int ImageMargin = 1;

    /// <summary>
    /// Отступ между флагом и названием страны.
    /// </summary>
    private const int TextMargin = 2;


    /// <summary>
    /// Отрисовывает элемент выпадающего списка.
    /// </summary>
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();

        if (e.Index != -1 &&
            e.Index < Items.Count)
        {
            var item = (CountryDropDownItem)Items[e.Index];

            var flagLocation = new Point()
            {
                X = e.Bounds.Left + ImageMargin,
                Y = e.Bounds.Top + ImageMargin
            };
            var stringLocation = new Point()
            {
                X = e.Bounds.Left + item.Image.Width + TextMargin,
                Y = e.Bounds.Top
            };

            e.Graphics.DrawImage(item.Image, flagLocation);
            e.Graphics.DrawString(item.CountryInfo.Name, e.Font,
                new SolidBrush(e.ForeColor), stringLocation);
        }

        base.OnDrawItem(e);
    }
}