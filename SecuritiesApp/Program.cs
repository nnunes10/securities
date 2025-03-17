// See https://aka.ms/new-console-template for more information
using SecuritiesApp;

// create host
// declare dependencies
// dbcontext
// IApiservice, ApiService
// Security Service and Repository

IApiService apiService = new ApiService();
ISecurityRepository securityRepository = new SecurityRepository();
ILogger logger = new Logger();
ISecurityService svc = new SecurityService(apiService, securityRepository, logger);

var result = svc.UpdatePrices(new List<Security>() { new Security() { ISIN = "sec12345874g" }, new Security() { ISIN = "sec99345874g" }, });


