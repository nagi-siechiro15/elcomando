namespace eydvzegvfbh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("nom", "nom");
            dataGridView1.Columns.Add("prix", "prix");
            dataGridView1.Columns.Add("quantite", "quantite");
            dataGridView1.Columns.Add("description", "description");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var champsManquants = new List<string>();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                champsManquants.Add("Nom du produit");
                textBox1.Clear();
            }

            float prix;
            if (string.IsNullOrWhiteSpace(textBox2.Text) || !float.TryParse(textBox2.Text, out prix) || prix <= 0f)
            {
                champsManquants.Add("Prix");
                textBox2.Clear();
            }

            if (numericUpDown1.Value <= 0)
            {
                champsManquants.Add("Quantité");
                numericUpDown1.Value = 0;
            }


            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                champsManquants.Add("Description");
                richTextBox1.Clear();
            }


            if (champsManquants.Count > 0)
            {
                MessageBox.Show(
                    $"Veuillez remplir les champs suivants : {string.Join(", ", champsManquants)}.",
                    "Champs manquants",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int cont = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {

                    cont++;
                }
            }

            dataGridView1.Rows.Add(cont + 1, textBox1.Text, textBox2.Text, numericUpDown1.Value, richTextBox1.Text);
            comboBox1.Items.Add(cont + 1);
            comboBox1.Text = (cont + 1).ToString();
            clearinput();
        }

        private void clearinput()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == comboBox1.SelectedItem.ToString())
                    {
                        textBox1.Text = row.Cells[1].Value.ToString();
                        textBox2.Text = row.Cells[2].Value.ToString();
                        numericUpDown1.Value = Convert.ToDecimal(row.Cells[3].Value);
                        richTextBox1.Text = row.Cells[4].Value.ToString();

                    }
                }
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == comboBox1.SelectedItem.ToString())
                {
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    numericUpDown1.Value = Convert.ToDecimal(row.Cells[3].Value);
                    richTextBox1.Text = row.Cells[4].Value.ToString();

                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.");
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == comboBox1.SelectedItem.ToString())
                    {
                        textBox1.Text = row.Cells[1].Value.ToString();
                        textBox2.Text = row.Cells[2].Value.ToString();
                        numericUpDown1.Value = Convert.ToDecimal(row.Cells[3].Value);
                        richTextBox1.Text = row.Cells[4].Value.ToString();
                        dataGridView1.ClearSelection();
                        dataGridView1.CurrentCell = row.Cells[0];
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

                    }



                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == comboBox1.SelectedItem.ToString())
                {
                    row.Cells[1].Value = textBox1.Text;
                    row.Cells[2].Value = textBox2.Text;
                    row.Cells[3].Value = numericUpDown1.Value;
                    row.Cells[4].Value = richTextBox1.Text;
                    clearinput();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Sélectionnez un ID à supprimer.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == comboBox1.SelectedItem.ToString())
                {
                    dataGridView1.Rows.Remove(row);

                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    clearinput();

                    if (dataGridView1.Rows.Count == 1)
                    {
                        comboBox1.Items.Clear();
                        comboBox1.Text = "";
                    }
                    break;
                }

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {



            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[0].IsNewRow)
                return;

            DataGridViewRow row = dataGridView1.Rows[0];

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = row.Cells[0];
            row.Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

            textBox1.Text = Convert.ToString(row.Cells[1].Value);
            textBox2.Text = Convert.ToString(row.Cells[2].Value);
            richTextBox1.Text = Convert.ToString(row.Cells[4].Value);

            if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal valeur))
            {
                numericUpDown1.Value = Math.Min(
                    Math.Max(valeur, numericUpDown1.Minimum),
                    numericUpDown1.Maximum);
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {

            int lastRowIndex = dataGridView1.Rows.Count
        - (dataGridView1.AllowUserToAddRows ? 2 : 1);

            if (lastRowIndex < 0)
                return; // Aucune ligne contenant des données

            DataGridViewRow row = dataGridView1.Rows[lastRowIndex];

            dataGridView1.CurrentCell = row.Cells[0];
            row.Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

            textBox1.Text = Convert.ToString(row.Cells[1].Value);
            textBox2.Text = Convert.ToString(row.Cells[2].Value);
            richTextBox1.Text = Convert.ToString(row.Cells[4].Value);

            if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal valeur))
            {
                numericUpDown1.Value = Math.Min(
                    Math.Max(valeur, numericUpDown1.Minimum),
                    numericUpDown1.Maximum);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int indexActuel = dataGridView1.CurrentCell?.RowIndex ?? -1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (indexActuel >= 0 && row.Index == indexActuel + 1)
                {
                    dataGridView1.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    textBox1.Text = Convert.ToString(row.Cells[1].Value);
                    textBox2.Text = Convert.ToString(row.Cells[2].Value);
                    richTextBox1.Text = Convert.ToString(row.Cells[4].Value);
                    if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal valeur))
                    {
                        numericUpDown1.Value = Math.Min(
                            Math.Max(valeur, numericUpDown1.Minimum),
                            numericUpDown1.Maximum);
                    }
                    break;
                }

            }




        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int indexActuel = dataGridView1.CurrentCell?.RowIndex ?? -1;
                if (indexActuel > 0 && row.Index == indexActuel - 1)
                {
                    dataGridView1.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    textBox1.Text = Convert.ToString(row.Cells[1].Value);
                    textBox2.Text = Convert.ToString(row.Cells[2].Value);
                    richTextBox1.Text = Convert.ToString(row.Cells[4].Value);
                    if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal valeur))
                    {
                        numericUpDown1.Value = Math.Min(
                            Math.Max(valeur, numericUpDown1.Minimum),
                            numericUpDown1.Maximum);
                    }
                    break;
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string chemin = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                 + "\\produits.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(chemin))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            continue;
                        }

                        string[] valeur = new string[dataGridView1.Columns.Count];

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            valeur[i] = row.Cells[i].Value?.ToString() ?? string.Empty;
                        }

                        writer.WriteLine(string.Join(";", valeur));
                    }
                }

                MessageBox.Show(
                    "Les données ont été exportées avec succès vers le fichier produits.txt sur le bureau.",
                    "Exportation réussie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Une erreur s'est produite lors de l'exportation : {ex.Message}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


    }
}