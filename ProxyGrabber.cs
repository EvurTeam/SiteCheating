using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SiteCheating.FakeView;

namespace SiteCheating
{
    public static class ProxyGrabber
    {
        public static List<string> GetAll(SiteDriver driver, string pagingPattern, int startPage)
        {
            var list = new List<string>();
            int currentPage = startPage;
            while (true)
            {
                var currentUrl = pagingPattern.Replace("$PAGE$", currentPage.ToString());
                Log($"-> {currentUrl}");
                driver.Navigate(currentUrl);
                try
                {
                    var gp1 = driver.GetElementsBySelector("tr.spy1x td[colspan]:first-child .spy14");
                    if (gp1 == null || gp1.Length < 1)
                    {
                        Log("Страница не имеет прокси");
                        break;
                    }
                    var gp2 = driver.GetElementsBySelector("tr.spy1xx td[colspan]:first-child .spy14");
                    var tmp = gp1.Concat(gp2);
                    list.AddRange(tmp.Select(x => x.Text));
                } catch
                {
                    break;
                }
                currentPage++;
            }
            return list;
        }
    }
}
