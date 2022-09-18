using OpenQA.Selenium.Chrome;

namespace AutoTest
{
    public class BaseTest
    {
        public ChromeDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(TestSettings.implicitWaitFromSeconds);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TestSettings.implicitWaitFromSeconds);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(TestSettings.implicitWaitFromSeconds);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}