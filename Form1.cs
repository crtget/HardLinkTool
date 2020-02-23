using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace HardLinkTool
{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "CreateHardLink", CharSet = CharSet.Unicode)]
        public static extern bool CreateHardLink(string newFileName, string existiingFileName, IntPtr securityAttributes);

     

        public static void GetPathFiles(string path, ref List<string> result)
        {

            var files = Directory.GetFiles(path);
            string[] dirs = null;

            var p = new DirectoryInfo(path).Attributes & FileAttributes.System;

            dirs = Directory.GetDirectories(path);
      
            


            foreach (var f in files)
            {
                result.Add(f);
            }

            if (dirs != null)
            {
                foreach (var d in dirs)
                {
                    if ((new FileInfo(d).Attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        GetPathFiles(d, ref result);
                    }
                    
                }
            }


        }


        public bool MakeHardLink(string link, string target)
        {
            var d = Path.GetDirectoryName(link);

            if (!Directory.Exists(d))
            {
                Directory.CreateDirectory(d);
            }

            return CreateHardLink(link, target, IntPtr.Zero);
        }


        public bool MakeDirHardLink(string link, string target)
        {
            List<string> files = new List<string>();
            GetPathFiles(target, ref files);
            var result = true;


            foreach (var f in files)
            {
                var ff = f.Replace(target, link);
                var d = Path.GetDirectoryName(ff);

                if (!Directory.Exists(d))
                {
                    Directory.CreateDirectory(d);
                }

                if (!MakeHardLink(ff, f))
                    result = false;
            }

            return result;
        }





        public MainForm(string[] args)
        {
            InitializeComponent();

            var result = true;

            foreach(var a in args)
            {
                
                if (!File.Exists(a) && !Directory.Exists(a))
                    continue;

                var fname = a;

                if ((new FileInfo(fname).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    if (!MakeDirHardLink(new DirectoryInfo(fname).Parent.FullName + "\\" + new DirectoryInfo(fname).Name + "_Linked", a))
                        result = false;
                    
                }
                else
                {
                    if (!MakeHardLink(Path.GetDirectoryName(fname) + "\\" + Path.GetFileNameWithoutExtension(fname) + "_Linked" + Path.GetExtension(fname), a))
                        result = false;
                }
            }



            if (args.Length > 0)
            {

                if (!result)
                    ShowResult(result);

                this.Close();
            }
                

 
        }



        public void ShowResult(bool b)
        {
            if (b)
            {
                MessageBox.Show(this, "操作成功完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "操作完成，有错误发生！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {


          
            //




        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/crtget/HardLinkTool");
        }


        private void tbxtarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void tbxtarget_DragDrop(object sender, DragEventArgs e)
        {
            tbxtarget.Text = "";
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var f in files)
            {

                tbxtarget.Text += f;

                if (f != files[files.Length - 1])
                    tbxtarget.Text += "|";


            }
        }

        private void btnbrowser1_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            fd.Description = "请选择源路径";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbxtarget.Text = fd.SelectedPath;
            }

        }

        private void btnbrowser2_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            fd.Description = "请选链接路径";

            var target = tbxtarget.Text;

            if (target.Trim() != "")
            {
                fd.SelectedPath = target.Substring(0, 3); ;
            }

            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbxlink.Text = fd.SelectedPath;
            }
        }

        private void btnlink_Click(object sender, EventArgs e)
        {
            var target = tbxtarget.Text;
            var link = tbxlink.Text;
            var result = true;
            string[] files = null;

            if (target.Trim() == "" || link.Trim() == "")
                return;


            if (target.IndexOf("|") >= 0)
            {
                files = target.Split('|');
            }
            else
            {
                files = new string[] { target };
            }

            if (Path.GetPathRoot(link) != Path.GetPathRoot(files[0]))
            {
                MessageBox.Show(this, "硬链接路径必须在同一驱动器下！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            foreach (var f in files)
            {

                if (!File.Exists(f) && !Directory.Exists(f))
                    continue;


                if ((new FileInfo(f).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    MakeDirHardLink(link + "\\" + new DirectoryInfo(f).Name + "\\", f);
                }
                else
                {

                    if (!MakeHardLink(link + "\\" + Path.GetFileName(f), f))
                        result = false;

                }
            }

            ShowResult(result);



        }




    }

}
