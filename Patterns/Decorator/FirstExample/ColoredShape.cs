namespace Patterns.Decorator.FirstExample
{
    // dynamic
    public class ColoredShape : Shape
    {
        private readonly Shape shape;
        private readonly string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }
        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }
}
