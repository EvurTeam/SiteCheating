using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteCheating
{
    public static class FakeView
    {
        private static TextBox Display { set; get; }

        public static void SetDisplay(TextBox tb)
        {
            Display = tb;
        }

        public static void Log(params object[] data)
        {
            if (data.Length > 1)
                Display.AppendText($"{data.Aggregate((p, c) => $"{p} {c}")}\n");
            else
                Display.AppendText($"{data[0]}\n");
        }
    }
}
