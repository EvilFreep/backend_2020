using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Password
    {

        public int checkLettersOrNumsOnly(string password)
        {
            var onlyLetters = true;
            var onlyNums = true;

            foreach(char ch in password)
            {
                if(!char.IsLetter(ch) && onlyLetters)
                {
                    onlyLetters = false;
                }

                if(!char.IsDigit(ch) && onlyNums)
                {
                    onlyNums = false;
                }
            }

            if(onlyLetters || onlyNums)
            {
                return -password.Length;
            }

            return 0;
        }

        public int count(Func<char, bool> func, string password)
        {
            int count = 0;

            foreach (char ch in password)
            {
                if (func(ch))
                {
                    count++;
                }
            }

            return count;
        }

        public int countNums(string password)
        {
            return count(char.IsDigit, password);
        }

        public int countLetters(string password)
        {
            return count(char.IsLetter, password);
        }

        /* Считал повториющиеся символы и в верхенем, и в нижнем регистре так как
           формула (len - x) * 2 + (len - y) * 2
           (x - это символы в Верхнем регистре, у - это символы в нижнем регистре)
           эквивалентна 2 * (2 * len - (x + y))
           х + у - это все символы*/ 
        public int countRepeatSymbols(string password)
        {
            int repeatCount = 0;
            var allSyms = new List<char>();
            var ununiqueSyms = new List<char>();

            foreach (char ch in password)
            {
                if (!allSyms.Contains(ch))
                {
                    allSyms.Add(ch);
                }
                else
                {
                    if (!ununiqueSyms.Contains(ch))
                    {
                        ununiqueSyms.Add(ch);
                    }
                }
            }

            foreach(char ch in ununiqueSyms)
            {
                foreach(char character in password)
                {
                    if(ch == character)
                    {
                        repeatCount++;
                    }
                }
            }

            return repeatCount;
        }

        public int checkPasswoedStrength(string password)
        {
            int passwordStrength = 0;

            passwordStrength += checkLettersOrNumsOnly(password) + (4 * password.Length) + (4 * countNums(password))
                             + 2 * (2 *(password.Length - countLetters(password))) - countRepeatSymbols(password);

            return passwordStrength;
        }
    }
}
