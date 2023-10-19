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
    public partial class debugForm01 : Form
    {
        public debugForm01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void readButton_Click(object sender, EventArgs e)
        {
            testPlan testPlan = new testPlan();
            testPlan.initializer();
        }

        private void debugForm01_Load(object sender, EventArgs e)
        {

        }
    }
}
