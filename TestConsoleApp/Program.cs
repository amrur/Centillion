using System;
using MethodTimer;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMediator mediator = new 
            //var response = mediator.Send(new Ping());
            //Debug.WriteLine(response); // "Pong"

            //File.Encrypt(@"E:\Amr\Projects\Tarasol\SRS\BPM.pdf");
            Test();
            //int[] years = { 2013, 2014, 2015 };
            //int[] population = { 1025632, 1105967, 1148203 };
            //string s = string.Format("{0,-10} {1,-15}\n", "Year", "Population");
            //for (int index = 0; index < years.Length; index++)
            //    s += string.Format("{0,-10} {1,-15:N0}\n",
            //                       years[index], population[index]);
            //Console.WriteLine(s);
            //Console.WriteLine(1.ToWords(GrammaticalGender.Feminine));

            //var serilog = new LoggerConfiguration()
            //    .WriteTo.LiterateConsole()
            //    .WriteTo.RollingFile("log-{Date}.txt")
            //    .CreateLogger();
            //Log.Logger = serilog;

            //var fruit = new[] { "Apple", "Pear", "Orange" };
            //serilog.Information("In my bowl I have {fruit}", fruit);


            //var data = new
            //{
            //    Name = "Amr",
            //    Age = 12,
            //    Address = new { Country = "SA", City = "Riyadh" },
            //    BirthDate = DateTime.Now.AddYears(-33)
            //};
            //serilog.Information("Personal Info is {data}", data);

            //var input = new { Latitude = 25, Longitude = 134 };
            //var time = 34;

            //Log.Information("Processed {@SensorInput} in {TimeMS:000} ms.", input, time);

            //serilog.Information("Hello, world!");

            //int a = 10, b = 10;
            //try
            //{
            //    serilog.Debug("Dividing {A} by {B}", a, b);
            //    Console.WriteLine(a / b);
            //}
            //catch (Exception ex)
            //{
            //    serilog.Error(ex, "Something went wrong");
            //}

            ////Log.CloseAndFlush();
            //Console.ReadKey();


            //Console.ReadLine();
            //var stopTime = DateTime.Now.AddSeconds(1);
            //for (;;)
            //{

            //    serilog.Information($"In my bowl I have {fruit}");
            //    //serilog.Information("Hello, Serilog!");
            //    var exception = new Exception("Represents errors that occur during application execution");
            //    serilog.Error(exception, "Custom Exception Error");
            //    if (DateTime.Now > stopTime)
            //        break;
            //}
            Console.ReadLine();
        }

        [Time]//[Interceptor]
        private static void Test()
        {
            Console.WriteLine("Creating MyClass instance");
            MyClass mc = new MyClass();
            Console.WriteLine("Setting value in MyClass instance");
            mc.Value = 1;
           
        }
    }
}
