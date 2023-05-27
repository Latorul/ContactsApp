namespace ContactsApp.Model;

public class FakeRandomizer : IRandomize
{
    
    public int Next(int maxValue)
    {
        return maxValue;
    }

    public int Next(int minValue, int maxValue)
    {
        return maxValue;
    }
}