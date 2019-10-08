using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SiteCheating.FakeView;

namespace SiteCheating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetDisplay(textBox2);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPageUrl.Text))
            {
                Log("Адрес страницы не указан!");
                return;
            }
            var url = tbPageUrl.Text;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = $"http://{url}";
            }
            var tabName = tabControl1.SelectedTab.Text;
            string selector = string.Empty;
            string selector2 = string.Empty;
            switch (tabName)
            {
                case "Клик":
                    selector = tClickTbCss.Text;
                    selector2 = tClickTbCss2.Text;
                    break;
                default:
                    throw new Exception($"tabName: {tabName}");
            }
            if (HaseNodeWithTitle(url, out var node))
            {
                node.Nodes.Add(url);
            } else
            {
                node = treeView1.Nodes.Add(url);
            }
        }

        bool HaseNodeWithTitle(string title, out TreeNode node)
        {
            node = null;
            foreach (TreeNode item in treeView1.Nodes)
            {
                if (item.Text == title)
                {
                    node = item;
                    return true;
                }
            }
            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> proxyList = new List<string>();
            using (var tmpDriver = SiteDriver.Create())
            {
                Log("Получение списка прокси...");
                proxyList = ProxyGrabber.GetAll(tmpDriver, "http://spys.one/proxies/$PAGE$/",  0);
                var len = proxyList.Count;
                if (len > 0)
                {
                    Log($"Прокси получены ({len} шт.)");
                    SetDisplay(textBox3);
                    foreach (var item in proxyList)
                    {
                        Log(item);
                    }
                    SetDisplay(textBox2);
                }
                else
                {
                    Log($"Не удалось получить список прокси");
                }
            }
            
            var driver = SiteDriver.Create(proxyList);
        }
    }
}
