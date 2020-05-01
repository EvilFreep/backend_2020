using System;

namespace PasswordStrength
{
    public class Program
    {
        public const string INPUT_INCORRECT_PASSWORD_ERROR = "Invalid password entered";
        public const string RIGHT_FORM_OF_PASSWORD_ERROR = "Password can consist of numbers and english letters";
        public const string INCORRECT_NUMBER_OF_ARGS_ERROR = "Incorrect number of arguments";
        public const string RIGHT_USAGE_ERROR = "Usage method: PasswordStrenght.exe <password line>";

        public static bool checkTheCorrectnessOfPassword(ref string passwordStr)
        {
            for (int i = 0; i < passwordStr.Length; i++)
            {
                if (!(char.IsDigit(passwordStr[i]) || char.IsLetter(passwordStr[i])))
                {
                    Console.WriteLine(INPUT_INCORRECT_PASSWORD_ERROR);
                    Console.WriteLine(RIGHT_FORM_OF_PASSWORD_ERROR);

                    return false;
                }
            }

            return true;
        }

        public static bool checkTheCorrectnessOfArgs(ref string [] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(INCORRECT_NUMBER_OF_ARGS_ERROR);
                Console.WriteLine(RIGHT_USAGE_ERROR);

                return false;
            }

            return true;
        }

        public static int Main(string[] args)
        {
            if(!checkTheCorrectnessOfArgs(ref args) || !checkTheCorrectnessOfPassword(ref args[0]))
            {
                return 1;
            }

            var password = new Password();

            Console.WriteLine(password.checkPasswoedStrength(args[0]));

            return 0;
        }
    }
}
