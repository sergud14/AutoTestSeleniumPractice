using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class DressesPage : BasePage
    {
        private readonly By iconDress = By.XPath("//*[@id='center_column']/descendant::a[@title='Printed Dress']");
        private readonly By submenuCasualDress = By.XPath("//*[@id='subcategories']/ul/li[1]/div[1]/a");

        public DressesPage() : base()
        {

        }

        public DressesPage(ChromeDriver driver) : base(driver)
        {

        }

        public CasualDressesPage OpenCasualDressesPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(submenuCasualDress)).Click();
                var casualDressesPage = new CasualDressesPage(chromeDriver);
                if (casualDressesPage.PageLoaded())
                {
                    return casualDressesPage;
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
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(iconDress));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
