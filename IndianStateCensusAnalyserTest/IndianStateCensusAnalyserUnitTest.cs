using IndiaStateCensusAnalyser;
using NUnit.Framework;

namespace IndianStateCensusAnalyserTest
{
    public class IndianStateCensusAnalyserUnitTest
    {

        public string CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\IndiaStateCensusData.csv";
        public string WRONG_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusData.csv";
        public string NOT_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\IndiaStateCensusData.txt";
        public string WRONG_DELIMITER_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\IndiaStateCensusDataIncorrect.csv";

        [Test]
        public void GivenCSVFile_WhenAnalyseForRecord_ThenShouldReturnCorrectRecord()
        {
            Assert.AreEqual(29, IndiaStateCensusAnalyser.StateCensusAnalyser.GetStateCensusRecords(CSV_FILE_PATH));
        }

        [Test]
        public void GivenWrongCSVFile_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForWrongFilePath(CSV_FILE_PATH, WRONG_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileType_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForWrongFileType(CSV_FILE_PATH, NOT_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileDelimiter_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForDelimiter(WRONG_DELIMITER_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.WRONG_CSV_DELIMITER_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileType_WhenAnalyseForStateCensus_ThenShouldThrowException1()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForWrongFileType(CSV_FILE_PATH, NOT_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileType_WhenAnalyseForStateCensus_ThenShouldThrowHeadearNotMathedException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForHeader(CSV_FILE_PATH, WRONG_DELIMITER_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.HEADER_NOT_MATCHED_EXCEPTION, e.type);
        }
    }
}