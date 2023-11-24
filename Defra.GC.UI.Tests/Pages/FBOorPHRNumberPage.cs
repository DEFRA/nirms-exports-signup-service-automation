

using BoDi;
using Defra.GC.UI.Tests.Configuration;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class FBOorPHRNumberPage : IFBOorPHRNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public FBOorPHRNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        #endregion Page Methods






    }
}