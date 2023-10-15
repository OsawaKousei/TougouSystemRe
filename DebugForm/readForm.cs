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

        const string usingDirectry = @"Debug";
        const string usingFile = @"debug.xml";
        private static string usingPath = Path.Combine(center.DataBasePath, 
                                           usingDirectry,usingFile);

        public readForm()
        {
            InitializeComponent();
        }

        private void readForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(usingPath);
            //使用するファイルが存在することを確認
            if (File.Exists(usingPath))
            {
                MessageBox.Show("使用するファイルを確認しました。");
            }
            else
            {
                MessageBox.Show("使用するファイルが見つかりません。\r\nフォームを閉じます", "readForm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void readXML()
        {
            //xmlファイルを指定する
            XElement xml = XElement.Load(@"C:sample.xml");

            //メンバー情報のタグ内の情報を取得する
            IEnumerable<XElement> infos = from item in xml.Elements("メンバー情報")
                                          select item;

            //メンバー情報分ループして、コンソールに表示
            foreach (XElement info in infos)
            {
                Console.Write(info.Element("名前").Value + @",");
                Console.Write(info.Element("住所").Value + @",");
                Console.WriteLine(info.Element("年齢").Value);
            }
        }
    }
}
