using ABTestRealDB;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PGEFContext())
            {
                try
                {
                    PGEFContextSeeder.Seed(context);
                    Console.WriteLine("all ok");
                }
                catch
                {
                    Console.WriteLine("all bad");
                }
            }
            Console.Read();
        }
    }
}
