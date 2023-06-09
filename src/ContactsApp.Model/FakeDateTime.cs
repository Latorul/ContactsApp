namespace ContactsApp.Model;

public class FakeDateTime: IDateTime
{
    public DateTime Today => new(2003, 12, 11);
}