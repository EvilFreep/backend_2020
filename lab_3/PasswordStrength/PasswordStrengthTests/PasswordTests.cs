using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PasswordStrength.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void checkLettersOrNumsOnly_NumsOnlyPassword_MinusPasswordLeangthReturned()
        {
            string passwordLine = "147365";
            var password = new Password();

            int expected = password.checkLettersOrNumsOnly(passwordLine);
            int actual = -passwordLine.Length;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkLettersOrNumsOnly_LettersOnlyPassword_MinusPasswordLeangthReturned()
        {
            string passwordLine = "abcdefg";
            var password = new Password();

            int expected = password.checkLettersOrNumsOnly(passwordLine);
            int actual = -passwordLine.Length;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkLettersOrNumsOnly_PasswordWithNumsAndLetters_ZeroReturned()
        {
            string passwordLine = "Stalin1953";
            var password = new Password();

            int expected = password.checkLettersOrNumsOnly(passwordLine);
            int actual = 0;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void count_CharIsDigitFunc_NumberOfDitgitReturned()
        {
            string passwordLine = "Lenin1924";
            var password = new Password();

            int expected = password.count(char.IsDigit, passwordLine);
            int actual = 4;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void count_CharIsLetterFunc_NumberOfLettersReturned()
        {
            string passwordLine = "Lenin1924";
            var password = new Password();

            int expected = password.count(char.IsLetter, passwordLine);
            int actual = 5;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void countNums_StrOfNumsAndLetters_NumberOfDitgitReturned()
        {
            string passwordLine = "Trotsky1940";
            var password = new Password();

            int expected = password.countNums(passwordLine);
            int actual = 4;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void countLetters_StrOfNumsAndLetters_NumberOfDitgitReturned()
        {
            string passwordLine = "Trotsky1940";
            var password = new Password();

            int expected = password.countLetters(passwordLine);
            int actual = 7;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkPasswoedStrength_PasswordOfNumsAndLetters_StreangthReturned()
        {
            string passwordLine = "Zinoviev1936";

            var password = new Password();

            int expected = password.checkPasswoedStrength(passwordLine);
            int actual = 76;

            Assert.Equal(expected, actual);
        }
    }

    public class ProgramTests
    {
        [Fact]
        public void checkTheCorrectnessOfArgs_TooManyArgs_FalseReturned()
        {
            string[] args = { "sasha123", "misha34" };

            Assert.False(Program.checkTheCorrectnessOfArgs(ref args));
        }

        [Fact]
        public void checkTheCorrectnessOfArgs_ZeroArgs_FalseReturned()
        {
            string[] args = { };

            Assert.False(Program.checkTheCorrectnessOfArgs(ref args));
        }

        [Fact]
        public void checkTheCorrectnessOfArgs_CorrectNumOfArgs_TrueReturned()
        {
            string[] args = { "hsfbsdh312" };

            Assert.True(Program.checkTheCorrectnessOfArgs(ref args));
        }

        [Fact]
        public void checkTheCorrectnessOfPassword_NonNumericAndNonLetterCharacterInPassword_FalseReturned()
        {
            string passwordLine = "fjsfksj.exe";

            Assert.False(Program.checkTheCorrectnessOfPassword(ref passwordLine));
        }

        [Fact]
        public void checkTheCorrectnessOfPassword_CorrectPasswordLine_TrueReturned()
        {
            string passwordLine = "fjsfksj1234";

            Assert.True(Program.checkTheCorrectnessOfPassword(ref passwordLine));
        }

        [Fact]
        public void Main_IvalidPassword_PasswordErrorReturned()
        {
            var writer = new StringWriter();            
            Console.SetOut(writer);
            string[] args = { "!ds" };
            Program.Main(args);
            Assert.Equal(Program.INPUT_INCORRECT_PASSWORD_ERROR + "\r\n" + Program.RIGHT_FORM_OF_PASSWORD_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void Main_IvalidNumOfArgs_ArgsErrorReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string[] args = { "ds", "fdsfs" };
            Program.Main(args);
            Assert.Equal(Program.INCORRECT_NUMBER_OF_ARGS_ERROR + "\r\n" + Program.RIGHT_USAGE_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void Main_CorrectInput_PasswoedStrengthReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string[] args = { "fdsfs" };
            Program.Main(args);
            Assert.Equal(11 + "\r\n", writer.ToString());
        }
    }
}
