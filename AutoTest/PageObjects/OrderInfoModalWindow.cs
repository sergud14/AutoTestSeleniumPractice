using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class OrderInfoModalWindow : BasePage
    {
        private readonly By headerModalWindow = By.XPath("//*[@id='layer_cart']//h2[contains(.,'successfully')]");
        private readonly By buttonProceed = By.XPath("//a[@title='Proceed to checkout']");

        public OrderInfoModalWindow() : base()
        {

        }

        public OrderInfoModalWindow(ChromeDriver driver) : base(driver)
        {

        }

        public ShoppingCartSummaryPage OpenShoppingCartSummaryPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                webDriverWait.Until(ExpectedConditions.ElementExists(buttonProceed)).Click();
                var shoppingCartSummaryPage = new ShoppingCartSummaryPage(chromeDriver);
                if (shoppingCartSummaryPage.PageLoaded())
                {
                    return shoppingCartSummaryPage;
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

        public bool WindowLoaded()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(headerModalWindow));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
