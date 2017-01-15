using System;

namespace TransientFaultHanlder
{
    internal class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }
}
