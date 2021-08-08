using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSTravelSolution.Data.Filters
{
    public class LandmarkFilter
    {  
        private int _pageNumber;
        private int _pageSize;
        private string _search;
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value == 0 ? 1 : value; }
        }       

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value == 0? 10: value; }
        }        
        public string Search { 
            get => _search;
            set => _search =  value.ToLower();
        }
    }
}
