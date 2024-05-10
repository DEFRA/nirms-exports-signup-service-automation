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

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private By LinkText => By.XPath("//p[@class='govuk-body']/a");
        private IWebElement StatusText => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Status')]/..//dd//div"));
        private IWebElement UpdatedDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Updated')]/following-sibling::dd"));
        private IWebElement RemovedDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Removed')]/following-sibling::dd"));
        private IWebElement AddedDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Added')]/following-sibling::dd"));
        private IWebElement EstablishmentRMS => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Establishment RMS number')]/following-sibling::dd"));
        private IWebElement EstAddress => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Address')]/following-sibling::dd"));
        private IWebElement EstEmailAddress => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email address')]/following-sibling::dd"));
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

        public bool VerifyEstablishmentDetailsTable(string establishmentName, string Eststatus, string addrPostcode)
        {
            string establishmentNameEle = "//a[contains(text(),'" + establishmentName + "')]";
            string postcodeEle = "//a[contains(text(),'" + establishmentName + "')]/../following-sibling::td[1]";
            string RMSNumberEle = "//a[contains(text(),'" + establishmentName + "')]/../following-sibling::td[2]";
            string StatusEle = "//a[contains(text(),'" + establishmentName + "')]/../following-sibling::td[3]/div";
            string UpdatedDateEle = "//a[contains(text(),'" + establishmentName + "')]/../following-sibling::td[4]";

            bool status = true;
            string sDate = DateTime.Now.ToString("dd MMM yyy");

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);

            if (_driver.WaitForElement(By.XPath(establishmentNameEle)).Text != establishmentName)
                status = false;
            string temp1 = _driver.WaitForElement(By.XPath(postcodeEle)).Text;
            if (_driver.WaitForElement(By.XPath(postcodeEle)).Text != addrPostcode)
                status = false;
            string temp2 = _driver.WaitForElement(By.XPath(StatusEle)).Text;
            if (_driver.WaitForElement(By.XPath(StatusEle)).Text != Eststatus)
                status = false;
            if (Eststatus != "Draft")
            { 
                string temp3 = _driver.WaitForElement(By.XPath(RMSNumberEle)).Text;
                if (!_driver.WaitForElement(By.XPath(RMSNumberEle)).Text.Contains("RMS"))
                    status = false; 
            }
            string temp4 = _driver.WaitForElement(By.XPath(UpdatedDateEle)).Text;
            if (!sDate.Contains(_driver.WaitForElement(By.XPath(UpdatedDateEle)).Text))
                status = false;
            return status;
        }

        public bool VerifyEstablishmentDetails(string establishmentName, string Eststatus, string addrPostcode, string emailAddress)
        {
            bool status = true;
            string sDate = DateTime.Now.ToString("dd MMMM yyy");

            if (Eststatus == "Draft")
            {
                if (!PageHeading.Text.Contains("Add a place of"))
                    status = false;

                string temp6 = EstAddress.Text;
                if (!EstAddress.Text.Contains(addrPostcode))
                    status = false;

                string temp7 = EstEmailAddress.Text;
                if (!EstEmailAddress.Text.Contains(emailAddress))
                    status = false;

                return status;
            }

            string temp = PageHeading.Text;
            if (!PageHeading.Text.Contains(establishmentName))
                status = false;

            string temp1 = StatusText.Text;
            if (!StatusText.Text.Contains(Eststatus))
                status = false;

            if (Eststatus.Contains("Removed"))
            {
                string temp12 = RemovedDate.Text;
                if (!RemovedDate.Text.Contains(sDate))
                    status = false;
            }
            else
            {
                string temp2 = UpdatedDate.Text;
                if (!sDate.Contains(UpdatedDate.Text))
                    status = false;
            }
            string temp3 = AddedDate.Text;
            if (!sDate.Contains(AddedDate.Text))
                status = false;

            string temp8 = EstablishmentRMS.Text;
            if (!EstablishmentRMS.Text.Contains("RMS"))
                status = false;

            string temp4 = EstAddress.Text;
            if (!EstAddress.Text.Contains(addrPostcode))
                status = false;

            string temp5 = EstEmailAddress.Text;
            if (!EstEmailAddress.Text.Contains(emailAddress))
                status = false;
            return status;
        }

        public void ClickOnEstablishment(string establishmentName)
        {
            string establishmentNameEle = "//a[contains(text(),'" + establishmentName + "')]";
            _driver.WaitForElement(By.XPath(establishmentNameEle)).Click();
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
