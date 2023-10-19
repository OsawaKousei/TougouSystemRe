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
    public partial class textInputForm : Form
    {
        //ボタン押下イベント追加
        public delegate void buttonEventHandler(object sender, EventArgs e);
        public event buttonEventHandler buttonEvent;

        public string inputText;
        public textInputForm()
        {
            InitializeComponent();
        }

        private void changeForm_Load(object sender, EventArgs e)
        {

        }

        public void showText(string content)
        {
            viewTextBox.ReadOnly = true;
            viewTextBox.Text = content;
        }

        private void changeButton_onClick(object sender, EventArgs e)
        {
            inputText = inputTextBox.Text;
            this.buttonEvent(this, new EventArgs());
        }
    }
}
