namespace ContactsApp.View.Controls;

public sealed class DropDownItem
{
    private readonly Size _flagSize = new Size(21, 15);

    public string Value { get; set; }

    public Image Image { get; set; }


    public DropDownItem() : this("", "")
    {
    }

    public DropDownItem(string flag, string country)
    {
        Value = country;
        Image = new Bitmap(
            (Image)Properties.Resources.ResourceManager.GetObject(flag)!,
            _flagSize);
    }

    public override string ToString() => Value;
}