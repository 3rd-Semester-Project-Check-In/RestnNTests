using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOgTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOgTests.Models.Tests
{
    [TestClass()]
    public class LokaleTests
    {
        private Lokale LokaleNoFail = new Lokale("D02.08", false);
        private Lokale LokaleIdNull = new Lokale(null, false);
        private Lokale LokaleIdLow = new Lokale("", false);
        private Lokale LokaleIdHigh = new Lokale("pajfæoksajffæokdsajjdfjljfjfjjidsajidfjpefjoifjsapodifjojoifjwapoeifjwaifjaoifjsadjsapodjsadifjdsaifjsadifdsafjsadifheapoifhseufhepoifwphwaefpohsadpfifilhdsfpiusadhfpiusadhfhdfpihdsafiuasdfiuasdhiusahdfiusahdfiudsahfpiuhdsafiusadhfpiudsahfpudsahfpiusadhfiudsahfiudsahfpiusadhfpiusadhfiaushfpisaudhfpiaudshfpisadhfpuadshfpusahdfpusahdfpudsahfpisudafhpaudsfhpiausdhfpiausdhfåpaudshfpusadhfiasdhfaisudfhpisaudhfapsiudhfpisaudfhpiudsahfpiueahfdsahpiusadhfpiausdhfpidsahfpiusHDFPIUDSA", false);


        [TestMethod()]
        public void ToStringTest()
        {
            // Act
            string str = LokaleNoFail.ToString();

            // Assert
            Assert.AreEqual("{LokaleId=D02.08, Occupied=False}", str);
        }

        [TestMethod]
        public void StandardPropertyTest()
        {
            try
            {
                // Act
                LokaleNoFail.Validate();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void ValidateLokaleIdNullTest()
        {
            // Assert
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdNull.ValidateLokaleId());
        }

        [TestMethod]
        public void ValidateLokaleIdLowTest()
        {
            // Assert
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdLow.ValidateLokaleId());
        }

        [TestMethod]
        public void ValidateLokaleIdHighTest()
        {
            // Assert
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdHigh.ValidateLokaleId());
        }

        [TestMethod]
        public void ValidateTest()
        {
            LokaleNoFail.Validate();
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdLow.Validate());
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdHigh.Validate());
            Assert.ThrowsException<IllegalLokaleIdException>(() => LokaleIdNull.Validate());

        }
    }
}