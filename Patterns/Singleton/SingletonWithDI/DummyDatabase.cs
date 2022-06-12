namespace Patterns.Singleton.SingletonWithDI
{
    public class DummyDatabase : IDatabase
    {
        public int GetPopulation()
        {
            return new Dictionary<string, int>
            {
                ["Moscow"] = 21000000,
            }["Moscow"];
        }
    }
}
