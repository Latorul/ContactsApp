﻿namespace ContactsApp.View;

public sealed class CountrySelector : ComboBox
{
    public CountrySelector()
    {
        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();

        e.DrawFocusRectangle();

        if (e.Index >= 0 && e.Index < Items.Count)
        {
            DropDownItem item = (DropDownItem)Items[e.Index];

            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);

            e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);
        }

        base.OnDrawItem(e);
    }
}

public sealed class DropDownItem
{
    public string Value { get; set; }

    public Image Image { get; set; }

    public DropDownItem()
        : this("")
    { }

    public DropDownItem(string val)
    {
        Value = val;
        Image = new Bitmap(16, 16);
        using (Graphics g = Graphics.FromImage(Image))
        {
            using (Brush b = new SolidBrush(Color.FromName(val)))
            {
                g.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
                g.FillRectangle(b, 1, 1, Image.Width - 1, Image.Height - 1);
            }
        }
    }

    public override string ToString() => Value;
}