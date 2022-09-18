using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;


namespace AutoTest
{
    public class MainPage:BasePage
    {
        private readonly By header = By.XPath("//*[@id='header_logo']");
        private readonly By buttonSignIn = By.XPath("//*[@class='login']");
        private readonly By headerAlreadyRegistered = By.XPath("//h3[contains(text() ,'Already registered?')]");

        public MainPage():base()
        {

        }

        public MainPage(ChromeDriver driver):base(driver)
        {

        }

        public bool CheckLoadMainPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                chromeDriver.Navigate().GoToUrl(TestSettings.mainPageURL);
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(header));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AuthenticationPage OpenAuthenticationPage()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                chromeDriver.Navigate().GoToUrl(TestSettings.mainPageURL);
                ClickElement(buttonSignIn);
                AuthenticationPage page = new AuthenticationPage(chromeDriver);
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
    }
}
