using System.Collections.Generic;
using System.IO;

namespace IndiaStateCensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetRecords(string path)
        {
            var csv = new List<string>();
            var records = File.ReadAllLines(path);
            foreach(var elements in records)
            {
                csv.Add(elements);
            }
            return csv.Count - 1;
        }

    }
}
