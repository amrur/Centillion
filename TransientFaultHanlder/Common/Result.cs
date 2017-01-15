using Newtonsoft.Json;

namespace TransientFaultHanlder
{
    internal class Result<T>
    {
        public bool IsSucceed { get; set; }
        public T Data { get; set; }

        public static implicit operator Result<T>(T data)
        {
            return new Result<T> { IsSucceed = true, Data = data };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}