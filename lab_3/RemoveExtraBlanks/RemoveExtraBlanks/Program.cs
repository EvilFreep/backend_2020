using System;
using System.IO;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static bool ParseAgrs(string[] args, ref string inputFile, ref string outputFile)
        {
            const string INCORRECT_NUMBER_OF_ARS_ERROR = "Incorrect number of arguments";
            const string USAGE_MESSAGE = "Usage: RemoveExtraBlanks.exe <input file> <output file>";
            if (args.Length != 2)
            {
                Console.WriteLine(INCORRECT_NUMBER_OF_ARS_ERROR);
                Console.WriteLine(USAGE_MESSAGE);
                return false;
            }

            inputFile = args[0];
            outputFile = args[1];

            return true;
        }

        public static void removeExtraBlanksInLine(ref string readLine)
        {
            bool firstSpace = false;
            readLine = readLine.Trim();
            for (var i = 0; i < readLine.Length; i++)
            {
                if (firstSpace && (readLine[i] == ' ' || readLine[i] == '\t'))
                {
                    readLine = readLine.Remove(i, 1);
                    i--;
                }

                if (readLine[i] == ' ' || readLine[i] == '\t')
                {
                    firstSpace = true;
                }
                else
                {
                    firstSpace = false;
                }
            }
        }

        public static bool CheckExistFile(string file)
        {
            const string INPUT_FILE_NOT_EXISTS_ERROR = "Input or output file can't be opened";
            if(!File.Exists(file))
            {
                Console.WriteLine(INPUT_FILE_NOT_EXISTS_ERROR);
                return false;
            }

            return true;
        }

        public static bool writeTextWithoutExtraBlanksFromInputToOutput(string inputFile, string outputFile)
        {
            if (!CheckExistFile(inputFile) || !CheckExistFile(outputFile))
            {
                return false;
            }

            var inputStream = new StreamReader(inputFile, System.Text.Encoding.UTF8);
            var outputStream = new StreamWriter(outputFile, false, System.Text.Encoding.UTF8);
            string readLine;

            while((readLine = inputStream.ReadLine()) != null)
            {
                removeExtraBlanksInLine(ref readLine);
                Console.WriteLine(readLine);
                outputStream.WriteLine(readLine);
            }

            inputStream.Close();
            outputStream.Close();
            return true;
        }

        public static int Main(string[] args)
        {
            string inputFileName = "";
            string outputFileName = "";

            if (!ParseAgrs(args, ref inputFileName, ref outputFileName))
            {
                return 1;
            }

            if (!writeTextWithoutExtraBlanksFromInputToOutput(inputFileName, outputFileName))
            {
                return 1;
            }

            return 0;
        }
    }
}
