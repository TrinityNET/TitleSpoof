using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitleSpoof
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            Task.Run(() => Spoofer.Populate(dataGridView1));
        }

        private void thirteenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()))
                {
                    if (string.IsNullOrEmpty(thirteenTextBox1.Text))
                    {
                        MessageBox.Show("Please enter a window title!", "TitleSpoof by Centos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        new TitleSpoof.WindowSpoofer().Set(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(), thirteenTextBox1.Text, 0);
                        dataGridView1.Rows.Clear();
                        Task.Run(() => Spoofer.Populate(dataGridView1));
                    }
                }
                else
                {
                    MessageBox.Show("Please select a cell with a value!", "TitleSpoof by Centos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Unknown error.", "TitleSpoof by Centos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thirteenButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Task.Run(() => Spoofer.Populate(dataGridView1));
        }
    }
}
