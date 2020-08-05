using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IndiaStateCensusAnalyser
{
    public class JSONStateCensus : ICSVHelper
    {
        public readonly string path;
        public JSONStateCensus(string path)
        {
            this.path = path;
        }
        public string CsvToJSON()
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int rows = 1; rows < lines.Length; rows++)
            {
                var objResult = new Dictionary<string, string>();
                for (int columns = 0; columns < properties.Length; columns++)
                    objResult.Add(properties[columns], csv[rows][columns]);

                listObjResult.Add(objResult);
            }
            return JsonConvert.SerializeObject(listObjResult);
        }
        
        public string SortIndiaStateCensusByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<IndianStateCensusModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.State);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortIndiaStateCodeByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<IndianStateCodeModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.StateName);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortIndiaStateCensusByDensityPerSqKm()
        {
            var listOb = JsonConvert.DeserializeObject<List<IndianStateCensusModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.DensityPerSqKm);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortIndiaStateCensusByAreaInSqKm()
        {
            var listOb = JsonConvert.DeserializeObject<List<IndianStateCensusModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.AreaInSqKm);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByPopulousState()
        {
            var listOb = JsonConvert.DeserializeObject<List<USCensusModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.Population);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<USCensusModel>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.State);
            return JsonConvert.SerializeObject(ascListOb);
        }
    }
}
