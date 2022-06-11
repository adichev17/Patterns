namespace Patterns.Prototype.PrototypeWithFactory
{
    [Serializable]
    public class Address
    {
        public string StreetAddress, City;
        public int Suite;
        public Address(string streetAddress, string city, int suite)
        {
            StreetAddress = streetAddress;
            City = city;
            Suite = suite;
        }
    }
}
