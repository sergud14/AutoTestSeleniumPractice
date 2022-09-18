using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class MyAccountPage:BasePage
    {
        private readonly By menuWomen = By.XPath("//*[@id='block_top_menu']/ul/li[1]/a");
        private readonly By menuDresses = By.XPath("//*[@id='block_top_menu']/ul/li[2]/a");
        private readonly By menuTShirt = By.XPath("//*[@id='block_top_menu']/ul/li[3]/a");
        private readonly By submenuCasualDresses = By.XPath("//a[@title='Casual Dresses']/img");

        public MyAccountPage() : base()
        {

        }

        public MyAccountPage(ChromeDriver driver) : base(driver)
        {

        }

        public DressesPage OpenDressesPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(menuDresses)).Click();
                var dressesPage = new DressesPage(chromeDriver);
                if (dressesPage.PageLoaded())
                {
                    return dressesPage;
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
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(menuWomen));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

