using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOgTests.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestOgTests.Models;

namespace RestOgTests.Managers.Tests
{
    [TestClass()]
    public class LokaleManagerTests
    {
        LokaleManager manager = new LokaleManager();


        [TestMethod()]
        public void GetAllTest()
        {
            List<Lokale> lokaler = manager.GetAll();
            Assert.IsNotNull(lokaler);
            Assert.AreEqual(2, lokaler.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Lokale lokaler = manager.GetById("D2.08");
            Assert.AreEqual(true, lokaler.Occupied);
            Assert.IsNotNull(manager.GetById("D2.08"));
        }



        [TestMethod()]
        public void AddTest()
        {
            Lokale newLokale = new Lokale { LokaleId = "D3.11", Occupied = false };
            Lokale addedLokale = manager.Add(newLokale);
            Assert.AreEqual("D3.11", addedLokale.LokaleId);
            Assert.AreEqual(3, manager.GetAll().Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Lokale updates = new Lokale { LokaleId = "D2.09", Occupied = false };
            Lokale updatedLokale = manager.Update("D2.08", updates);
            Assert.AreEqual(false, updatedLokale.Occupied);
            Assert.AreEqual("D2.09", updatedLokale.LokaleId);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Lokale deletedLokale = manager.Delete("D3.11");
            Assert.AreEqual("D3.11", deletedLokale.LokaleId);
            Assert.AreEqual(2, manager.GetAll().Count);
        }

    }
}