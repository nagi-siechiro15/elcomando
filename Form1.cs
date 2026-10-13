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
                    break;
                }

            }

            if (dataGridView1.Rows.Count == 0)
            {
                comboBox1.Items.Clear();
            }
        }
    }
}
