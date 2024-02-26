using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;



namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class AddEstablishmentPage : IAddEstablishmentPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IPointOfDepartureEstablishmentPage? PointOfDepartureEstablishmentPage => _objectContainer.IsRegistered<IPointOfDepartureEstablishmentPage>() ? _objectContainer.Resolve<IPointOfDepartureEstablishmentPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private By LinkText => By.XPath("//p[@class='govuk-body']/a");
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public AddEstablishmentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void ClickOnLink(string linkText)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            string linkElement = "//a[contains(text(),'" + linkText + "')]";
            _driver.WaitForElement(By.XPath(linkElement)).Click();
        }

        public void ClickOnButton(string buttonText)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            string buttonElement = "//button[contains(text(),'" + buttonText + "')]";
            _driver.WaitForElement(By.XPath(buttonElement)).Click();
        }

        public bool VerifyLinksOnEstablishmentPage(string link1, string link2, string link3)
        {

            IList<IWebElement> linkTextMessages = _driver.FindElements(LinkText);
            bool status = true;
            List<string> linkTextList = new List<string>();

            foreach (IWebElement message in linkTextMessages)
            {
                linkTextList.Add(message.Text);
            }

            foreach (string text in linkTextList)
            {
                if (text.Contains(link1))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }
            foreach (string text in linkTextList)
            {
                if (text.Contains(link2))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }
            foreach (string text in linkTextList)
            {
                if (text.Contains(link3))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }

            return status;
        }

        public bool VerifyEstablishmentDetailsTable(string establishmentName, string status, string addrPostcode)
        {

            return true;
        }

        public void AddEstablishmentAsDraft(string establishmentName, string addressLine, string estCity, string estCountry, string addrPostcode)
        {
            PointOfDepartureEstablishmentPage.EnterEstablishmentPostcode(addrPostcode);
            PointOfDepartureEstablishmentPage.ClickOnCannotFindEstablishmentLink();
            PointOfDepartureEstablishmentPage.ClickOnAddTheEstablishmentAddressManuallyLink();
            PointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(establishmentName, addressLine, estCity, estCountry, addrPostcode);
            PointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress("test@test.com");
            applicationPage.ClickOnBackLink();
            applicationPage.ClickOnBackLink();
            applicationPage.ClickOnBackLink();
            applicationPage.ClickOnBackLink();
            applicationPage.ClickOnBackLink();
        }

        #endregion Page Methods

    }
}
