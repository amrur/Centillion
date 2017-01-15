using Newtonsoft.Json;
using System.Net;

namespace TransientFaultHanlder
{
    internal class RestResult<T>
    {
        public RestResult(HttpStatusCode statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }


        public static implicit operator RestResult<T>(T data)
        {
            return new RestResult<T>(HttpStatusCode.OK, data);
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is RestResult<T> && StatusCode == ((RestResult<T>)obj).StatusCode;
        //}
        //public override int GetHashCode()
        //{
        //    return StatusCode.GetHashCode();
        //}
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}