using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TougouSystem.DebugForm
{
    internal class testPlan
    {
        //xmlファイルの設定
        const string usingDirectry = @"Debug";
        const string usingFile = @"testProject.xml";
        private static string usingPath = Path.Combine(center.DataBasePath,
                                           usingDirectry, usingFile);

        //計画情報
        private static int plnNum;
        private string[] plnContentsList = new string[7] {"計画番号","計画名","計画目標","作成日","所属","重要性","状態" };
        private static string[] plnContents = new string[7];
        private static string[] writableTable = new string[7] {"不可","不可","不可","不可","不可","可","可"};
        private static int plnAmount;

        static listViewForm readForm;
        static listViewForm detailForm;
        static textInputForm changeForm;
        static xmlEditor xmlEditor;

        public void initializer()
        {
            //xmlファイルの読み込みとxmlエディタの初期化
            xmlEditor = new xmlEditor();
            xmlEditor.xmlGetter(usingPath,"計画","計画番号");
            plnAmount = xmlEditor.maxItem("計画番号");

            showReadView();
        }

        public void showReadView()
        {
            //初期化
            refreshForm();
            readForm = new listViewForm();
            readForm.DetailEvent += delegate (object sender, EventArgs e) { showDetailView(int.Parse(readForm.selectedItems[0])); };

            //一覧に計画リストを格納
            readForm.makeList(plnContentsList);
            plnNum = 1;
            for(int i=0 ;i < plnAmount; i++)
            {
                setPlnContents();
                readForm.addList(plnContents);
                plnNum++;
            }
            plnNum = 1;

            readForm.Show();
        }

        public void showDetailView(int num)
        {
            //初期化
            refreshForm();
            detailForm = new listViewForm();
            detailForm.DetailEvent += delegate (object sender, EventArgs e)
            { if (detailForm.selectedItems[3] == "不可")
                {
                    MessageBox.Show("この項目は書き込み不可です", "testPlan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
                else { showChangeView(int.Parse(detailForm.selectedItems[0]), detailForm.selectedItems[1], detailForm.selectedItems[2]); }
                };

            //計画詳細を格納
            detailForm.makeList(new string[] {"項目番号","タイトル","内容","書き込み"});
            plnNum = num;
            setPlnContents();

            string[] strings = new string[4];
            for (int i = 0; i < plnContents.Length; i++)
            {
                strings[0] = i.ToString();
                strings[1] = plnContentsList[i].ToString();
                strings[2] = plnContents[i].ToString();
                strings[3] = writableTable[i].ToString();
                detailForm.addList(strings);
            }
            detailForm.Show();
        }

        private void showChangeView(int target, string title, string current)
        {
            //初期化
            refreshForm();
            changeForm = new textInputForm();
            changeForm.buttonEvent += delegate (object sender, EventArgs e) { changeData(target, changeForm.inputText); };

            changeForm.showText(title + "を変更しようとしています。\r\n現在の値は" + current + "です。\r\n");

            changeForm.Show();
        }

        //全ての子フォームを閉じる
        private void refreshForm()
        {
            if (readForm != null && readForm.IsDisposed == false)
            {
                readForm.Close();
                readForm = null;
            }
            if(detailForm != null && detailForm.IsDisposed == false)
            {
                detailForm.Close();
                detailForm = null;
            }
        }

        private void sortData()
        {

        }

        //xmlファイルの情報を表示
        private void showXML()
        {
            xmlEditor.xmlGetter(usingPath, "計画","計画番号");

            MessageBox.Show(xmlEditor.xmlReader());
        }

        //計画情報を格納
        private void setPlnContents()
        {
            for (int i = 0; i < 7; i++)
            {
                plnContents[i] = xmlEditor.itemReader(plnNum.ToString(), plnContentsList[i]);
            }
        }

        private void changeData(int target, string content)
        {
            plnContents[target] = content;

            for(int i = 0; i < 7; i++)
            {
                xmlEditor.itemWriter(plnNum.ToString(), plnContentsList[target],content);
            }

            MessageBox.Show(plnContentsList[target] +"を"+content+"に変更しました。\r\n");

            showReadView();
        }
    }
}
