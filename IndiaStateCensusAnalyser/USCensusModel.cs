using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusAnalyser
{
    class USCensusModel
    {
        public string StateId { get; set; }
        public string State { get; set; }
        public string Population { get; set; }
        public string HousingUnits { get; set; }
        public string TotalArea { get; set; }
        public string WaterArea { get; set; }
        public string LandArea { get; set; }
        public string PopulationDensity { get; set; }
        public string HousingDensity { get; set; }
    }
}
