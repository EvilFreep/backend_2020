using System;

namespace printArgs
{
    class MainClass
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
            }
            else
            {
                Console.WriteLine("Number of arguments: " + args.Length);
                Console.Write("Arguments: ");
                foreach (string s in args)
                    Console.Write(s + " ");
            }

            return 0;
        }
    }
}
