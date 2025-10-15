namespace AzubiDemo;

public class HintsInit
{
    private Hints crossSum= new Hints
    {
        Name = "CrossSum",
        Description = "The sum of my number",
        GeneratorFunction = HintsGenerator.GetCrossSumHint 
    };
    private Hints range = new Hints
    {
        Name = "Range",
        Description = "range of numbers",
        GeneratorFunction = HintsGenerator.GetRangeHint
    };
    private Hints firstDigit = new Hints
    {
        Name = "FirstDigit",
        Description = "the first digit of the number",
        GeneratorFunction = HintsGenerator.GetFirstDigitHint
    };
    

    public List<Hints> Hints { get; init; } = new();

    public HintsInit()
    {
        Hints.Add(crossSum);
        Hints.Add(range);
        Hints.Add(firstDigit);
    }
}