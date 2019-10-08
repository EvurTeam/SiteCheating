using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SiteCheating
{
    public class SiteDriver : IDisposable
    {
        private ChromeDriver driver { set; get; }

        public static SiteDriver Create()
        {
            var tmp = new SiteDriver();
            tmp.driver = new ChromeDriver();
            return tmp;
        }

        public static SiteDriver Create(List<string> proxyList)
        {
            var tmp = new SiteDriver();
            tmp.driver = new ChromeDriver();
            // todo add proxy
            return tmp;
        }

        private SiteDriver()
        {

        }

        public void Navigate(string url)
        {
            driver.Url = url;
        }

        public void ClickToElement(string selector)
        {
            driver.FindElementByCssSelector(selector).Click();
        }

        public IWebElement[] GetElementsBySelector(string selector)
        {
            var elements = driver.FindElementsByCssSelector(selector);
            var arr = new IWebElement[elements.Count];
            elements.CopyTo(arr, 0);
            return arr;
        }

        public void Dispose()
        {
            driver.Close();
            driver.Quit();
        }
    }
}