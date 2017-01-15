using System;

namespace TestConsoleApp
{

    [AttributeUsage(AttributeTargets.All)]
    public class TestAttribute : Attribute
    {
        public TestAttribute()
        {
            Console.WriteLine("Running constructor");
        }
    }

}