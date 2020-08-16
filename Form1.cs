using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS多语言启动器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
                private string OpenSubKey(RegistryKey key, string name, string value)
                {
                    try
                    {
                        return key.OpenSubKey(name).GetValue(value).ToString();
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
        */
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.muruoxi.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Dictionary<string, string> ps = new Dictionary<string, string>();
                ps.Add("cs6", OpenSubKey(photoshop, "60.0", "ApplicationPath"));
                for (int i = 13,j = 7;i<=20 ;i++,j++)
                {
                    ps.Add("cc"+i.ToString(), OpenSubKey(photoshop, j.ToString()+"0.0", "ApplicationPath"));
                }*/
            try
            {
                string path = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Adobe\Photoshop\120.0").GetValue("ApplicationPath").ToString();
                string cn = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat";
                string en = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat.bak";
                FileInfo file = new FileInfo(en);
                if (file.Exists)
                {
                    file.MoveTo(cn);
                }
                if (File.Exists(cn))
                {
                    Process process = new Process();
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(path + "Photoshop.exe");
                    process.StartInfo = processStartInfo;
                    if (!process.Start())
                    {
                        MessageBox.Show("启动失败，你的PS是正常安装的吗？");
                    }
                    else
                    {
                        ShowInTaskbar = false;
                        Hide();
                        Task.Delay(60 * 1000);
                        File.Move(cn, en);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("您用的是精简版的PS？？？");
                }
            }
            catch
            {
                MessageBox.Show("Adobe PhotoShop CC 2018 产品未被正确安装！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Adobe\Photoshop\120.0").GetValue("ApplicationPath").ToString();
                string cn = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat";
                string en = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat.bak";
                FileInfo file = new FileInfo(cn);
                if (file.Exists)
                {
                    file.MoveTo(en);
                }
                if (File.Exists(en))
                {
                    Process process = new Process();
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(path + "Photoshop.exe");
                    process.StartInfo = processStartInfo;
                    if (!process.Start())
                    {
                        MessageBox.Show("启动失败，你的PS是正常安装的吗？");
                    }
                    else
                    {
                        ShowInTaskbar = false;
                        Hide();
                        Task.Delay(60 * 1000);
                        File.Move(en, cn);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("您用的是精简版的PS？？？");
                }
            }
            catch
            {
                MessageBox.Show("Adobe PhotoShop CC 2018 产品未被正确安装！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Adobe\Photoshop\120.0").GetValue("ApplicationPath").ToString();
            string cn = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat";
            string en = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat.bak";
            if (File.Exists(en))
            {
                File.Move(en, cn);
            }
            MessageBox.Show("设置成功！");
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Adobe\Photoshop\120.0").GetValue("ApplicationPath").ToString();
            string cn = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat";
            string en = path + @"Locales\zh_CN\Support Files\tw10428_Photoshop_zh_CN.dat.bak";
            if (File.Exists(cn))
            {
                File.Move(cn, en);
            }
            MessageBox.Show("设置成功！");
            Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
    }
}
