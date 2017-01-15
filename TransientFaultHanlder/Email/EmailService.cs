using RestSharp;
using System.Net;
using System.Reflection;

namespace TransientFaultHanlder
{
    internal class EmailService : IEmailService
    {
        private int Count { get; set; } = 0;

        public Result<string> Send()
        {
            return Send(new Email());
        }

        public Result<string> Send(Email email)
        {
            Count++;
            if (Count % 3 == 0 || Count % 5 == 0)
                throw new MyException($"My Custom Test Exception from [{MethodBase.GetCurrentMethod().Name}]");

            if (Count % 13 == 0)
                return new WebClient().DownloadString("https://raw.githubusercontent.com/amrur/Test/master/Polly");
            else
                return new WebClient().DownloadString("https://raw.githubusercontent.com/amrur/Test/master/NotExist");
        }

        public RestResult<string> SendMocky()
        {
            Count++;
            if (Count == 1)
                throw new MyException($"My Custom Test Exception from [{MethodBase.GetCurrentMethod().Name}]");

            if (Count % 2 == 0)
                return GetMocky("58510c350f00004308046c09"); // 504 : Gateway Timeout

            if (Count % 3 == 0 || Count % 5 == 0)
                return GetMocky("585106db0f00004e08046bf9"); // 400 : Bad Request

            if (Count % 7 == 0)
                return GetMocky("5851125d0f00003f08046c19"); // 200 : OK with text Result
            else
                return GetMocky("58510bd20f00003e08046c06"); // 503 : Service Unavailable
        }

        public RestResult<string> SendMocky(Email email)
        {
            return SendMocky();
        }

        private RestResult<string> GetMocky(string resource)
        {
            var client = new RestClient("http://www.mocky.io/v2/");
            var request = new RestRequest(resource, Method.GET);
            var result = client.Execute(request);
            return new RestResult<string>(result.StatusCode, result.Content);
        }
    }
}