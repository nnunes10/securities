using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritiesApp
{
    public interface ISecurityService
    {
        //Security GetSecurity(string ISIN);

        SecurityResult UpdatePrices(IList<Security> securities);
    }
}
