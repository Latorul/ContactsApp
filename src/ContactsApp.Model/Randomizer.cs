namespace ContactsApp.Model;

public class Randomizer : IRandomize
{
    public int Next(int maxValue)
    {
        return new Random().Next(maxValue);
    }

    public int Next(int minValue, int maxValue)
    {
        return new Random().Next(minValue, maxValue);
    }
}