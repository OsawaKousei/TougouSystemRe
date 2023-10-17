using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TougouSystem
{
    internal class xmlEditor
    {
        private static XElement xml = null;
        private static XDocument xdoc = null;
        private static string mainCategory = null;

        //指定のファイルが存在することを確認
        private bool checkPath(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("目的のxmlファイルが見つかりません。\r\n操作を終了します", "xmlEditor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        //xmlファイル新規作成
        public void fileCreator(string path,string fileName)
        {

        }

        //xmlファイル削除
        public void fileDeleter(string path)
        {

        }

        //xmlファイルを読み込み
        public void xmlGetter(string path, string main)
        {
            if (checkPath(path))
            {
                xml = XElement.Load(path);
                xdoc = XDocument.Load(path);
                mainCategory = main;
            }
        }

        //xmlファイル全体を取得
        public string xmlReader()
        {
            return xdoc.ToString();
        }

        //xmlファイル全体を上書き
        public void xmlWriter(string contents)
        {

        }

        //指定のアイテムが存在することを確認
        public bool checkItem(string itemPath)
        {
            return true;
        }

        //指定されたアイテムを数える
        public int countItem(string item)
        {
            return 1;
        }

        //指定されたアイテムを読み込み
        public void itemGetter(string path)
        {
            if (checkItem(path))
            {

            }
        }

        //指定されたアイテムを取得
        public void itemWriter()
        {

        }

        //指定されたアイテムを上書き
        public string itemReader(string num, string contents) 
        {
            var res = (
                 from p in xml.Elements(mainCategory)
                 where p.Element("num").Value == num
                 select p).Single();

            MessageBox.Show(res.Element(contents).Value);

            return res.Element(contents).Value;
        }
    }
}
