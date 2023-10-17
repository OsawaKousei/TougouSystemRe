using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TougouSystem.DebugForm
{
    public partial class readForm : Form
    { 
        center center = new center();

        public readForm()
        {
            InitializeComponent();
        }

        private void readForm_Load(object sender, EventArgs e)
        {

        }

        private void readXML()
        {

        }

        public void makeList(string[] contentsList)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();


        }

        public void addList(string[] contents)
        {

        }
    }
}
