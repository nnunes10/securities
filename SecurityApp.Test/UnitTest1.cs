using NuGet.Frameworks;
using SecuritiesApp;

namespace SecurityApp.Test
{
    // create test services, but ideally would be with Moq framework
    public class TestApiService : IApiService
    {
        public double GetPrice(string ISIN)
        {
            return 2.0;
        }
    }

    public class TestSecurityRepository : ISecurityRepository
    {
        public Security GetSecurity(string ISIN)
        {
            return new Security();
            {
                ISIN = ISIN;
            }
        }

        public Security Save(Security security)
        {
            return security;
        }
    }

    public class TestLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine("[Error] " + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        public void Warn(string message)
        {
            Console.WriteLine("[WARN] " + message);
        }
    }

    public class UnitTest1
    {

        [Fact]
        public void TestHappyFlow()
        {
            // given            
            IApiService apiService = new TestApiService();
            ISecurityRepository securityRepository = new TestSecurityRepository();
            ILogger logger = new TestLogger();
            ISecurityService svc = new SecurityService(apiService, securityRepository, logger);                       
            
            var securities = new List<Security>() { 
                new Security() { ISIN = "sec12345874g", Price = 0 }, 
                new Security() { ISIN = "sec99345874g", Price = 0 }
            };

            // when
            SecurityResult result = svc.UpdatePrices(securities);

            Assert.NotNull(result);
            Assert.NotNull(result.Securities);
            Assert.NotEmpty(result.Securities);
            Assert.Equal(securities.Count, result.Securities.Count);

            // then
            foreach (Security security in result.Securities)
            {
                Assert.Equal(2.0, security.Price);
            }

        }

        [Fact]
        public void TestUnHappyFlow()
        {
            var invalidSecurity = new Security() { ISIN = "12" , Price = 0};

            // given

            IApiService apiService = new TestApiService();
            ISecurityRepository securityRepository = new TestSecurityRepository();
            ILogger logger = new TestLogger();
            ISecurityService svc = new SecurityService(apiService, securityRepository, logger);

            var securities = new List<Security>() {
                invalidSecurity
            };

            // when
            SecurityResult result = svc.UpdatePrices(securities);

            // then
            Assert.NotNull(result);
            Assert.NotNull(result.Securities);
            Assert.Empty(result.Securities);
        }
    }
}