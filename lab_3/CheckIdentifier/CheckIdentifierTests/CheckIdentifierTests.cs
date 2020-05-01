using System;
using System.IO;
using Xunit;

namespace CheckIdentifier.Tests
{
    public class CheckIdentifierTests
    {
        [Fact]
        public void IsEnglishLetter_RusSym_FalseReturned()
        {
            char ch = 'ú';

            Assert.False(Program.IsEnglishLetter(ch));
        }

        [Fact]
        public void IsEnglishLetter_EngSym_TrueReturned()
        {
            char ch = 's';

            Assert.True(Program.IsEnglishLetter(ch));
        }

        [Fact]
        public void checkInd_EmptyStr_ErrorMessageReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string[] args = { "" };
            Program.Main(args);
            Assert.Equal(Program.NO_ERROR_MESSAGE + "\r\n" + Program.EMPTY_STR_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void checkInd_StartWithDigit_ErrorMessageReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string args = "123yut";
            Program.checkInd(ref args);
            Assert.Equal(Program.NO_ERROR_MESSAGE + "\r\n" + Program.BEGIN_WITH_NUM_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void checkInd_NonNumericAndNonLettersSyms_ErrorMessageReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string args = "fsfsf.fe";
            Program.checkInd(ref args);
            Assert.Equal(Program.NO_ERROR_MESSAGE + "\r\n" + Program.RIGTH_USAGE_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void checkInd_CorrectInput_TrueReturned()
        {
            string args = "fgsfgds123";

            Assert.True(Program.checkInd(ref args));
        }

        [Fact]
        public void Main_TooManyArgs_ErrorMessageReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string[] args = { "", "" };
            Program.Main(args);
            Assert.Equal(Program.INCOERRECT_NUM_OF_ARGS_ERROR + "\r\n", writer.ToString());
        }

        [Fact]
        public void Main_CorrectInput_YesMessageReturned()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            string[] args = { "dada11" };
            Program.Main(args);
            Assert.Equal(Program.YES_MESSAGE + "\r\n", writer.ToString());
        }
    }
}
