using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace AutoTest
{
    public class ShoppingCartSummaryPage : BasePage
    {
        private By buttonProceedTabSummary = By.XPath("//a[@title='Proceed to checkout'][@class='button btn btn-default standard-checkout button-medium']");
        private By buttonProceed = By.XPath("//span[contains(text(),'Proceed')]//parent::button");

        private By tabAddressToDo = By.XPath("//li[@class='step_todo third']");
        private By tabAddressCurrent = By.XPath("//li[@class='step_current third']");

        private By tabShippingToDo = By.XPath("//li[@class='step_todo four']");
        private By tabShippingCurrent = By.XPath("//li[@class='step_current four']");
      
        private By checkboxTermsOfService = By.XPath("//div[@class='checker']");
        private By checkboxTermsOfServiceChecked = By.XPath("//input[@type='checkbox']//parent::span[@class='checked']");

        private By tabPaymentToDo = By.XPath("//li[@class='step_todo last']");
        private By tabPaymentCurrent = By.XPath("//li[@class='step_current last']");

        public ShoppingCartSummaryPage() : base()
        {
        }

        public ShoppingCartSummaryPage(ChromeDriver driver) : base(driver)
        {
        }

        public bool OpenAddressTab()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabAddressToDo));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonProceedTabSummary)).Click();
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabAddressCurrent));
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool OpenShippingTab()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabAddressCurrent));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabShippingToDo));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonProceed)).Click();
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabShippingCurrent));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool OpenPaymentTab()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabShippingCurrent));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabPaymentToDo));
                IWebElement iWebElement1 = chromeDriver.FindElement(checkboxTermsOfService);
                IWebElement iWebElement2 = chromeDriver.FindElement(buttonProceed);
                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                ////js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                //js.ExecuteScript("arguments[0].scrollIntoView();", iWebElement1);
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(checkboxTermsOfService)).Click();
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(checkboxTermsOfServiceChecked));
                //js.ExecuteScript("arguments[0].scrollIntoView();", iWebElement2);
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonProceed));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonProceed)).Click();
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tabPaymentCurrent));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PageLoaded()
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonProceedTabSummary));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tabLoaded(By tab)
        {
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(tab));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
