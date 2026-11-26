using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eydvzegvfbh
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        UserControl1 userControl1 = new UserControl1();
        UserControl2 userControl2 = new UserControl2();

        private void Form4_Load(object sender, EventArgs e)
        {


        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (userControl2.Dock == DockStyle.Fill&& userControl2 != null)
            {
                this.Controls.Remove(userControl2);

            }
            userControl1 = new UserControl1();
            userControl1.Dock = DockStyle.Fill;
            this.Controls.Add(userControl1);


        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userControl1.Dock == DockStyle.Fill&& userControl1 != null)
            {
                this.Controls.Remove(userControl1);
            }
            userControl2 = new UserControl2();
            userControl2.Dock = DockStyle.Fill;
            this.Controls.Add(userControl2);
        }


    }
}
