using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace eydvzegvfbh
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=gestionprouduit;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
        DataTable Dt_produit_category = new DataTable();
        DataTable Dt_category = new DataTable();
        SqlDataAdapter adapterProduit;
        SqlDataAdapter adapterCategory;

        DataSet ds = new DataSet();
        SqlDataAdapter adapterJoin;


        private void Form3_Load(object sender, EventArgs e)
        {
            refresh();

        }

        private void refresh()
        {
            SqlConnection cnx = new SqlConnection(connectionString);

            adapterProduit = new SqlDataAdapter("SELECT * FROM products", cnx);
            adapterCategory = new SqlDataAdapter("SELECT * FROM category", cnx);

            adapterProduit.Fill(ds, "products");
            adapterCategory.Fill(ds, "category");

            string req = "SELECT p.id_product, p.name_product, c.id_category, c.name_category, p.prix, p.quantity, p.descriptions FROM products p INNER JOIN category c ON p.id_category = c.id_category";

            adapterJoin = new SqlDataAdapter(req, cnx);

            adapterJoin.Fill(ds, "ProduitCategory");

            dataGridView1.DataSource = ds.Tables["ProduitCategory"];

            comboBox1.DataSource = ds.Tables["products"];
            comboBox1.DisplayMember = "id_product";
            comboBox1.ValueMember = "id_product";

            comboBox2.DataSource = ds.Tables["category"];
            comboBox2.DisplayMember = "name_category";
            comboBox2.ValueMember = "id_category";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataRow dr = ds.Tables["products"].NewRow();

            dr["name_product"] = textBox1.Text;
            dr["prix"] = Convert.ToDecimal(textBox2.Text);
            dr["quantity"] = numericUpDown1.Value;
            dr["id_category"] = comboBox2.SelectedValue;
            dr["descriptions"] = richTextBox1.Text;

            ds.Tables["products"].Rows.Add(dr);




            MessageBox.Show("Produit ajouté !");
            refresh();
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(adapterProduit);

            adapterProduit.Update(ds.Tables["products"]);

            MessageBox.Show("Enregistrement réussi !");
            ds.Tables["ProduitCategory"].Clear();

            adapterJoin.Fill(ds, "ProduitCategory");

            dataGridView1.DataSource = ds.Tables["ProduitCategory"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
                return;

            int id = Convert.ToInt32(comboBox1.SelectedValue);

            DataRow[] lignes = ds.Tables["products"].Select("id_product = " + id);

            if (lignes.Length > 0)
            {
                lignes[0].Delete();

                MessageBox.Show("Produit supprimé !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
                return;
            int id = Convert.ToInt32(comboBox1.SelectedValue);

            DataRow[] lignes = ds.Tables["products"].Select("id_product = " + id);
            textBox1.Text = lignes[0]["name_product"].ToString();
            textBox2.Text = lignes[0]["prix"].ToString();
            numericUpDown1.Value = Convert.ToDecimal(lignes[0]["quantity"]);
            richTextBox1.Text = lignes[0]["descriptions"].ToString();
            comboBox2.SelectedValue = lignes[0]["id_category"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not DataRowView selectedProduct)
                return;

            DataRow product = selectedProduct.Row;
            int productId = Convert.ToInt32(product["id_product"]);

            textBox1.Text = product["name_product"].ToString();
            textBox2.Text = product["prix"].ToString();
            numericUpDown1.Value = Convert.ToDecimal(product["quantity"]);
            richTextBox1.Text = product["descriptions"].ToString();
            comboBox2.SelectedValue = product["id_category"];

            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow || row.Cells["id_product"].Value == null ||
                    row.Cells["id_product"].Value == DBNull.Value ||
                    Convert.ToInt32(row.Cells["id_product"].Value) != productId)
                {
                    continue;
                }

                dataGridView1.CurrentCell = row.Cells[0];
                row.Selected = true;
                break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
                return;

            if (!decimal.TryParse(textBox2.Text, out decimal prixValue))
            {
                MessageBox.Show("Veuillez saisir un prix valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(comboBox1.SelectedValue);
            DataRow[] lignes = ds.Tables["products"].Select("id_product = " + id);
            if (lignes.Length == 0)
                return;

            DataRow produit = lignes[0];
            produit["name_product"] = textBox1.Text;
            produit["id_category"] = comboBox2.SelectedValue;
            produit["prix"] = prixValue;
            produit["quantity"] = numericUpDown1.Value;
            produit["descriptions"] = richTextBox1.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow || row.Cells["id_product"].Value == null ||
                    row.Cells["id_product"].Value == DBNull.Value ||
                    Convert.ToInt32(row.Cells["id_product"].Value) != id)
                {
                    continue;
                }
                row.Cells["name_product"].Value = textBox1.Text;
                row.Cells["id_category"].Value = comboBox2.SelectedValue;
                row.Cells["prix"].Value = prixValue;
                row.Cells["quantity"].Value = numericUpDown1.Value;
                row.Cells["descriptions"].Value = richTextBox1.Text;
                break;
            }

            MessageBox.Show("Produit modifié en mémoire. Cliquez sur Enregistrer pour appliquer les changements à la base de données.");
        }

    }
}
