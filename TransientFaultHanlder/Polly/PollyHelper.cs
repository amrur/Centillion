using System;
using Humanizer;
using Polly;

namespace TransientFaultHanlder
{
    // 6: Transient Fault Handling
    // https://msdn.microsoft.com/en-us/library/hh680901.aspx
    internal static class PollyHelper
    {
        public static void Retry(Action action, int retryCount, Action<Exception, int> onRetry)
        {
            Policy
               .Handle<DivideByZeroException>().Or<MyException>()
               .Retry(retryCount, onRetry)
               .Execute(action);
        }

        public static TResult Retry<TResult>(Func<TResult> action, int retryCount, Action<Exception, int> onRetry)
        {
            return Policy
               .Handle<DivideByZeroException>().Or<MyException>()
               .Retry(retryCount, onRetry)
               .Execute(action);
        }
        public static void WaitAndRetry(Action action, int retryCount, Action<Exception, TimeSpan> onRetry)
        {
            Policy
               .Handle<DivideByZeroException>().Or<MyException>()
               .WaitAndRetry(retryCount, sleepDuration => 1.Seconds(), onRetry)
               .Execute(action);
        }

        public static TResult WaitAndRetry<TResult>(Func<TResult> action, int retryCount, Action<Exception, TimeSpan> onRetry)
        {
            return Policy
               .Handle<DivideByZeroException>().Or<MyException>()
               .WaitAndRetry(retryCount, sleepDuration => 1.Seconds(), onRetry)
               .Execute(action);
        }
    }
}