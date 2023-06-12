using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Capabilities
{
    public interface IDriverOptions
    {
        DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null);
    }
}
