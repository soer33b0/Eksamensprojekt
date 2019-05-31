using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DomainLayer;
using UI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SaveInvoice()
        {
            Controller controller = new Controller();
            bool save = controller.SaveInvoice("10/10/2019", 28321, "Faktura titel", "47", "120", 5640, "Test-beskrivelse", "/test/test/", 3);
            Assert.IsTrue(save);
        }
        [TestMethod]
        public void GetFilePath()
        {
            InvoiceGen invoiceGen = new InvoiceGen();
            string filepath = invoiceGen.Filepath();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Fakturaer";
            Assert.AreEqual(path, filepath);
        }

    }
}
