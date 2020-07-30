using System;

namespace IndiaStateCensusAnalyser
{
    public class IndianStateAnalyserException : Exception
    {
        
        public enum ExceptionType
        {
            NOT_CSV_FILE_EXCEPTION,
            CENSUS_FILE_PROBLEM_EXCEPTION,
            WRONG_CSV_DELIMITER_EXCEPTION,
            HEADER_NOT_MATCHED_EXCEPTION
        }
        public ExceptionType type;
        public IndianStateAnalyserException(string message,ExceptionType type)
            : base(message)
        {
            this.type = type;
        }
    }
}
