namespace Patterns.Decorator.FirstExample
{
    public sealed class Circle : Shape
    {
        private float radius;

        public Circle()
        {
            this.radius = 0;
        }
        public Circle(float radius)
        {
            this.radius = radius;
        }
        public void Resize(float factor)
        {
            radius *= factor;
        }
        public override string AsString() => $"A circle of radius {radius}";
    }
}
