using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class BasePage
    {
        protected readonly ChromeDriver chromeDriver;
        protected readonly WebDriverWait webDriverWait;

        public BasePage()
        {

        }

        public BasePage(ChromeDriver driver)
        {
            this.chromeDriver = driver;
            webDriverWait = new WebDriverWait(this.chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));
        }

        protected bool ClickElement(By element)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool InsertText(By element,string text)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element)).SendKeys(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
