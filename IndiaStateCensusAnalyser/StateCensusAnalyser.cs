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
                new CSVFactory('C').CheckForException();
            }
        }

        public static void CheckForWrongFileType(string correctFilePath, string filePath)
        {
            if (correctFilePath != filePath)
            {
                new CSVFactory('N').CheckForException();
            }
        }

        public static void CheckForDelimiter(string filePath)
        {
            string[] numOfRecords = File.ReadAllLines(filePath);
            foreach (var elements in numOfRecords)
            {
                if (elements.Split() != elements.Split(','))
                {
                    new CSVFactory('W').CheckForException();
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
                    new CSVFactory('H').CheckForException();
                }
            }
        }
    }
}
