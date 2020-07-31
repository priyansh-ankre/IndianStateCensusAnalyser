using System.Collections.Generic;
using System.IO;

namespace IndiaStateCensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetRecords(string path)
        {
            var csv = new Dictionary<int,string[]>();
            var records = File.ReadAllLines(path);
            for(int rows = 0; rows < records.Length; rows++)
            {
                csv.Add(rows, records);
            }
            return csv.Count - 1;
        }

    }
}
