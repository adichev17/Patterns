using NUnit.Framework;
using Patterns.Prototype.PrototypeWithFactory;

namespace PattersTests
{
    [TestFixture]
    public class PrototypeTests
    {
        //With ctor copy
        [Test]
        public void Test()
        {
            var firstEmployee = new Patterns.Prototype.PrototypeWithCtorCopy
                .Employee("Dmitriy", new Patterns.Prototype.PrototypeWithCtorCopy.Address("123 Street", "Moscow", 0));
            var secondEmployee = new Patterns.Prototype.PrototypeWithCtorCopy
                .Employee(firstEmployee);

            secondEmployee.Name = "New Name";
            secondEmployee.Address = new Patterns.Prototype.PrototypeWithCtorCopy.Address("New Address", "new streer", 1);

            Assert.AreNotEqual(firstEmployee.Name, secondEmployee.Name);
            Assert.AreNotEqual(firstEmployee.Address, secondEmployee.Address);
        }

        //With factory
        [Test]
        public void SecondTest()
        {
            var firstEmployee = EmployeeFactory.NewMainOfficeEmployee("Kerio", 10);
            Assert.IsNotNull(firstEmployee);
            Assert.That(firstEmployee.Name, Is.EqualTo("Kerio"));
        }
    }
}
