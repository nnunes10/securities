using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritiesApp
{
    public class ApiService : IApiService
    {
        public double GetPrice(string ISIN)
        {
            // make http call
            return 2.0;
        }
    }
}
