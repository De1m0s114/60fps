using NUnit.Framework;
using _60fps;
using System;
using System.Threading;

namespace _60fpsTest
{
    public class TestFor_60fps
    {
        public int i = 0;
        [SetUp]
       

        [Test]
        public void TestForFrameDuration()
        {
            var s= new GameLoop(1);
            s.Start(counter);
            Thread.Sleep(2000);
            
            Assert.AreEqual(2, i);
            
        }

        private void counter()
        {
            i++;
        }
    }
}