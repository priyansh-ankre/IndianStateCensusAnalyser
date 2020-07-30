using System;

namespace IndiaStateCensusAnalyser
{
    class Program
    {
        public static void Main(string[] args)
        {
            string STATE_CENSUS_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusData.csv";
            string STATE_CODE_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCode.csv";
            int csvStateCensusRecords = CSVStateCensus.GetRecords(STATE_CENSUS_FILE_PATH);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecords(STATE_CENSUS_FILE_PATH);
            Console.WriteLine("CSV state census records: " + csvStateCensusRecords);
            Console.WriteLine("state census recors: " + stateCensusRecords);
            StateCensusAnalyser.GetData(STATE_CENSUS_FILE_PATH);
            Console.WriteLine();
            new JSONStateCensus(STATE_CENSUS_FILE_PATH).SortIndiaSateCensusByState();
            Console.WriteLine();
            new JSONStateCensus(STATE_CENSUS_FILE_PATH).SortIndiaSateCensusByDensityPerSqKm();
        }
    }
}
