namespace capa_de_presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form pain = new For2();
            pain.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form pain = new Form3();
            pain.Show();
        }
    }
}