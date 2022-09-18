using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class CasualDressesPage : BasePage
    {
        private readonly By iconPrintedDress = By.XPath("//*[@id='center_column']/ul/li/div");
        private readonly By iconPrintedDressMore = By.XPath("//*[@id='center_column']/ul/li/div/div[2]/div[2]/a[2]");
        public CasualDressesPage() : base()
        {

        }

        public CasualDressesPage(ChromeDriver driver) : base(driver)
        {

        }

        public PrintedDressPage OpenPrintedDressesPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                var action = new Actions(chromeDriver);
                webDriverWait.Until(ExpectedConditions.ElementExists(iconPrintedDress));
                IWebElement el = chromeDriver.FindElement(iconPrintedDress);
                action.MoveToElement(el).Perform();
                webDriverWait.Until(ExpectedConditions.ElementExists(iconPrintedDressMore)).Click();
                PrintedDressPage page = new PrintedDressPage(chromeDriver);
                if (page.PageLoaded())
                {
                    return page;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        public bool PageLoaded()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(iconPrintedDress));
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
