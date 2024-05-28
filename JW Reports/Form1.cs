using System.IO;
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

        private string _folderFilesPdf;
        private string _type;

        public string FolderFilesPdf { get => _folderFilesPdf; set => _folderFilesPdf = value; }
        public string type { get => _type; set => _type = value; }

        private void FillNamesByFolder(string? folder = "")
        {
            // Limpa o ListBox e preenche com os nomes dos arquivos na pasta selecionada
            listBox1.Items.Clear();
            string selectedFolderPath = !string.IsNullOrEmpty(folder) ? folder : FolderFilesPdf; // Obtem o caminho da pasta selecionada
            if (!string.IsNullOrEmpty(selectedFolderPath) && Directory.Exists(selectedFolderPath))
            {
                string[] files = Directory.GetFiles(selectedFolderPath, "*.pdf");

                Array.Sort(files);

                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file).Replace(".pdf", ""));
                }
            }
        }

        public void FillGroups()
        {

            if(this.type == "1")
            {
                string selectedFolderPath = FolderFilesPdf; // Obtém o caminho da pasta selecionada
                if (!string.IsNullOrEmpty(selectedFolderPath) && Directory.Exists(selectedFolderPath))
                {
                    string[] directories = Directory.GetDirectories(selectedFolderPath);

                    int i = 0;
                    // Adiciona os nomes das pastas ao ListBox
                    foreach (string directory in directories)
                    {
                        Label label = new();
                        label.Text = $"{Path.GetFileName(directory)}";
                        label.AutoSize = true;
                        label.BorderStyle = BorderStyle.FixedSingle;
                        label.BackColor = SystemColors.Control;

                        label.Click += new EventHandler(Label_Click);

                        tableLayoutPanel1.Controls.Add(label, 0, i++);
                    }
                }
            }
            else
            {
                this.FillNamesByFolder();
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

            this.FillNamesByFolder($"{this.FolderFilesPdf}\\{labelSelected.Text}");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            if (listBox.SelectedIndex != -1)
            {
                Report report = new Report(listBox.Text);
                report.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config config = new(this);
            config.ShowDialog();
        }
    }
}
