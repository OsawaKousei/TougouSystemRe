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
    public partial class listViewForm : Form
    { 
        //詳細選択イベント追加
        public delegate void DetailEventHandler(object sender, EventArgs e);
        public event DetailEventHandler DetailEvent;

        public  string[] selectedItems = new string[0];
        public listViewForm()
        {
            InitializeComponent();
        }

        private void readForm_Load(object sender, EventArgs e)
        {

        }

        private void readXML()
        {

        }

        //リストビューの初期設定
        public void makeList(string[] contentsList)
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (string content in contentsList)
            {
                listView1.Columns.Add(content);
            }

            foreach (ColumnHeader ch in listView1.Columns)
            {
                ch.Width = -2;
            }

            listView1.HoverSelection = true;
            listView1.Activation = ItemActivation.TwoClick;
            listView1.ItemActivate += new EventHandler(listView1_ItemActivate);
        }

        //リストビューに内容を追加
        public void addList(string[] contents)
        {
            listView1.Items.Add(new ListViewItem(contents));
        }

        //アイテムがアクティブになった時
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem itemx = listView1.SelectedItems[0];

            Array.Resize(ref selectedItems, itemx.SubItems.Count);
            for (int i=0; i < itemx.SubItems.Count; i++)
            {
                selectedItems[i] = itemx.SubItems[i].Text;
            }

            this.DetailEvent(this, new EventArgs());
        }
    }
}
