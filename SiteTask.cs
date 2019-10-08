using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCheating
{
    public class SiteTask
    {
        public string Url { set; get; }
        public Queue<ISiteAction> Actions { set; get; }

        public SiteTask(string url, Queue<ISiteAction> actions)
        {
            Url = url;
            Actions = actions;
        }

        public void Run(ref SiteDriver driver)
        {
            foreach (var action in Actions)
            {
                action.Run(ref driver);
            }
        }
    }
}
