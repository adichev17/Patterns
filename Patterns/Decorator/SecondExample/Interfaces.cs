namespace Patterns.Decorator.SecondExample
{
    public interface ICreature
    {
        int Age { get; set; }
    }
    public interface IBird : ICreature
    {
        string Fly();
    }
    public interface ILizard : ICreature
    {
        string Crawl();
    }
}
