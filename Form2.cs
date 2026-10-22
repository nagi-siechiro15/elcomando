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
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=gestionprouduit;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // methode 2
            DataTable datatable = new DataTable();

            SqlConnection cnx = new SqlConnection(connectionString);
            string requete = "SELECT p.id_product,  p.name_product, c.id_category,c.name_category FROM " +
                "products p INNER JOIN category c  ON p.id_category = c.id_category;";
            cnx.Open();
            SqlCommand cmd = new SqlCommand(requete, cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            datatable.Load(dr);
            comboBox2.DisplayMember = "name_category";
            comboBox2.ValueMember = "id_category";
            comboBox2.DataSource = datatable;
            dataGridView1.DataSource = datatable;

            if (dataGridView1.Columns["id_category"] != null)
            {
                dataGridView1.Columns["id_category"].Visible = false;
            }

            // Renommer les titres des colonnes du DataGridView
            dataGridView1.Columns["id_product"].HeaderText = "ID Produit";
            dataGridView1.Columns["name_product"].HeaderText = "Nom du Produit";
            dataGridView1.Columns["name_category"].HeaderText = "Catégorie";

            cnx.Close();
            /*dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("nom", "nom");
            dataGridView1.Columns.Add("prix", "prix");
            dataGridView1.Columns.Add("quantite", "quantite");
            dataGridView1.Columns.Add("description", "description");
            dataGridView1.Columns.Add("category", "category");*/
            // metod 
            /*  DataTable datatable = new DataTable();

              SqlConnection cnx = new SqlConnection(connectionString);
              string requete = "SELECT * FROM category";
              cnx.Open();
              SqlCommand cmd = new SqlCommand(requete, cnx);
              SqlDataReader dr = cmd.ExecuteReader();
            // while dans la methode 0
             while (dr.Read())
               {
                   comboBox2.Items.Add(dr[1].ToString());
                   comboBox2.SelectedIndex = 0;

               }

              datatable.Load(dr);
              comboBox2.DisplayMember = "name_category";
              comboBox2.ValueMember = "id_category";
              comboBox2.DataSource = datatable;
              DataTable datatable2 = new DataTable();


              requete = "SELECT * FROM products";

              SqlCommand cmd1 = new SqlCommand(requete, cnx);
              SqlDataReader dr1 = cmd1.ExecuteReader();

              datatable2.Load(dr1);
              dataGridView1.DataSource = datatable2;
              dr1.Close();




              dr.Close();
              cnx.Close();


              */





        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    MessageBox.Show("Connexion réussie !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox2.SelectedValue.ToString());
            
        }
    }
}
