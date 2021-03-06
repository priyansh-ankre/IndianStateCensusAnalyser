﻿using System;
using System.IO;

namespace IndiaStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        private readonly string filePath;
        private readonly string wrongFilePath;
        private readonly char delimiter = ',';


        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        public StateCensusAnalyser(string filePath, string wrongFilePath)
        {
            this.filePath = filePath;
            this.wrongFilePath = wrongFilePath;
        }

        public int GetStateCensusRecords()
        {
            if (wrongFilePath != null)
            {
                if (filePath != wrongFilePath)
                {
                    throw new IndianStateAnalyserException("this is wrong file path", IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION);
                }
            }

            if (!filePath.EndsWith(".csv"))
            {
                throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION);
            }

            string[] numOfRecords = File.ReadAllLines(filePath);

            foreach (var elements in numOfRecords)
            {
                if (elements.Split() != elements.Split(delimiter))
                {
                    throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.WRONG_CSV_DELIMITER_EXCEPTION);
                }
            }

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
