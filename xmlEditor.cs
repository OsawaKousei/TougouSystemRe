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
        private static string mainNumber = null;

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

        //xmlファイルを読み込み
        public void xmlGetter(string path, string main, string mainNum)
        {
            if (checkPath(path))
            {
                xml = XElement.Load(path);
                xdoc = XDocument.Load(path);
                mainCategory = main;
                mainNumber = mainNum;
            }
        }

        //xmlファイル全体を取得
        public string xmlReader()
        {
            return xdoc.ToString();
        }

        //指定されたアイテムの最大値を求める
        public int maxItem(string item)
        {
            int max = (
                from p in xml.Elements(mainCategory)
                select int.Parse(p.Element(item).Value)).Max();
            return max;
        }

        //数値順に並び替え
        public int[] numericSort(string target, string option)
        {
            int[] result = new int[maxItem(mainNumber)];
            int i = 0;

            IOrderedEnumerable<XElement> sortedRes = null;

            if (option == "descending")
            {
                sortedRes = (
                     from p in xml.Elements(mainCategory)
                     orderby int.Parse(p.Element(target).Value) descending
                     select p);
            }
            else
            {
                sortedRes = (
                    from p in xml.Elements(mainCategory)
                    orderby int.Parse(p.Element(target).Value)
                    select p);
            }

            foreach(var res in sortedRes)
            {
                result[i] = int.Parse(res.Element(mainNumber).Value);
                i++;
            }

            return result;
        }

        //指定した要素値を持つものだけ抜き出し
        public int[] extractiveSort(string targt, string selection)
        {
            int[] result = new int[maxItem(mainNumber)];
            int i = 0;

            var sortedRes = (
                 from p in xml.Elements(mainCategory)
                 where p.Element(targt).Value == selection
                 select p);

            foreach (var res in sortedRes)
            {
                result[i] = int.Parse(res.Element(mainNumber).Value);
                i ++;
            }

            Array.Resize(ref result, i-1);
            return result;
        }

        //指定されたアイテムを取得
        public string itemReader(string num, string target) 
        {
            var res = (
                 from p in xml.Elements(mainCategory)
                 where p.Element(mainNumber).Value == num
                 select p).Single();

            return res.Element(target).Value;
        }

        //指定されたアイテムを上書き
        public void itemWriter(string num, string target, string contents)
        {
            var res = (
                 from p in xml.Elements(mainCategory)
                 where p.Element(mainNumber).Value == num
                 select p).Single();

            res.Element(target).Value = contents;
        }
    }
}
