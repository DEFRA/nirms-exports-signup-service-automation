using OpenQA.Selenium;

namespace Defra.GC.UI.Tests.Capabilities
{
    public interface IDriverOptions
    {
        DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null);
    }
}
