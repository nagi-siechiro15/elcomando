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
            comboBox1.Items.Add(cont+1);
            comboBox1.Text = (cont +1 ).ToString();
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
