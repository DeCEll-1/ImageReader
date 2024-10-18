using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReadingScreen readingScreen = new ReadingScreen();
            bool a = true;
            foreach (var item in this.MdiChildren)
            {
                if (item.GetType() == readingScreen.GetType())
                {
                    this.ActivateMdiChild(item);
                    readingScreen.BringToFront();
                    a = false;
                    break;
                }
            }
            if (a)
            {
                readingScreen.MdiParent = this;
                readingScreen.Show();
            }
        }
        public void UpdatePage(string s)
        {
            TSSL_PageNumber.Text = s;
        }
    }
}
