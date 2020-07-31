using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IndiaStateCensusAnalyser
{
    public class JSONStateCensus
    {
        string path;
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
            /*Console.WriteLine(json);
            string serializedAsString = JsonConvert.SerializeObject(json, Formatting.Indented);*/
        }
        
        public void SortIndiaSateCensusByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<JSONCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.State);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

        public void SortIndiaSateCodeByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<JSONCode>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.StateName);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

        public void SortIndiaSateCensusByDensityPerSqKm()
        {
            var listOb = JsonConvert.DeserializeObject<List<JSONCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.DensityPerSqKm);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

        public void SortIndiaSateCensusByAreaInSqKm()
        {
            var listOb = JsonConvert.DeserializeObject<List<JSONCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.AreaInSqKm);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }
    }
}
