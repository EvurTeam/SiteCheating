using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCheating
{
    class ClickAction : ISiteAction
    {
        public string PrimaryCssSelector { set; get; }
        public string AlternateCssSelector { set; get; }

        public void SetParams(params string[] args)
        {
            PrimaryCssSelector = args[0];
            AlternateCssSelector = args[1];
        }

        public void Run(ref SiteDriver driver)
        {

        }
    }
}
