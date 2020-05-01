using System;

namespace CheckIdentifier
{
    public class Program
    {
        public const string NO_ERROR_MESSAGE = "No";
        public const string EMPTY_STR_ERROR = "Empty string is not identifier";
        public const string BEGIN_WITH_NUM_ERROR = "Identifier can't begin with num";
        public const string RIGTH_USAGE_ERROR = "Identifier must contain only english letters or numbers";
        public const string INCOERRECT_NUM_OF_ARGS_ERROR = "incorrect number of args";
        public const string YES_MESSAGE = "Yes";

        public static bool IsEnglishLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }

        public static bool checkInd(ref string line)
        {
            if (line.Length == 0)
            {
                Console.WriteLine(NO_ERROR_MESSAGE);
                Console.WriteLine(EMPTY_STR_ERROR);
                return false;
            }

            if (char.IsDigit(line[0]))
            {
                Console.WriteLine(NO_ERROR_MESSAGE);
                Console.WriteLine(BEGIN_WITH_NUM_ERROR);
                return false;
            }

            for (int i = 1; i < line.Length; i++)
            {
                if (!(IsEnglishLetter(line[i]) || char.IsDigit(line[i])))
                {
                    Console.WriteLine(NO_ERROR_MESSAGE);
                    Console.WriteLine(RIGTH_USAGE_ERROR);
                    return false;
                }
            }
            return true;
        }

        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(INCOERRECT_NUM_OF_ARGS_ERROR);
                return 1;
            }

            string identifier = args[0];
            if (checkInd(ref identifier))
            {
                Console.WriteLine(YES_MESSAGE);
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
