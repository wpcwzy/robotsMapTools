using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace RobotsMapTool
{
    public partial class menu : Form
    {
        public bool isSaved=false;
        string path;
        string MapData;
        uint speed;
        string[] map = new string[1]; 

        public menu()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isSaved)
            {
                if(MessageBox.Show("确定要关闭程序吗？", "关闭程序", MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk)==DialogResult.OK)//文件已保存
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                if(MessageBox.Show("是否不保存直接关闭程序？", "关闭程序", MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk)==DialogResult.OK)//文件已保存
                {
                    Environment.Exit(0);
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "地图配置文件|*.ini|所有文件|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                Debug.WriteLine(path);
                MapData=File.ReadAllText(path);
                Debug.WriteLine(MapData);

            }
            if (path != "")
            { 
                int num;
                ReadFileButton.Enabled = true;
               // num=Convert.ToInt16(File.ReadLines(path));
                //string[] map = new string[num];    //FIXME:Wrong string init and convert.
                Debug.WriteLine(num);

            }
            else
            {
                ReadFileButton.Enabled = false;
            }
        }


        private void AboutmeMapToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            speed =Convert.ToUInt16(textBox1.Text);
            Debug.WriteLine(speed);
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            map = MapData.Split('L');//FIXIT:Split wrong.
            Debug.WriteLine(MapData);
            Debug.WriteLine(map);
        }
    }
}
