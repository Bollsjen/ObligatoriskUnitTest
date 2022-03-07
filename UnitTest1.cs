using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave.Models;
using ObligatoriskOpgave.Exeptions;

namespace ObligatoriskUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CarConstructorTest()
        {
            Assert.IsInstanceOfType(new Car(1,"Model X", 399.95, "XD69420"), typeof(Car));
        }

        [TestMethod]
        [ExpectedException(typeof(ModelNotLongEnough))]
        public void CarConstructorModelTest()
        {
            Car car = new Car(1,"Mo", 399.95, "XD69420");
        }

        [TestMethod]
        [ExpectedException(typeof(PriceHasToBeMoreThanZero))]
        public void CarConstructorPriceIsZeroTest()
        {
            Car car = new Car(1,"Model X", 0, "XD69420");
            Car car1 = new Car(2,"Model X", -100, "XD69420");
        }

        [TestMethod]
        [ExpectedException(typeof(LicensePlateHasToBeInRange))]
        public void CarConstructorLicensePlateLessThan2CharactersTest()
        {
            Car car = new Car(1,"Model X", 399.95, "X");
            Car car1 = new Car(2,"Model X", 399.95, "XD694200");

        }

        [TestMethod]
        public void CarPropertiesTest()
        {
            Car car = new Car(1,"Model X", 399.95, "XD69420");
            string toString = car.ToString();
            Assert.ThrowsException<ModelNotLongEnough>(() => car.Model = "M");
            Assert.ThrowsException<PriceHasToBeMoreThanZero>(() => car.Price = 0);
            Assert.ThrowsException<PriceHasToBeMoreThanZero>(() => car.Price = -1);
            Assert.ThrowsException<LicensePlateHasToBeInRange>(() => car.LicensePlate = "X");
            Assert.ThrowsException<LicensePlateHasToBeInRange>(() => car.LicensePlate = "XD694200");
            Assert.AreEqual(toString, car.ToString());
        }

        [TestMethod]
        public void ExeptionPropertyTest()
        {
            try
            {
                Car car = new Car(1,"Mo", 399.95, "XD69420");
            }
            catch (ModelNotLongEnough e)
            {
                Assert.IsNotNull(e.Model);
            }

            try
            {
                Car car = new Car(1,"Model X", 0, "XD69420");
            }
            catch (PriceHasToBeMoreThanZero e)
            {
                Assert.IsNotNull(e.Price);
            }

            try
            {
                Car car = new Car(1,"Model X", 399.95, "X");
            }
            catch (LicensePlateHasToBeInRange e)
            {
                Assert.IsNotNull(e.LicensePlate);
            }
        } 
    }
}
