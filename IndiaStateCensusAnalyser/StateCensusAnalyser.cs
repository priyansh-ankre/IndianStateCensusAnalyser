using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndiaStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        private readonly string filePath;

        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        public static int GetStateCensusRecords(string filepath)
        {
            string[] numOfRecords = File.ReadAllLines(filepath);
            return numOfRecords.Length - 1;
        }

        public static void GetData(string filePath)
        {
            string[] numOfRecords = File.ReadAllLines(filePath);

            foreach (var elements in numOfRecords)
            {
                Console.WriteLine(elements);
            }
        }

        public static void CheckForWrongFilePath(string correctFilePath, string filePath)
        {
            if (correctFilePath != filePath)
            {
                throw new IndianStateAnalyserException("this is wrong file path", IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION);
            }
        }

        public static void CheckForWrongFileType(string correctFilePath, string filePath)
        {
            if (correctFilePath != filePath)
            {
                throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION);
            }
        }

        public static void CheckForDelimiter(string filePath)
        {
            string[] numOfRecords = File.ReadAllLines(filePath);
            foreach (var elements in numOfRecords)
            {
                if (elements.Split() != elements.Split(','))
                {
                    throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.WRONG_CSV_DELIMITER_EXCEPTION);
                }
            }
        }

        public static void CheckForHeader(string correctFilePath,string wrongFilePath)
        {
            string[] numOfRecords = File.ReadAllLines(correctFilePath);
            string[] numOfRecordsIncorrectFile = File.ReadAllLines(wrongFilePath);

            for (int rows = 0; rows < numOfRecords.Length; rows++)
            {
                if (numOfRecords[0] != numOfRecordsIncorrectFile[0])
                {
                    throw new IndianStateAnalyserException("this is a wrong header", IndianStateAnalyserException.ExceptionType.HEADER_NOT_MATCHED_EXCEPTION); 
                }
            }
        }
    }
}
