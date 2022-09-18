using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class PrintedDressPage : BasePage
    {
        private readonly By listboxSize = By.XPath("//*[@id='group_1']");
        private readonly By listboxItemSize = By.XPath("//*[@id='group_1']/option[@title='M']");
        private readonly By listboxItemSizeSelected = By.XPath("//div[@id='uniform-group_1']/span[text()='M']");
        private readonly By buttonAddToCart = By.XPath("//*[@id='add_to_cart']/button");
        private readonly By byModalWindow = By.XPath("//*[@id='category']/div[2]");

        public PrintedDressPage() : base()
        {

        }

        public PrintedDressPage(ChromeDriver driver) : base(driver)
        {

        }

        public bool SelectSize()
        {
            bool result = false;
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementExists(listboxSize)).Click();
                webDriverWait.Until(ExpectedConditions.ElementExists(listboxItemSize)).Click();
                webDriverWait.Until(ExpectedConditions.ElementExists(listboxItemSizeSelected));
                result = true;
            }
            catch
            {

            }

            return result;
        }

        public OrderInfoModalWindow AddToCart()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                webDriverWait.Until(ExpectedConditions.ElementExists(buttonAddToCart)).Click();
                var orderInfoModalWindow = new OrderInfoModalWindow(chromeDriver);
                if (orderInfoModalWindow.WindowLoaded())
                {
                    return orderInfoModalWindow;
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
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonAddToCart));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
