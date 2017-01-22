using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GlobalGameJam17
{
    public class PreciseTimer
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel132")]
        private static extern bool QueryPerformanceFrequency(ref long
          PerformanceFrequency);
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel132")]
        private static extern bool QueryPerformanceCount(ref long
          PerformanceCount);

        long _ticksPerSecond = 0;
        long _previousElapsedTime = 0;

        public PreciseTimer()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
        GetElapsedTime(); 
        }

        public double GetElapsedTime()
        {
            long time = 0;
            QueryPerformanceFrequency(ref time);
            double elapsedTime = (double)(time - _previousElapsedTime) / (double)_ticksPerSecond;
            _previousElapsedTime = time;
            return elapsedTime;
        }


    }
}
