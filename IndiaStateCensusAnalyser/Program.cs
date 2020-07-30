using System;

namespace IndiaStateCensusAnalyser
{
    class Program
    {
        public static void Main(string[] args)
        {
            string FILE_PATH = @"C:\Users\hp\source\repos\IndiaStateCensusAnalyserApplication\IndiaStateCensusAnalyser\CSVfiles\IndiaStateCensusData.csv";

            int csvStateCensusRecords = CSVStateCensus.GetRecords(FILE_PATH);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecords(FILE_PATH);
            Console.WriteLine("CSV state census records: " + csvStateCensusRecords);
            Console.WriteLine("state census recors: " + stateCensusRecords);
            StateCensusAnalyser.GetData(FILE_PATH);
            Console.WriteLine();
            JSONStateCensus.CsvToJSON(FILE_PATH);
            
        }
    }
}
