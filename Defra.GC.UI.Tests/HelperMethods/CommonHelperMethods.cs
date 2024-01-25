using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Defra.UI.Framework.Driver;

namespace Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods
{
    public static class CommonHelperMethods
    {
        public static void SelectFromDropdown(this IWebDriver driver, IWebElement Element, string Text)
        {
            SelectElement dropDown = new SelectElement(Element);
            dropDown.SelectByText(Text);
        }
        public static void ClickRadioButton(this IWebDriver driver, string code)
        {
            IWebElement commLabel = driver.WaitForElement(By.XPath($"//label[contains(.,'{code}')]"));
            //commLabel.Click();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
        }

        public static void ClickFristRadioButton(this IWebDriver driver, string code)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(d => d.FindElement(By.XPath($"//label[contains(text(),'{code}')]")).Text.Contains(code));
        }
    }
}
