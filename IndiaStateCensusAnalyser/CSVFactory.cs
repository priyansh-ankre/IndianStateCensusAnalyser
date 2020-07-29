using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaStateCensusAnalyser
{
    class CSVFactory : CSVBuilder
    {
        char ExceptionType;
        public CSVFactory(char ExceptionType)
        {
            this.ExceptionType = ExceptionType;
        }
        public void CheckForException()
        {
            switch (ExceptionType)
            {
                case 'H':
                    throw new IndianStateAnalyserException("this is a wrong header", IndianStateAnalyserException.ExceptionType.HEADER_NOT_MATCHED_EXCEPTION);
                case 'W':
                    throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.WRONG_CSV_DELIMITER_EXCEPTION);
                case 'C':
                    throw new IndianStateAnalyserException("this is wrong file path", IndianStateAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM_EXCEPTION);
                case 'N':
                    throw new IndianStateAnalyserException("this is a wrong file type", IndianStateAnalyserException.ExceptionType.NOT_CSV_FILE_EXCEPTION);
                default:
                    break;
            }
        }

    }
}
