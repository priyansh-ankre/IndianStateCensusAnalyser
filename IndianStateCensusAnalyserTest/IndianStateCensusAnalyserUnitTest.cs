using IndiaStateCensusAnalyser;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace IndianStateCensusAnalyserTest
{
    public class IndianStateCensusAnalyserUnitTest
    {

        public string CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusData.csv";
        public string WRONG_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\CSVfiles\IndiaStateCensusData.csv";
        public string NOT_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusData.txt";
        public string WRONG_DELIMITER_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusDataIncorrect.csv";
        public string STATE_CODE_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCode.csv";
        public string WRONG_STATE_CODE_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\CSVfiles\IndiaStateCode.csv";
        public string STATE_CODE_NOT_CSV_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCode.txt";
        public string US_CENSUS_DATA_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\USCensusData.csv";

        [Test]
        public void GivenCSVFile_WhenAnalyseForRecord_ThenShouldReturnCorrectRecord()
        {
            Assert.AreEqual(29,IndiaStateCensusAnalyser.CSVStateCensus.GetRecords(CSV_FILE_PATH));
        }

        [Test]
        public void GivenWrongCSVFile_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() =>new IndiaStateCensusAnalyser.StateCensusAnalyser(CSV_FILE_PATH, WRONG_CSV_FILE_PATH).GetStateCensusRecords());
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileType_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() =>new IndiaStateCensusAnalyser.StateCensusAnalyser(NOT_CSV_FILE_PATH).GetStateCensusRecords());
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileDelimiter_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() =>new IndiaStateCensusAnalyser.StateCensusAnalyser(WRONG_DELIMITER_CSV_FILE_PATH).GetStateCensusRecords());
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.WRONG_CSV_DELIMITER_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongFileType_WhenAnalyseForStateCensus_ThenShouldThrowHeadearNotMathedException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForHeader(CSV_FILE_PATH, WRONG_DELIMITER_CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.HEADER_NOT_MATCHED_EXCEPTION, e.type);
        }

        [Test]
        public void GivenStateCodeCSVFile_WhenAnalyseForRecord_ThenShouldReturnCorrectRecord()
        {
            Assert.AreEqual(37,IndiaStateCensusAnalyser.CSVStateCensus.GetRecords(STATE_CODE_CSV_FILE_PATH));
        }

        [Test]
        public void GivenWrongStateCodeCSVFile_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() =>new IndiaStateCensusAnalyser.StateCensusAnalyser(STATE_CODE_CSV_FILE_PATH, WRONG_STATE_CODE_CSV_FILE_PATH).GetStateCensusRecords());
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongStateCodeFileType_WhenAnalyseForStateCensus_ThenShouldThrowException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() =>new IndiaStateCensusAnalyser.StateCensusAnalyser(STATE_CODE_NOT_CSV_FILE_PATH).GetStateCensusRecords());
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION, e.type);
        }

        [Test]
        public void GivenWrongStateCodeFileType_WhenAnalyseForStateCensus_ThenShouldThrowHeadearNotMathedException()
        {
            IndianStateAnalyserException e = Assert.Throws<IndianStateAnalyserException>(() => IndiaStateCensusAnalyser.StateCensusAnalyser.CheckForHeader(STATE_CODE_CSV_FILE_PATH, CSV_FILE_PATH));
            Assert.AreEqual(IndianStateAnalyserException.ExceptionType.HEADER_NOT_MATCHED_EXCEPTION, e.type);
        }

        [Test]
        public void GivenIndianStateCensusData_WhenAnalysed_ThenShouldReturnStateSortedResult()
        {
            IndiaStateCensusAnalyser.JSONStateCensus jSONState = new IndiaStateCensusAnalyser.JSONStateCensus(CSV_FILE_PATH);
            string jsonData = jSONState.SortIndiaStateCensusByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValue = jArray[0]["State"].ToString();
            Assert.AreEqual("Andhra Pradesh",firstValue);
        }

        [Test]
        public void GivenIndianStateCodeData_WhenAnalysed_ThenShouldReturnStateSortedResult()
        {
            IndiaStateCensusAnalyser.JSONStateCensus jSONState = new IndiaStateCensusAnalyser.JSONStateCensus(STATE_CODE_CSV_FILE_PATH);
            string jsonData = jSONState.SortIndiaStateCodeByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValue = jArray[0]["StateName"].ToString();
            Assert.AreEqual("Andaman and Nicobar Islands", firstValue);
        }

        [Test]
        public void GivenIndianStateCensusData_WhenAnalysed_ThenShouldReturnPopulousStateSortedResult()
        {
            IndiaStateCensusAnalyser.JSONStateCensus jSONState = new IndiaStateCensusAnalyser.JSONStateCensus(CSV_FILE_PATH);
            string jsonData = jSONState.SortIndiaStateCensusByDensityPerSqKm();
            JArray jArray = JArray.Parse(jsonData);
            string firstValue = jArray[0]["DensityPerSqKm"].ToString();
            Assert.AreEqual("1029", firstValue);
        }

        [Test]
        public void GivenUSCensusData_WhenAnalyseForRecord_ThenShouldReturnCorrectRecord()
        {
            Assert.AreEqual(51,IndiaStateCensusAnalyser.CSVStateCensus.GetRecords(US_CENSUS_DATA_FILE_PATH));
        }

        [Test]
        public void GivenUSCensusData_WhenAnalysed_ThenShouldReturnPopulousStateSortedResult()
        {
            IndiaStateCensusAnalyser.JSONStateCensus jSONState = new IndiaStateCensusAnalyser.JSONStateCensus(US_CENSUS_DATA_FILE_PATH);
            string jsonData = jSONState.SortUSCensusDataByPopulousState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValue = jArray[0]["Population"].ToString();
            Assert.AreEqual("1052567", firstValue);
        }

        [Test]
        public void GivenUSCensusData_WhenAnalysed_ThenShouldReturnStateSortedResult()
        {
            IndiaStateCensusAnalyser.JSONStateCensus jSONState = new IndiaStateCensusAnalyser.JSONStateCensus(US_CENSUS_DATA_FILE_PATH);
            string jsonData = jSONState.SortUSCensusDataByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValue = jArray[0]["State"].ToString();
            Assert.AreEqual("Alabama", firstValue);
        }
    }
}