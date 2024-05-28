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
    public partial class Report : Form
    {
        private string file_name;

        public Report(string file_name)
        {
            this.file_name = file_name;

            InitializeComponent();
            SetName();
        }

        private void SetName()
        {
            groupBox1.Text = this.file_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
