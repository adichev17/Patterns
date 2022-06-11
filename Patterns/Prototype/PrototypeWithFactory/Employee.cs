namespace Patterns.Prototype.PrototypeWithFactory
{
    [Serializable]
    public class Employee
    {
        public string Name;
        public Address Address;
        public Employee(string name, Address address)
        {
            Name = name ;
            Address = address;
        }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
