using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    public class AuthenticationPage:BasePage
    {
        private readonly By headerAlreadyRegistered = By.XPath("//h3[contains(text() ,'Already registered?')]");
        private readonly By inputEmail = By.XPath("//input[@id='email']");
        private readonly By inputPassword = By.XPath("//input[@name='passwd']");
        private readonly By buttonSignIn = By.XPath("//button[@id='SubmitLogin']");

        public AuthenticationPage() : base()
        {

        }

        public AuthenticationPage(ChromeDriver driver) : base(driver)
        {

        }

        public MyAccountPage SignIn()
        {
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(TestSettings.explicitWaitFromSeconds));

            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(inputEmail)).SendKeys("sergud@bk.ru");
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(inputPassword)).SendKeys("qwerty");
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonSignIn)).Click();
                chromeDriver.Navigate().GoToUrl(TestSettings.mainPageURL);
                ClickElement(buttonSignIn);
                MyAccountPage myAccountPage = new MyAccountPage(chromeDriver);
                if (myAccountPage.PageLoaded())
                {
                    return myAccountPage;
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
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(headerAlreadyRegistered));
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
