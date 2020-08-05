namespace IndiaStateCensusAnalyser
{
    class CensusDAO
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }
        public string SrNo { get; set; }
        public string TIN { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string StateId { get; set; }
        public string HousingUnits { get; set; }
        public string TotalArea { get; set; }
        public string WaterArea { get; set; }
        public string LandArea { get; set; }
        public string PopulationDensity { get; set; }
        public string HousingDensity { get;set; }

        public CensusDAO(IndianStateCensusModel indianStateCensusModel)
        {
            this.State = indianStateCensusModel.State;
            this.Population = indianStateCensusModel.Population;
            this.AreaInSqKm = indianStateCensusModel.AreaInSqKm;
            this.DensityPerSqKm = indianStateCensusModel.DensityPerSqKm;
        }

        public CensusDAO(IndianStateCodeModel indianStateCodeModel)
        {
            this.SrNo = indianStateCodeModel.SrNo;
            this.TIN = indianStateCodeModel.TIN;
            this.StateName = indianStateCodeModel.StateName;
            this.StateCode = indianStateCodeModel.StateCode;
        }

        public CensusDAO(USCensusModel uSCensusModel)
        {
            this.StateId = uSCensusModel.StateId;
            this.State = uSCensusModel.State;
            this.Population = uSCensusModel.Population;
            this.HousingDensity = uSCensusModel.HousingDensity;
            this.HousingUnits = uSCensusModel.HousingUnits;
            this.TotalArea = uSCensusModel.TotalArea;
            this.WaterArea = uSCensusModel.WaterArea;
            this.LandArea = uSCensusModel.LandArea;
            this.PopulationDensity = uSCensusModel.PopulationDensity;
            this.HousingDensity = uSCensusModel.HousingDensity;
        }
    }
}
