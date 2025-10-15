namespace AzubiDemo;

public class Hints
{
    public string Name { get; init; }
    public string Description { get; init; }
    public Func<int, string> GeneratorFunction { get; init; } 
    
  // public Function { get; init; }

    //public string PropertyWithGetterAndSetter { get; set; }
}