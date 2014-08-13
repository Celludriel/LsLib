using LSToolFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SamplePlugin
{
    public class SamplePlugin : IPlugin
    {
        public override bool Init()
        {
            System.Console.WriteLine("SamplePlugin.Init");
            this.RegisterPanel();
            return true;
        }

        public override bool Start()
        {
            System.Console.WriteLine("SamplePlugin.Start");
            return true;
        }

        public override bool Stop()
        {
            System.Console.WriteLine("SamplePlugin.Stop");
            return true;
        }

        public void RegisterPanel()
        {
            MenuBarService menuBarService = (MenuBarService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(MenuBarService));
            if (menuBarService == null)
                return;

            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = "SAMPLE MENU";
            menuItem.Text = "SAMPLE PLUGIN MENU";
            menuItem.Click += new EventHandler(this.SampleMenuHandler);
            menuBarService.InsertSubMenuItem("Modding", menuItem);
        }

        public void SampleMenuHandler(object sender, EventArgs e)
        {
            MessageBox.Show("I'm a sample plugin!", "Sample");
        }
    }
}
