using System;

namespace IndiaStateCensusAnalyser
{
    class Program
    {
        public static void Main(string[] args)
        {

            string STATE_CENSUS_FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusData.csv";

            ICSVHelper cSVHelper = new JSONStateCensus(STATE_CENSUS_FILE_PATH);

            int csvStateCensusRecords = CSVStateCensus.GetRecords(STATE_CENSUS_FILE_PATH);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecords(STATE_CENSUS_FILE_PATH);

            Console.WriteLine("CSV state census records: " + csvStateCensusRecords);
            Console.WriteLine("state census recors: " + stateCensusRecords);

            StateCensusAnalyser.GetData(STATE_CENSUS_FILE_PATH);
            Console.WriteLine();

            Console.WriteLine("State census data from most population density state to least one :" + cSVHelper.SortIndiaStateCensusByDensityPerSqKm());
            Console.WriteLine();

            Console.WriteLine("State according to the ascending order of area :" + cSVHelper.SortIndiaStateCensusByAreaInSqKm());
            Console.WriteLine();

            Console.WriteLine("State in ascending order :" + cSVHelper.SortIndiaStateCensusByState());
        }
    }
}
