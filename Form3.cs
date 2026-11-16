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
    }
}
