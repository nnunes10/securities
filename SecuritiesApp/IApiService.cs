using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritiesApp
{
    public interface IApiService
    {
        double GetPrice(string ISIN);
    }
}
