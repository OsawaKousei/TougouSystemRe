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
            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (string content in contentsList)
            {
                listView1.Columns.Add(content);
            }

            //ListView1のすべての列を自動調節
            foreach (ColumnHeader ch in listView1.Columns)
            {
                ch.Width = -2;
            }

            //ポイントで選択できるようにする
            listView1.HoverSelection = true;
            //ダブルクリックでアクティブにできるようにする
            listView1.Activation = ItemActivation.TwoClick;
            //ItemActivateイベントハンドラの追加
            listView1.ItemActivate += new EventHandler(listView1_ItemActivate);
        }

        public void addList(string[] contents)
        {
            listView1.Items.Add(new ListViewItem(contents));
        }

        //アイテムがアクティブになった時
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            // 選択項目があるかどうかを確認する
            if (listView1.SelectedItems.Count == 0)
            {
                // 選択項目がないので処理をせず抜ける
                return;
            }

            // 選択項目を取得する
            ListViewItem itemx = listView1.SelectedItems[0];
        }
    }
}
