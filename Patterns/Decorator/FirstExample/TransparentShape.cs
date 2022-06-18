namespace Patterns.Decorator.FirstExample
{
    public class TransparentShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() =>
          $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
}
