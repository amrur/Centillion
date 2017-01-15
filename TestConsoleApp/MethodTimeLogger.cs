using System;
using Humanizer;
using System.Reflection;

namespace TestConsoleApp
{

    public static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, long milliseconds)
        {
            Console.WriteLine($"MethodTimeLogger » {milliseconds.Milliseconds()}");
        }
    }

}