namespace ContactsApp.View.Controls;

public sealed class DropDownItem
{
    private readonly Size _flagSize = new Size(21, 15);

    private string Code { get; set; }

    public string Country { get; set; }

    public Image Image { get; set; }


    public DropDownItem() : this("", "")
    {
    }

    public DropDownItem(string code, string country)
    {
        Code = code;
        Country = country;
        Image = new Bitmap(
            (Image)Properties.Resources.ResourceManager.GetObject(Code)!,
            _flagSize);
    }

    public override string ToString() => Code;
}