using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas;
using System.Linq;

namespace KatasTests
{
    [TestClass]
    public class FabricaTests
    {
        Fabrica f;

        [TestInitialize]
        public void TestInitialize()
        {
            f = new Fabrica("Nueva Fabrica");
        }

        [TestMethod]
        public void ShouldHaveExpectedNameWhenItIsCreated()
        {
            //Given

            //When            

            //Then
            Assert.AreEqual(f.Name, "Nueva Fabrica");
        }

        [TestMethod]
        public void ShouldntHaveBombillasWhenItsCreated()
        {
            //When
            
            //Then
            Assert.IsTrue(f.BombillasTotal() == 0);
        }

        [TestMethod]
        public void CreateBombillaShouldAddANewBombillaWithSpecifiedCharacteristics()
        {
            //Given            

            //when
            f.CreateBombilla("",Enums.TypeBombilla.Halogena, 2000);

            //Then
            Assert.AreEqual(f.Bombillas[0].Type, Enums.TypeBombilla.Halogena);
            Assert.AreEqual(f.Bombillas[0].Lumens, 2000);
        }

        [TestMethod]
        public void BombillasTotalShouldReturnTheTotalAmountOfBombillas()
        {
            //Given            
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);

            //When
            int totalBobillas = f.BombillasTotal();

            //Then
            Assert.AreEqual(totalBobillas, 3);
        }

        [TestMethod]
        public void BombillasTotalTypeShouldReturnTotalAmountOfBombillasPerType()
        {
            //Given            
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);

            f.CreateBombilla("",Enums.TypeBombilla.Halogena, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Halogena, 0);

            //When
            var totalHalogenas = f.BombillasTotalType(Enums.TypeBombilla.Halogena);
            int totalLed = f.BombillasTotalType(Enums.TypeBombilla.Led);

            //Then
            Assert.AreEqual(totalHalogenas, 2);
            Assert.AreEqual(totalLed, 3);
        }


        [TestMethod]
        public void RepairBombillaShouldSetBombillaIsBrokenToFalse()
        {
            //Given
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.Bombillas[0].IsBroken = true;

            //When
            f.RepairBombilla(f.Bombillas[0]);

            //Then
            Assert.IsFalse(f.Bombillas[0].IsBroken);
        }


        [TestMethod]
        public void RepairBombillasShouldSetIsBrokenFalseToAllBrokenOnes()
        {
            //Given
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("",Enums.TypeBombilla.Halogena, 0);
            foreach (var b in f.Bombillas)
            {
                b.IsBroken = true;
            }
            f.CreateBombilla("",Enums.TypeBombilla.Halogena, 0);                        
            int howManyRepairs;

            //When
            howManyRepairs = f.RepairBombillas(f.Bombillas);            

            //Then
            Assert.IsFalse(f.Bombillas.Any(b => b.IsBroken));
            Assert.AreEqual(howManyRepairs, 3);
        }

        [TestMethod]
        public void CreateBombillaShouldAllowToSetLote()
        {
            //Given

            //When
            f.CreateBombilla("L8001", Enums.TypeBombilla.Led, 0);

            //Then
            Assert.AreEqual("L8001", f.Bombillas[0].Lote);
        }

        [TestMethod]
        public void SendBombillasShouldRemoveBombillasWithSpecificLoteFromOurFabrica()
        {
            //Given
            f.CreateBombilla("L8001", Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("L4001", Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("L5001", Enums.TypeBombilla.Led, 0);
            f.CreateBombilla("L8001", Enums.TypeBombilla.Led, 0);

            //when
            f.SendBombillas("L5001");

            //then
            Assert.AreEqual(3, f.BombillasTotal());

        }

    }
}
