using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCheating
{
    public interface ISiteAction
    {
        void SetParams(params string[] args);

        void Run(ref SiteDriver driver);
    }
}
