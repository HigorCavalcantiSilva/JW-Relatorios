using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JW_Reports
{
    public partial class Config : Form
    {
        private Form1 form;

        public Config(Form1 form)
        {
            this.form = form;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Configura as propriedades do diálogo
                folderBrowserDialog.Description = "Selecione uma pasta";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.ShowNewFolderButton = true;

                // Mostra o diálogo e verifica se o usuário selecionou uma pasta
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtém o caminho da pasta selecionada
                    string selectedPath = folderBrowserDialog.SelectedPath;

                    richTextBox1.Text = selectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form.FolderFilesPdf = richTextBox1.Text;
            form.type = comboBox1.SelectedIndex.ToString();
            form.FillGroups();
            this.Dispose();
        }
    }
}
