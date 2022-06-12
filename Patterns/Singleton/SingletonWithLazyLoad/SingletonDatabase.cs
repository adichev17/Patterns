namespace Patterns.Singleton.WingletonWithLazyLoad
{
    public class SingletonDatabase
    {
        private string[] _capitals;

        private SingletonDatabase()
        {      
            _capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(SingletonDatabase).Assembly.Location).DirectoryName,"capitals.txt"
                    )
                );
        }

        public int GetPopulatin()
        {
            return Convert.ToInt32(_capitals[1]);
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }
}
