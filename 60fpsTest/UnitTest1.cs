using NUnit.Framework;
using _60fps;
using System;
using System.Threading;

namespace _60fpsTest
{
    public class TestFor_60fps
    {
        public int i ;
        [SetUp]
    public void Begin()
        {
            i = 0;
        }
        

        [Test]
        public void TestForFrameDuration()
        {
            var s= new GameLoop(1);
            s.Start(counter);
            Thread.Sleep(5100);
            s.Stop();
            Assert.AreEqual((int)s.ElapsetTime.TotalSeconds, i);
            
        }

        [Test]
        public void TestForFrameDuration60()
        {
            var s = new GameLoop(60);
            s.Start(counter);
            Thread.Sleep(1000);
            s.Stop();
            Assert.AreEqual(60, i, 2);

        }

        private void counter()
        {
            i++;
        }
    }
}