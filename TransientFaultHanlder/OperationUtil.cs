using System.Reflection;

namespace TransientFaultHanlder
{
    internal class OperationUtil
    {
        public int Y { get; set; } = 0;
        public int Count { get; set; } = 0;


        public int Calculate()
        {
            return Calculate(int.MaxValue);
        }

        public int Calculate(int x)
        {
            Count++;
            if (Count > 3 & Count <= 5)
                throw new MyException($"My Custom Test Exception from [{MethodBase.GetCurrentMethod().Name}]");

            var result = x / Y;
            Y++;
            return result;
        }
    }
}
