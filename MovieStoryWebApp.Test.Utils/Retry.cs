using System;
using System.Threading;

namespace MovieStoryWebApp.Test.Utils
{
    public static class Retry
    {
        public static TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromMilliseconds(3000);

        public static TimeSpan DefaultInterval { get; set; } = TimeSpan.FromMilliseconds(100);

        public static bool Until(Func<bool> predicate, TimeSpan timeout, TimeSpan interval)
        {
            var startTime = DateTime.UtcNow;
            bool result = false;
            while ((timeout == Timeout.InfiniteTimeSpan || DateTime.UtcNow.Subtract(startTime) < timeout) && !(result = predicate()))
            {
                Thread.Sleep(interval);
            }
            return result;
        }

        public static bool Until(Func<bool> predicate) => Until(predicate, DefaultTimeout, DefaultInterval);
    }
}
