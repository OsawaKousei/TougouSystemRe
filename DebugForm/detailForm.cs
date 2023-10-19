using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TougouSystem.DebugForm
{
    public partial class detailForm : Form
    {
        public detailForm()
        {
            InitializeComponent();
        }

        private void detailForm_Load(object sender, EventArgs e)
        {

        }

        public void showDetail(string[] contentsList, string[] contnts)
        {
            richTextBox1.ReadOnly = true;

            for(int i = 0; i < contentsList.Length; i++)
            {
                richTextBox1.Text += contentsList[i] + "：" + contnts[i] + "\r\n";
            }
        } 
    }
}
