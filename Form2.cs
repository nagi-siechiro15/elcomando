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
            DataTable datatable = new DataTable();

            SqlConnection cnx = new SqlConnection(connectionString);
            string requete = "SELECT * FROM category";
            cnx.Open();
            SqlCommand cmd = new SqlCommand(requete, cnx);
            SqlDataReader dr = cmd.ExecuteReader();

            /* while (dr.Read())
             {
                 comboBox2.Items.Add(dr[1].ToString());
                 comboBox2.SelectedIndex = 0;

             }*/

            datatable.Load(dr);
            comboBox2.DisplayMember = "name_category";
            comboBox2.ValueMember = "id_category";
            comboBox2.DataSource = datatable;
            datatable.Load(dr);






            dr.Close();
            cnx.Close();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("nom", "nom");
            dataGridView1.Columns.Add("prix", "prix");
            dataGridView1.Columns.Add("quantite", "quantite");
            dataGridView1.Columns.Add("description", "description");
            dataGridView1.Columns.Add("category", "category");

            using (SqlConnection productConnection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM product", productConnection))
            {
                DataTable products = new DataTable();
                adapter.Fill(products);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = products;






            }

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
