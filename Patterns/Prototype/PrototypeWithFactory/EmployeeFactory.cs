namespace Patterns.Prototype.PrototypeWithFactory
{
    public class EmployeeFactory
    {
        private static Employee main = new Employee(null, new Address("123 East Dr", "London", 0));
        private static Employee aux = new Employee(null, new Address("123B East Dr", "London", 0));

        private static Employee NewEmployee(Employee proto, string name, int suite)
        {
            var copy = proto.DeepCopy();
            copy.Name = name;
            copy.Address.Suite = suite;
            return copy;
        }

        public static Employee NewMainOfficeEmployee(string name, int suite) => NewEmployee(main, name, suite);

        public static Employee NewAuxOfficeEmployee(string name, int suite) => NewEmployee(aux, name, suite);
    }
}
