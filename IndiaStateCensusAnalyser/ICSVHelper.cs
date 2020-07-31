using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusAnalyser
{
    interface ICSVHelper
    {
        public string SortIndiaStateCodeByState();
        public string SortIndiaStateCensusByState();
        public string SortIndiaStateCensusByDensityPerSqKm();
        public string SortIndiaStateCensusByAreaInSqKm();
    }
}
