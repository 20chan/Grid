using System;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public static class Time
    {
        public static TimeSpan ElapsedGameTime = new TimeSpan();
        public static TimeSpan TotalGameTime = new TimeSpan();

        public static double ElapsedSeconds => ElapsedGameTime.TotalSeconds;
        public static double ElapsedMilliSeconds => ElapsedGameTime.TotalMilliseconds;
    }
}
