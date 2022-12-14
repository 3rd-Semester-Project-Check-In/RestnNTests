using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOgTests.DBContext;
using RestOgTests.Managers;
using RestOgTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOgTestsTests1.Managers
{
    public class KortManagerTests
    {
        KortManager manager = new KortManager();


        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Kort> korts = manager.GetAll();
            Assert.IsNotNull(korts);
            Assert.AreEqual(2, korts.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Kort korts = manager.GetById(1);
            Assert.AreEqual("Casper", korts.Kort_Ejer);
            Assert.IsNotNull(manager.GetById(1));
        }



        [TestMethod()]
        public void AddTest()
        {
            Kort newKort = new Kort { CardId = 4, Kort_Ejer = "Random" };
            Kort addedKort = manager.Add(newKort);
            Assert.AreEqual("D3.11", addedKort.CardId);
            Assert.AreEqual(3, manager.GetAll().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Kort updates = new Kort {CardId = 1, Kort_Ejer = "Casperrr" };
            Kort updatedKort = manager.Update(1, updates);
            Assert.AreEqual(1, updatedKort.CardId);
            Assert.AreEqual("Casperrr", updatedKort.Kort_Ejer);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Kort deletedKort = manager.Delete(2);
            Assert.AreEqual(2, deletedKort.CardId);
            Assert.AreEqual(2, manager.GetAll().Count());
        }
    }
}
