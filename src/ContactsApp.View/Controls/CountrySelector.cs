namespace ContactsApp.View.Controls;

public sealed class CountrySelector : ComboBox
{
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();

        if (e.Index != -1 && 
            e.Index < Items.Count)
        {
            CountryDropDownItem item = (CountryDropDownItem)Items[e.Index];

            e.Graphics.DrawImage(item.Image, e.Bounds.Left + 1, e.Bounds.Top + 1);
            e.Graphics.DrawString(item.CountryInfo.Name, e.Font, new SolidBrush(e.ForeColor), 
                e.Bounds.Left + item.Image.Width + 2, e.Bounds.Top);
        }

        base.OnDrawItem(e);
    }
}