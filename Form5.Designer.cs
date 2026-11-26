namespace eydvzegvfbh
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            produitToolStripMenuItem = new ToolStripMenuItem();
            categorieToolStripMenuItem = new ToolStripMenuItem();
            clientToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { produitToolStripMenuItem, categorieToolStripMenuItem, clientToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1388, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // produitToolStripMenuItem
            // 
            produitToolStripMenuItem.Name = "produitToolStripMenuItem";
            produitToolStripMenuItem.Size = new Size(72, 24);
            produitToolStripMenuItem.Text = "produit";
            produitToolStripMenuItem.Click += produitToolStripMenuItem_Click;
            // 
            // categorieToolStripMenuItem
            // 
            categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            categorieToolStripMenuItem.Size = new Size(86, 24);
            categorieToolStripMenuItem.Text = "categorie";
            categorieToolStripMenuItem.Click += categorieToolStripMenuItem_Click;
            // 
            // clientToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(61, 24);
            clientToolStripMenuItem.Text = "Client";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(1388, 723);
            panel1.TabIndex = 1;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 751);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem produitToolStripMenuItem;
        private ToolStripMenuItem categorieToolStripMenuItem;
        private ToolStripMenuItem clientToolStripMenuItem;
        private Panel panel1;
    }
}