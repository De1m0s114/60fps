using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _60fps
{
    public class GameLoop
    {
        private Stopwatch _stopwatch;
        private int _fps;
        private volatile bool _IsRunning;
        private Thread _thread;

        public GameLoop(int fps)
        {
            _fps = fps;
        }
        public void Start(Action action)
        {
            _IsRunning = true;
            _thread = new Thread(Work);
            _thread.Start(action);


        }
        public void Stop()
        {
            _IsRunning = false;
            _stopwatch.Stop();
            _thread.Join();
        }
        public TimeSpan ElapsetTime
        {
            get
            {
                return _stopwatch.Elapsed;
            }
            
        }
        public void Work(object o)
        {
            var action = o as Action;
            
            _stopwatch = Stopwatch.StartNew();
            var previousTime = _stopwatch.ElapsedMilliseconds;

            var frameDurationMs = 1000f / _fps;
            while (_IsRunning)
            {
                float delta = frameDurationMs - (_stopwatch.ElapsedMilliseconds - previousTime);
                if (_stopwatch.ElapsedMilliseconds - previousTime > frameDurationMs)
                {
                    action();

                    previousTime = _stopwatch.ElapsedMilliseconds;
                }
                else if (delta > 0)
                {
                   //Thread.Sleep((int)delta);
                }
            }
        }
    }
}

