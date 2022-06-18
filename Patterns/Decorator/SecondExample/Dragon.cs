namespace Patterns.Decorator.SecondExample
{
    public class Dragon : IBird, ILizard
    {
        private readonly IBird bird;
        private readonly ILizard lizard;

        public Dragon(IBird bird, ILizard lizard)
        {
            this.bird = bird;
            this.lizard = lizard;
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }

        public string Fly()
        {
            return bird.Fly();
        }
        public int Age
        {
            get => bird.Age;
            set => bird.Age = lizard.Age = value;
        }
    }
}
