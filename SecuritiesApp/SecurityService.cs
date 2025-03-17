using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritiesApp
{
    public class SecurityService : ISecurityService
    {

        private readonly IApiService _apiService;
        private readonly ISecurityRepository _securityRepository;
        private readonly ILogger _logger;

        public SecurityService(IApiService apiService, ISecurityRepository repository, ILogger logger)
        {
            _apiService = apiService;
            _securityRepository = repository;
            _logger = logger;
        }

        //public Security GetSecurity(string ISIN)
        //{
        //    return _securityRepository.GetSecurity(ISIN);
        //}

        //public Security Save(Security security)
        //{
        //    return _securityRepository.Save(security);
        //}

        public SecurityResult UpdatePrices(IList<Security> securities)
        {
            SecurityResult retVal = new SecurityResult();
            retVal.Securities = new List<Security>();

            foreach (var security in securities)
            {
                if (!this.IsValid(security))
                {
                    _logger.Error($"The security ISIN = {security.ISIN} is not valid.");
                    continue;
                }

                double price = _apiService.GetPrice(security.ISIN);
                Security record = _securityRepository.GetSecurity(security.ISIN);

                record.Price = price;
                Security updatedSecurity = _securityRepository.Save(record);
                retVal.Securities.Add(updatedSecurity);
            }

            return retVal;
        }

        private bool IsValid(Security security)
        {
            return security.ISIN is not null &&
                security.ISIN.Length == 12;
        }

    }
}
