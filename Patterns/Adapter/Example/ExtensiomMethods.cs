namespace Patterns.Adapter.Example
{
    public static class ExtensiomMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }
}
