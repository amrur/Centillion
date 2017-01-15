using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using Humanizer;
using Polly;
using Polly.CircuitBreaker;

namespace TransientFaultHanlder
{
    // 6: Transient Fault Handling
    // https://msdn.microsoft.com/en-us/library/hh680901.aspx
    internal class PollySample
    {
        #region : Initialization :

        private Action<string> Log { get; }
        private IEmailService Service { get; }
        private Random Rand { get; } = new Random();
        public PollySample(IEmailService service, Action<string> logger)
        {
            Log = logger;
            Service = service;
        }

        #endregion

        public void Retry(int retryCount)
        {
            try
            {
                var result = Policy
                    .Handle<WebException>().Or<MyException>()
                    .Retry(retryCount, OnRetry)
                    .Execute(Service.Send);

                LogResult(result);
            }
            catch (Exception exception)
            {
                LogException(exception);
            }
        }
        private void OnRetry(Exception exception, int retryCount)
        {
            string excetionData = $"{exception.GetType().Name} » {exception.Message}";
            Log($" {retryCount.ToString("00")}» {excetionData}");
        }

        public void WaitAndRetry_RandomWaitDurations(int retryCount)
        {
            try
            {
                var policy = Policy
                        .Handle<WebException>().Or<MyException>()
                        .WaitAndRetry(GenerateRandom(retryCount, 0, 6), OnRetryWait);
                //.WaitAndRetry(retryCount, sleepDuration => Rand.Next(0, 6).Seconds(), OnRetryWait);

                var result = policy.Execute(Service.Send);
                LogResult(result);
            }
            catch (Exception exception)
            {
                LogException(exception);
            }
        }
        public void WaitAndRetry(int retryCount, TimeSpan waitDuration)
        {
            //Func<int, TimeSpan> sleepDurationProvider = sleepDuration => 1.Seconds();
            try
            {
                var policy = Policy
                         .Handle<WebException>(exp => exp.Message == "The remote server returned an error: (404) Not Found.")
                         .Or<WebException>(exp => exp.Message == "Unable to connect to the remote server")
                         .Or<MyException>()
                         .WaitAndRetry(retryCount, sleepDuration => waitDuration, OnRetryWait);
                //.WaitAndRetry(10, retryCount => Math.Exp(retryCount / 3).Seconds(), OnRetryWait);

                var result = policy.Execute(() => Service.Send(new Email()));
                LogResult(result);
            }
            catch (Exception exception)
            {
                LogException(exception);
            }
        }
        private void OnRetryWait(Exception exception, TimeSpan timeSpan, int retryCount, Context context)
        {
            string excetionData = $"{exception.GetType().Name} » {exception.Message}";
            //Log($" {retryCount.ToString("00")}» Retry after {timeSpan.Humanize()}» {excetionData}");
            Log($"[ Retry No. {retryCount.ToString("00")} , Wait: {timeSpan.Humanize()} ] » {excetionData}");

        }

        public void WaitAndRetry_Mocky(int retryCount, TimeSpan waitDuration)
        {
            try
            {
                var policy = Policy
                        // Handle Results
                        .HandleResult<RestResult<string>>(r => r.StatusCode == HttpStatusCode.BadRequest)
                        .OrResult(r => r.StatusCode == HttpStatusCode.GatewayTimeout)
                        .OrResult(r => r.StatusCode == HttpStatusCode.ServiceUnavailable)
                        // Handle Exceptions
                        .Or<MyException>()
                        .Or<WebException>(exp => exp.Message.Contains("The remote server returned an error: (404) Not Found"))
                        .Or<WebException>(exp => exp.Message.Contains("Unable to connect to the remote server"))
                        .WaitAndRetry(retryCount, sleepDuration => waitDuration, OnRetryWait);

                var result = policy.Execute(() => Service.SendMocky(new Email()));
                LogResult(result);
            }
            catch (Exception exception)
            {
                LogException(exception);
            }
        }
    
        private void OnRetryWait(DelegateResult<RestResult<string>> data, TimeSpan timeSpan, int retryCount, Context context)
        {
            string message = null;
            if (data.Exception != null)
                message = $"{data.Exception.GetType().Name} » {data.Exception.Message}";

            var result = data.Result;
            if (result != null)
            {
                message = $"{(int)result.StatusCode} - {result.StatusCode}";
                if (!string.IsNullOrEmpty(result.Data))
                    message += $" » {result.Data}";
            }
            //Log($" {retryCount.ToString("00")}» Retry after {timeSpan.Humanize()}» {message}");
            Log($"[ Retry No. {retryCount.ToString("00")} , Wait: {timeSpan.Humanize()} ] » {message}");
        }


        // Circuit Breaker
        public Policy DefineCircuitBreakerPolicy(int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak)
        {
            return Policy
                    // Handle Exceptions
                    .Handle<MyException>()
                    .Or<WebException>(exp => exp.Message.Contains("The remote server returned an error: (404) Not Found"))
                    .Or<WebException>(exp => exp.Message.Contains("Unable to connect to the remote server"))

                    .CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak);
        }

        public void ExecuteCircuitBreaker(Policy policy)
        {
            try
            {
                var result = policy.Execute(() => Service.Send(new Email()));
                LogResult(result);
            }
            catch (BrokenCircuitException exception)
            {
                Log(exception.Message);
            }
            catch (Exception exception)
            {
                Log($"[{MethodBase.GetCurrentMethod().Name}] » " + exception);
            }
        }

        #region • Helper Methods •

        private void LogException(Exception exception, [CallerMemberName] string mb = "")
        {
            Log($"Unexpected Exception (Out of Polly [{mb}]) >> " + exception);
        }

        private void LogResult(object result)
        {
            Log($"Done, Result = {result}");
        }

        private List<TimeSpan> GenerateRandom(int count, int startNumber, int endNumber)
        {
            //var sleepDurations = new List<TimeSpan> { 1.Seconds(), 2.Seconds(), 1.Seconds() };
            var sleepDurations = new List<TimeSpan>();
            for (int i = 0; i < count; i++)
                sleepDurations.Add(Rand.Next(startNumber, endNumber).Seconds());

            return sleepDurations;
        }

        #endregion
    }
}