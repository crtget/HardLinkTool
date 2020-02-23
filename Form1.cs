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


        public void MakeHardLink(string link, string target)
        {
            var d = Path.GetDirectoryName(link);

            if (!Directory.Exists(d))
            {
                Directory.CreateDirectory(d);
            }

            CreateHardLink(link, target, IntPtr.Zero);
        }


        public void MakeDirHardLink(string link, string target)
        {
            List<string> files = new List<string>();

            GetPathFiles(target, ref files);


            foreach (var f in files)
            {
                var ff = f.Replace(target, link);
                var d = Path.GetDirectoryName(ff);

                if (!Directory.Exists(d))
                {
                    Directory.CreateDirectory(d);
                }

                MakeHardLink(ff, f);
            }
        }





        public MainForm(string[] args)
        {
            InitializeComponent();

            foreach(var a in args)
            {

                if (!File.Exists(a) && !Directory.Exists(a))
                    continue;

                var fname = a;

                if ((new FileInfo(fname).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    MakeDirHardLink(new DirectoryInfo(fname).Parent.FullName + "\\" + new DirectoryInfo(fname).Name + "_Linked", a);
                    
                }
                else
                {
                    MakeHardLink(Path.GetDirectoryName(fname) + "\\" + Path.GetFileNameWithoutExtension(fname) + "_Linked" + Path.GetExtension(fname), a);
                }
            }

  
 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {



            //




        }
    }
}
