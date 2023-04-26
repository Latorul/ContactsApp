﻿namespace ContactsApp.View.Controls;

public sealed class CountrySelector : ComboBox
{
    public CountrySelector()
    {
        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;
        ItemHeight = 17;
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();

        if (e.Index != -1 && 
            e.Index < Items.Count)
        {
            DropDownItem item = (DropDownItem)Items[e.Index];

            e.Graphics.DrawImage(item.Image, e.Bounds.Left + 1, e.Bounds.Top + 1);
            e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), 
                e.Bounds.Left + item.Image.Width + 2, e.Bounds.Top);
        }

        base.OnDrawItem(e);
    }
}