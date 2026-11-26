using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eydvzegvfbh
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        product_ctrl product_Ctrl = new product_ctrl();
        category_ctrl category_Ctrl = new category_ctrl();      

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is UserControl)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            product_ctrl p = new product_ctrl();
            p.Dock = DockStyle.Fill;
            panel1.Controls.Add(p);



        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is UserControl)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            product_Ctrl = new product_ctrl();
            product_Ctrl.Dock = DockStyle.Fill;
            panel1.Controls.Add(product_Ctrl);

        }
        

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is UserControl)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            category_Ctrl= new category_ctrl();
            category_Ctrl.Dock = DockStyle.Fill;
            panel1.Controls.Add(category_Ctrl);
        }

    }
  }

