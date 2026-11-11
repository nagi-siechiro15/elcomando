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
            refresh();


        }

        private void refresh()
        {
            // methode 2
            DataTable datatable = new DataTable();

            SqlConnection cnx = new SqlConnection(connectionString);
            string requete = "SELECT p.id_product,  p.name_product, c.id_category,c.name_category, p.prix, p.quantity, p.descriptions FROM " +
                "products p INNER JOIN category c  ON p.id_category = c.id_category ;";
            cnx.Open();
            SqlCommand cmd = new SqlCommand(requete, cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            datatable.Load(dr);

            dataGridView1.DataSource = datatable;
            comboBox1.DisplayMember = "id_product";
            comboBox1.ValueMember = "id_product";
            comboBox1.DataSource = datatable;
            comboBox1.SelectedIndex = -1;

            if (dataGridView1.Columns["id_category"] != null)
            {
                dataGridView1.Columns["id_category"].Visible = false;
            }

            // Renommer les titres des colonnes du DataGridView
            dataGridView1.Columns["id_product"].HeaderText = "ID Produit";
            dataGridView1.Columns["name_product"].HeaderText = "Nom du Produit";
            dataGridView1.Columns["name_category"].HeaderText = "Catégorie";
            dataGridView1.Columns["prix"].HeaderText = "prix";
            dataGridView1.Columns["quantity"].HeaderText = "quantity";
            dataGridView1.Columns["descriptions"].HeaderText = "descriptions";

            requete = "SELECT * FROM category";
            cmd = new SqlCommand(requete, cnx);
            dr = cmd.ExecuteReader();
            DataTable dtCategory = new DataTable();
            dtCategory.Load(dr);
            comboBox2.DataSource = dtCategory;
            DataTable productDataTable = datatable.Copy(); // Copie des données des produits pour une utilisation ultérieure
            // Création d'une nouvelle ligne pour "All"
            DataRow allRow = dtCategory.NewRow();
            allRow["id_category"] = -1;
            allRow["name_category"] = "All";

            // Insertion au tout début de la table
            dtCategory.Rows.InsertAt(allRow, 0);

            // Affectation au ComboBox
            comboBox2.DataSource = dtCategory;
            comboBox2.DisplayMember = "name_category";
            comboBox2.ValueMember = "id_category";

            //  cmd.Parameters.AddWithValue("@id_category", comboBox2.SelectedItem);
            int categoryId;
            if (int.TryParse(comboBox2.SelectedValue.ToString(), out categoryId) && categoryId == -1)
            {
                // Afficher tous les produits si "All" est sélectionné
                dataGridView1.DataSource = productDataTable;

            }
            try
            {
                using (SqlConnection cnx1 = new SqlConnection(connectionString))
                {
                    cnx1.Open();

                    string reqProducts = "SELECT p.id_product, p.name_product, c.id_category, c.name_category, p.prix, p.quantity, p.descriptions " +
                                         "FROM products p INNER JOIN category c ON p.id_category = c.id_category;";

                    using (SqlCommand cmd1 = new SqlCommand(reqProducts, cnx1))
                    {
                        using (SqlDataReader dr1 = cmd1.ExecuteReader())
                        {
                            // NE METTEZ PAS "DataTable" ici ! On utilise directement la variable globale :
                            productDataTable.Clear();
                            productDataTable.Load(dr1);
                        }
                    }

                    // Assigner le DataTable global au DataGridView
                    dataGridView1.DataSource = productDataTable;
                    cnx1.Close();
                    // ... (reste de votre configuration des colonnes et des combobox)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

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
            SqlConnection cnx = new SqlConnection(connectionString);
            cnx.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO products (name_product, id_category, prix, quantity," +
                " descriptions) VALUES (@name, @id_category, @prix, @quantity, @descriptions)", cnx);

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id_category", comboBox2.SelectedValue);
            if (decimal.TryParse(textBox2.Text, out decimal prixValue))
            {
                cmd.Parameters.AddWithValue("@prix", prixValue);
            }
            else
            {
                cmd.Parameters.AddWithValue("@prix", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@quantity", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@descriptions", richTextBox1.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Produit ajouté avec succès !");

            refresh(); // Rafraîchir les données après l'ajout du produit









        }
        DataTable productDataTable1 = new DataTable(); // Déclaration de la variable au niveau de la classe

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox2.SelectedValue == null)
            {
                return;
            }
            if (comboBox2.SelectedIndex == 0)
            {
                string requete1 = "SELECT p.id_product, p.name_product, c.id_category, " +
                                        "c.name_category, p.prix, p.quantity, p.descriptions FROM " +
                                        "products p INNER JOIN category c ON p.id_category = c.id_category ";
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    using (SqlCommand cmd1 = new SqlCommand(requete1, cnx))
                    using (SqlDataReader dr1 = cmd1.ExecuteReader())
                    {
                        productDataTable1.Load(dr1);
                    }
                }
                dataGridView1.DataSource = productDataTable1;
                return;
            }
            int categoryId;
            // 2. On essaie de convertir proprement la valeur sélectionnée en entier
            if (int.TryParse(comboBox2.SelectedValue.ToString(), out categoryId))
            {
                // 3. Si l'ID est -1, cela correspond à "All"
                if (categoryId == -1)
                {

                    dataGridView1.DataSource = productDataTable1;
                    return;
                }

                // 4. Sinon, on filtre par l'ID de la catégorie
                try
                {
                    using (SqlConnection cnx1 = new SqlConnection(connectionString))
                    {
                        string requete = "SELECT p.id_product, p.name_product, c.id_category, " +
                                         "c.name_category, p.prix, p.quantity, p.descriptions FROM " +
                                         "products p INNER JOIN category c ON p.id_category = c.id_category " +
                                         "WHERE c.id_category = @id_category;";
                        cnx1.Open();

                        using (SqlCommand cmd = new SqlCommand(requete, cnx1))
                        {
                            // On utilise 'categoryId' (qui est un int) au lieu de comboBox2.SelectedValue
                            cmd.Parameters.AddWithValue("@id_category", categoryId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                dt.Load(dr);
                                dataGridView1.DataSource = dt;
                            }
                        }
                        cnx1.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue == null)
                return;

            string idProduit = comboBox1.SelectedValue.ToString();
            if (comboBox1.SelectedItem is DataRowView drv)
            {
                textBox1.Text = drv["name_product"]?.ToString();
                textBox2.Text = drv["prix"]?.ToString();

                if (drv["quantity"] != DBNull.Value)
                    numericUpDown1.Value = Convert.ToDecimal(drv["quantity"]);

                richTextBox1.Text = drv["descriptions"]?.ToString();

                if (drv["id_category"] != DBNull.Value)
                {
                    comboBox2.SelectedValue = drv["id_category"];
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(connectionString);
            cnx.Open();
            SqlCommand cmd = new SqlCommand("UPDATE products SET name_product = @name, id_category = @id_category, prix = @prix, quantity = @quantity," +
                " descriptions = @descriptions WHERE id_product = @id_product", cnx);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id_category", comboBox2.SelectedValue);

            cmd.Parameters.AddWithValue("@prix", decimal.TryParse(textBox2.Text, out decimal prixValue));
                
            cmd.Parameters.AddWithValue("@quantity", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@id_product", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@descriptions", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            cnx.Close();
            refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE id_product = @id_product", cnx);
                cmd.Parameters.AddWithValue("@id_product", comboBox1.SelectedValue);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}               

