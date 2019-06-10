using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandlers;
namespace XMLHandlerTest
{
    public class Class1
    {
        [Test]
        public void readTdesKeysTest()
        {
            XMLHandler fileHandler = new XMLHandler();
            string[] tdesExpected = { "Hi", "Good", "Moorning" };
            string[] tdesKeysReceived=fileHandler.readTdesKeys("C:\\Users\\jose.paniagua\\Desktop\\tdesKeys.xml");


            Assert.AreEqual(tdesExpected[0], tdesKeysReceived[0]);
            Assert.AreEqual(tdesExpected[1], tdesKeysReceived[1]);
            Assert.AreEqual(tdesExpected[2], tdesKeysReceived[2]);
        }
    }
}
