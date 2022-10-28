namespace DimaGame.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetCellWithNumber2x2()
        {
            string[,] masTest = new string[,] { { "1", "2" }, { "3", "4" } };
            var logicGame = new LogicGame(masTest);
            var expected = "4";
            Assert.Equal(expected, logicGame.GetCellWithNumber(0, 0));
        }

        [Fact]
        public void TestGetCellWithNumber3x3()
        {
            string[,] masTest = new string[,] { { "1", "2", "3" }, { "143", "4", "5" }, { "6", "7", "8" } };
            var logicGame = new LogicGame(masTest);
            var expected = "8";
            Assert.Equal(expected, logicGame.GetCellWithNumber(1, 1));
        }

        [Fact]
        public void TestGetCellWithNumber4x4()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", "16" } };
            var logicGame = new LogicGame(masTest);
            var expected = "16";
            Assert.Equal(expected, logicGame.GetCellWithNumber(2, 2));
        }

        [Fact]
        public void TestGetCellWithNumber5x5()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4", "5" }, { "6", "7", "8", "9", "10" }, { "11", "12", "13", "14", "15" }, { "16", "17", "18", "19", "20" }, { "21", "22", "23", "24", "25" } };
            var logicGame = new LogicGame(masTest);
            var expected = "25";
            Assert.Equal(expected, logicGame.GetCellWithNumber(3, 3));
        }

        [Fact]
        public void TestGetCellWithNumber6x6()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4", "5", "6" }, { "7", "8", "9", "10", "11", "12" }, { "13", "14", "15", "16", "17", "18" }, { "19", "20", "21", "22", "23", "24" }, { "25", "26", "27", "28", "29", "30" }, { "31", "32", "33", "34", "35", "36" } };
            var logicGame = new LogicGame(masTest);
            var expected = "36";
            Assert.Equal(expected, logicGame.GetCellWithNumber(4, 4));
        }

        [Fact]
        public void TestSetCellWithNumber2x2()
        {
            string[,] masTest = new string[,] { { "1", "2" }, { "3", "4" } };
            var logicGame = new LogicGame(masTest);
            var expected = "8";
            logicGame.SetCellWithNumber(0, 0, "8");
            Assert.Equal(expected, logicGame.GetCellWithNumber(0, 0));
        }

        [Fact]
        public void TestSetCellWithNumber3x3()
        {
            string[,] masTest = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            var logicGame = new LogicGame(masTest);
            var expected = "100";
            logicGame.SetCellWithNumber(1, 1, "100");
            Assert.Equal(expected, logicGame.GetCellWithNumber(1, 1));
        }

        [Fact]
        public void TestSetCellWithNumber4x4()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4" }, { "5", "6", "7", "8" }, { "9", "10", "11", "12" }, { "13", "14", "15", "16" } };
            var logicGame = new LogicGame(masTest);
            var expected = "110";
            logicGame.SetCellWithNumber(2, 2, "110");
            Assert.Equal(expected, logicGame.GetCellWithNumber(2, 2));
        }

        [Fact]
        public void TestSetCellWithNumber5x5()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4", "5" }, { "6", "7", "8", "9", "10" }, { "11", "12", "13", "14", "15" }, { "16", "17", "18", "19", "20" }, { "21", "22", "23", "24", "25" } };
            var logicGame = new LogicGame(masTest);
            var expected = "2222";
            logicGame.SetCellWithNumber(3, 3, "2222");
            Assert.Equal(expected, logicGame.GetCellWithNumber(3, 3));
        }

        [Fact]
        public void TestSetCellWithNumber6x6()
        {
            string[,] masTest = new string[,] { { "1", "2", "3", "4", "5", "6" }, { "7", "8", "9", "10", "11", "12" }, { "13", "14", "15", "16", "17", "18" }, { "19", "20", "21", "22", "23", "24" }, { "25", "26", "27", "28", "29", "30" }, { "31", "32", "33", "34", "35", "36" } };
            var logicGame = new LogicGame(masTest);
            var expected = " ";
            logicGame.SetCellWithNumber(4, 4, " ");
            Assert.Equal(expected, logicGame.GetCellWithNumber(4, 4));
        }

        [Fact]
        public void TestFillTheTrueFieldAndFieldValidation()
        {
            string[,] trueMas = new string[,] { { "0", "0", "0", "0", "0" }, { "0", "1", "2", "3", "0" }, { "0", "4", "5", "6", "0" }, { "0", "7", "8", " ", "0" }, { "0", "0", "0", "0", "0" } };
            var logicGame = new LogicGame(trueMas);
            logicGame.FillTheTrueField();
            var expected = true;
            Assert.Equal(expected, logicGame.FieldValidation());
        }

        [Fact]
        public void TestSolvabilityCheckTrue()
        {
            int[] masTest2 = new int[] { 0, 3, 2, 7, 8, 4, 6, 11, 12, 9, 5, 10, 15, 1, 13, 14 };
            var logicGame = new LogicGame(masTest2);
            var expected = true;
            Assert.Equal(expected, logicGame.SolvabilityCheck());
        }

        [Fact]
        public void TestSolvabilityCheckFalse()
        {
            int[] masTest2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 14, 0 };
            var logicGame = new LogicGame(masTest2);
            var expected = false;
            Assert.Equal(expected, logicGame.SolvabilityCheck());
        }

        [Fact]
        public void TestGetTrueFieldValue()
        {
            var logicGame = new LogicGame(4);
            var expected = "1";
            logicGame.FillTheTrueField();
            Assert.Equal(expected, logicGame.GetTrueFieldValue(0, 0));
        }
    }
}