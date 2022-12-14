using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOgTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOgTestsTests1.Models
{
    public class KortTests
    {
        private Kort KortNoFail = new Kort(1, "Casper");
        private Kort CardIdNull = new Kort(int.Parse(null), "Mikkel");
        private Kort KortEjerNull = new Kort(2,null);
        private Kort KortEjerLow = new Kort(3, "");
        private Kort KortEjerHigh = new Kort(1,"pajfæoksajffæokdsajjdfjljfjfjjidsajidfjpefjoifjsapodifjojoifjwapoeifjwaifjaoifjsadjsapodjsadifjdsaifjsadifdsafjsadifheapoifhseufhepoifwphwaefpohsadpfifilhdsfpiusadhfpiusadhfhdfpihdsafiuasdfiuasdhiusahdfiusahdfiudsahfpiuhdsafiusadhfpiudsahfpudsahfpiusadhfiudsahfiudsahfpiusadhfpiusadhfiaushfpisaudhfpiaudshfpisadhfpuadshfpusahdfpusahdfpudsahfpisudafhpaudsfhpiausdhfpiausdhfåpaudshfpusadhfiasdhfaisudfhpisaudhfapsiudhfpisaudfhpiudsahfpiueahfdsahpiusadhfpiausdhfpidsahfpiusHDFPIUDSA");


        [TestMethod()]
        public void ToStringTest()
        {
            // Act
            string str = KortNoFail.ToString();

            // Assert
            Assert.AreEqual("{CardId=1, Kort_Ejer=Casper}", str);
        }

        [TestMethod]
        public void StandardPropertyTest()
        {
            try
            {
                // Act
                KortNoFail.Validate();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void ValidateCardIdNullTest()
        {
            // Assert
            Assert.ThrowsException<IllegalKortException>(() => CardIdNull.ValidateCardId());
        }

        [TestMethod]
        public void ValidateKortEjerNullTest()
        {
            // Assert
            Assert.ThrowsException<IllegalKortException>(() => KortEjerNull.ValidateKort_Ejer);
        }

        [TestMethod]
        public void ValidateKortEjerLowTest()
        {
            // Assert
            Assert.ThrowsException<IllegalKortException>(() => KortEjerLow.ValidateKort_Ejer());
        }

        [TestMethod]
        public void ValidateKortEjerHighTest()
        {
            // Assert
            Assert.ThrowsException<IllegalKortException>(() => KortEjerHigh.ValidateKort_Ejer());
        }

        [TestMethod]
        public void ValidateTest()
        {
            KortNoFail.Validate();
            Assert.ThrowsException<IllegalKortException>(() => KortEjerLow.Validate());
            Assert.ThrowsException<IllegalKortException>(() => KortEjerHigh.Validate());
            Assert.ThrowsException<IllegalKortException>(() => CardIdNull.Validate());
            Assert.ThrowsException<IllegalKortException>(() => KortEjerNull.Validate());
            Assert.ThrowsException<IllegalKortException>(() => KortNoFail.Validate());
        }
    }
}
