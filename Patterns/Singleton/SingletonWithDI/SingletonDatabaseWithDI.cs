namespace Patterns.Singleton.SingletonWithDI
{
    public class SingletonDatabaseWithDI : IDatabase
    {
        private string[] _capitals;

        public SingletonDatabaseWithDI()
        {
            _capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(SingletonDatabaseWithDI).Assembly.Location).DirectoryName, "capitals.txt"
                    )
                );
        }

        public int GetPopulation()
        {
            return Convert.ToInt32(_capitals[1]);
        }
    }
}
