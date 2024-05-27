using System.Windows.Forms;

namespace JW_Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillGroups();
        }

        private Label labelSelected;

        private void FillGroups()
        {
            for (int i = 0; i < 5; i++)
            {
                Label label = new();
                label.Text = $"TESTE {i}";
                label.AutoSize = true;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.BackColor = SystemColors.Control;

                label.Click += new EventHandler(Label_Click);

                tableLayoutPanel1.Controls.Add(label, 0, i);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            // Desmarca o Label previamente selecionado
            if (labelSelected != null)
            {
                labelSelected.BackColor = SystemColors.Control;
            }

            // Marca o novo Label como selecionado
            label.BackColor = Color.LightBlue;
            labelSelected = label;

            listBox1.Items.Clear();
            listBox1.Items.Add("TESTE MEU CHAPA");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            
            if(listBox.SelectedIndex != -1)
            {
                Report report = new Report(listBox.Text);
                report.ShowDialog();
            }
        }
    }
}
