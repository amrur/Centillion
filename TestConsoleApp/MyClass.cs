using System;
using System.Threading;

namespace TestConsoleApp
{

    [Test]
    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Getting attributes for MyClass type");
            object[] attributes = typeof(MyClass).GetCustomAttributes(true);
            Thread.Sleep(1520);
        }
        public int Value { get; set; }
    }

}