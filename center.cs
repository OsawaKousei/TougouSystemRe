using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TougouSystem.DebugForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TougouSystem
{
    public partial class center : Form
    {
        //Config.txtのファイルパスを格納
        private static string configPath =null;
        public string ConfigPath
        {
            get { return configPath; } 
        }

        const string configName = @"Config.txt";

        //データベースのファイルパスを格納
        private static string dataBasePath = null;
        public static string DataBasePath
        {
            get { return dataBasePath; }
        }

        //遷移画面登録
        debugForm01 debugForm01 = null;


        public center()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startCheck();
        }

        private void startCheck()
        {
            //Config.txtが存在することを確認して、ファイルパスを格納
            if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), configName)))
            {
                configPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), configName);
            }
            else
            {
                MessageBox.Show("Config.txtが見つかりません。\r\nアプリケーションを終了します", "center",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Close();
            }

            //Config.txtの内容を取得
            string path = @"C:\Users\jwith\OneDrive\Programing\workspace2-TougouSystem\TestData";

            //データベースフォルダが存在することを確認して、ファイルパスを格納
            if (Directory.Exists(path))
            {
                dataBasePath = path;
            }
            else
            {
                MessageBox.Show("データベースフォルダがが見つかりません。\r\nアプリケーションを終了します", "center",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Close();
            }

        }

        private void Debugbutton_Click(object sender, EventArgs e)
        {
            debugForm01 = new debugForm01();
            debugForm01.Show();
        }
    }
}
