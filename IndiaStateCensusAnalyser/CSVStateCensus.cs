using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndiaStateCensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetRecords(string path)
        {
            int count = 0;
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> records = data;
            List<string> recordsList = new List<string>();
            foreach (var elements in records)
            {
                count++;
                recordsList.Add(elements);
            }
            return recordsList.Count - 1;
        }

    }
}
