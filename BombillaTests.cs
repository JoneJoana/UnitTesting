using Katas;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KatasTests
{
    [TestClass()]
    public class BombillaTests
    {

        Bombilla b = new Bombilla("");

        [TestMethod()]       
        public void WhenCreatedShouldBeOfTypeLed()
        {
            //Given

            //When  

            //Then
            Assert.AreEqual(Enums.TypeBombilla.Led, b.Type);            
        }

        [TestMethod()]
        public void WhenCreatedShouldHave800Lumens()
        {            
            Assert.AreEqual(800, b.Lumens);
        }

        [TestMethod()]
        public void IsBrokenShouldReturnTrueWhenBombillaIsBroken()
        {
            //Given            
            b.IsBroken = true;

            //When
            bool isBroken = b.IsBroken;

            //Then
            Assert.IsTrue(isBroken);
        }

        [TestMethod()]
        public void ShouldHaveTypeAndLumensDesignedByUser()
        {
            Bombilla b1 = new Bombilla("",Enums.TypeBombilla.Halogena,1000);
            
            Assert.AreEqual(Enums.TypeBombilla.Halogena, b1.Type);
            Assert.AreEqual(1000, b1.Lumens);
        }

        [TestMethod()]
        public void IsBrokenShouldReturnFalseWhenIsCreated()
        {
            b = new Bombilla("");
            Assert.IsTrue(!b.IsBroken);
        }

        [TestMethod()]
        public void ShouldBeIdentifiedByASpecificLote()
        {
            //Given

            //When
            b = new Bombilla("L5001");
            Bombilla c = new Bombilla("H8001");

            //Then
            Assert.AreEqual("L5001", b.Lote);
            Assert.AreEqual("H8001", c.Lote);

        }



    }
}
