using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _60fps
{
    public class GameLoop
    {
        private int _fps;

        public GameLoop(int fps)
        {
            _fps = fps;
        }
        public void Start(Action action)
        {
            var thread = new Thread(Work);
            thread.Start(action);


        }
        public void Stop()
        {

        }
        public void Work(object o)
        {
            var action = o as Action;
            var stopwatch = Stopwatch.StartNew();
            var previousTime = stopwatch.ElapsedMilliseconds;

            var frameDurationMs = 1000f / _fps;
            while (true)
            {
                float delta = frameDurationMs - (stopwatch.ElapsedMilliseconds - previousTime);
                if (stopwatch.ElapsedMilliseconds - previousTime > frameDurationMs)
                {
                    action();

                    previousTime = stopwatch.ElapsedMilliseconds;
                }
                else if (delta > 0)
                {
                    Thread.Sleep((int)delta);
                }
            }
        }
    }
}

