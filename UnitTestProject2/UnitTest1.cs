using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationMockExam.Controllers;
using WebApplicationMockExam.Model;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private readonly TempController _controller = new TempController();

        [TestInitialize] //run before each method
        public void Init()
        {
            _controller.ReInitialize();
        }
        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Temp> Temps = _controller.Get();
            Assert.AreEqual(2,Temps.Count());

            //Temp te = _controller.Get(1);
            //Assert.AreEqual(11,te.Pressure);
            //te = _controller.Get(100);
            //Assert.IsNull(te);
        }

        [TestMethod]
        public void TestDelete()
        {
            //int howMany = _controller.Delete(100);
            //Assert.AreEqual(0,howMany);

            //howMany = _controller.Delete(1);
            //Assert.AreEqual(1,howMany);

            //IEnumerable<Temp> Temps = _controller.Get();
            //Assert.AreEqual(1, Temps.Count());


        }

        [TestMethod]
        public void TestPost()
        {
          Temp newTemp=new Temp
          {
              Humidity = 11,
              Pressure = 10,
              Temperatur = 10,

          };
            Temp tem = _controller.Post(newTemp);
            Assert.AreEqual(3,tem.Id);

        }


        [TestMethod]
        public void TestPut()
        {
            Temp newTemp = new Temp
            {
                Humidity = 10,
                Pressure = 10,
                Temperatur = 10

            };
            Temp tem = _controller.Put(1, newTemp);
            Assert.AreEqual(10, tem.Humidity);
            Temp t2 = _controller.Get(1);
            Assert.AreEqual(10,t2.Humidity);

        }
    }
}
