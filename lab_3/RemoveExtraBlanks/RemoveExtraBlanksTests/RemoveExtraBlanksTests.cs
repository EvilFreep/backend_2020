using System;
using Xunit;

namespace RemoveExtraBlanksTests
{
    public class RemoveExtraBlanksTests
    {
        [Fact]
        public void ParseArgs_TooLittleArgs_FalseReturned()
        {
            string[] args = { "input.txt" };
            string inFile = "";
            string outFile = "";
            Assert.False(RemoveExtraBlanks.Program.ParseAgrs(args, ref inFile, ref outFile));
        }

        [Fact]
        public void ParseArgs_CorrectInput_TrueReturned()
        {
            string[] args = { "input.txt", "output.txt" };
            string inFile = "";
            string outFile = "";
            Assert.True(RemoveExtraBlanks.Program.ParseAgrs(args, ref inFile, ref outFile));
            Assert.Equal("input.txt", inFile);
            Assert.Equal("output.txt", outFile);
        }

        [Fact]
        public void removeExtraBlanksInLine_EmptyLine_EmptyLineReturned()
        {
            string line = "";
            RemoveExtraBlanks.Program.removeExtraBlanksInLine(ref line);

            Assert.Equal("", line);
        }

        [Fact]
        public void removeExtraBlanksInLine_SpasesAtBothEnds_TextReturned()
        {
            string line = "        text        ";
            RemoveExtraBlanks.Program.removeExtraBlanksInLine(ref line);

            Assert.Equal("text", line);
        }

        [Fact]
        public void removeExtraBlanksInLine_SpacesAtLine_SomeTextReturned()
        {
            string line = "some                            text";
            RemoveExtraBlanks.Program.removeExtraBlanksInLine(ref line);

            Assert.Equal("some text", line);
        }

        [Fact]
        public void CheckExistFile_NotExistedFile_FalseReturned()
        {
            Assert.False(RemoveExtraBlanks.Program.CheckExistFile("NotExisting.txt"));
        }

        [Fact]
        public void CheckExistFile_ExistingFile_TrueReturned()
        {
            Assert.True(RemoveExtraBlanks.Program.CheckExistFile("input.txt"));
        }

        [Fact]
        public void writeTextWithoutExtraBlanksFromInputToOutput_ExistingInputOuputFiles_TrueReturned()
        {
            //провер€етс€ только корректный инпут так как все ошибки провер€ют вышепроверенные функции
            Assert.True(RemoveExtraBlanks.Program.writeTextWithoutExtraBlanksFromInputToOutput("input.txt", "output.txt"));
        }
    }
}
