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
        const string usingDirectry = @"Debug";
        const string usingFile = @"testProject.xml";
        private static string usingPath = Path.Combine(center.DataBasePath,
                                           usingDirectry, usingFile);

        private static int plnNum;
        private static string plnName;
        private static string plnTarget;
        private static DateTime plnCreationD;
        private static string plnBelonging;
        private static int plnImportance;
        private static string plnStatus;

        private static string[] plnContentsList = new string[7] {"計画番号","計画名","計画目標","作成日","所属","重要性","状態" };
        private static string[] plnContents;

        private static int plnAmount;

        static readForm readForm;
        static detailForm detailForm;
        static xmlEditor xmlEditor;

        public void initializer()
        {
            xmlEditor = new xmlEditor();
            xmlEditor.xmlGetter(usingPath,"project");
            readForm = new readForm();
            detailForm = new detailForm();

            plnAmount = xmlEditor.maxItem("num");

            showReadView();
        }

        public void showReadView()
        {
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
            plnNum = num;
            setPlnContents();
            detailForm.showDetail(plnContentsList, plnContents);
        }

        private void cangeData()
        {

        }

        private void sortData()
        {

        }

        //xmlファイルの情報を表示
        private void showXML()
        {
            xmlEditor.xmlGetter(usingPath, "project");

            MessageBox.Show(xmlEditor.xmlReader());
        }

        private void setData()
        {
            plnName = xmlEditor.itemReader(plnNum.ToString(), "name");
            plnTarget = xmlEditor.itemReader(plnNum.ToString(), "target");
            plnCreationD = DateTime.Parse(xmlEditor.itemReader(plnNum.ToString(), "date"));
            plnBelonging = xmlEditor.itemReader(plnNum.ToString(), "belonging");
            plnImportance = (int)Int64.Parse(xmlEditor.itemReader(plnNum.ToString(), "importance"));
            plnStatus = xmlEditor.itemReader(plnNum.ToString(), "status");
        }

        private void setPlnContents()
        {
            setData();
            plnContents = new string[7] {plnNum.ToString(),plnName,plnTarget,plnCreationD.ToString(),
                plnBelonging,plnImportance.ToString(),plnStatus };
        }
    }
}
