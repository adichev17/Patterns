namespace Patterns.Decorator.SecondExample
{
    public class Bird : IBird
    {
        public int Age { get; set; }
        public string Fly()
        {
            if (Age >= 10)
                return ("I am flying!");
            return String.Empty;
        }
    }
}
