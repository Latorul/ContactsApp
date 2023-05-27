namespace ContactsApp.Model;

public interface IRandomize
{
    int Next(int maxValue);
    
    int Next(int minValue, int maxValue);
}