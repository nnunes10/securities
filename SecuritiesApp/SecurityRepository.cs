using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritiesApp
{
    public class SecurityRepository : ISecurityRepository
    {

        public Security GetSecurity(string ISIN)
        {
            return new Security()
            {
                ISIN = ISIN,
            };
        }

        public Security Save(Security security)
        {
            // instatiate db context
            // edit record & save
            return security;
        }

    }
}
