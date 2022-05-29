using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace SeqCounterX
{
    public class UtilX
    {
        public static string GetTimeStringNow()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");

        }
       
        public static string ReadFileToStr(string filePath)
        {
            filePath = UtilX.ReplaceSeparatorChar(filePath);
            if (!File.Exists(filePath))
            {
                return "";
            }
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static void SaveStrToFile(string content, string filePath)
        {
            filePath = UtilX.ReplaceSeparatorChar(filePath);
            if (!File.Exists(filePath))
            {
                return;
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }

        }

        public static string CallCMD(string input)
        {
            //Console.WriteLine("请输入要执行的命令:");
            //string strInput = Console.ReadLine();
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(input + "&exit");

            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string output = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            Console.WriteLine(output);

            // Console.ReadKey();
            return output;
        }

        public static bool CheckPath(string path)
        {
            if(path == null || path == "")
            {
                return false;
            }
            path = ReplaceSeparatorChar(path);
            if(!Directory.Exists(path) && !File.Exists(path))
            {
                return false;
            }
            return true;
        }

        public static bool CheckFilePath(string filePath)
        {
            if (filePath == null || filePath == "")
            {
                return false;
            }
            filePath = ReplaceSeparatorChar(filePath);
            if (Directory.Exists(filePath))
            {
                return false;
            }
            if (!File.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        public static bool CheckFolderPath(string folderPath)
        {
            if(folderPath == null || folderPath == "")
            {
                return false;
            }
            folderPath = ReplaceSeparatorChar(folderPath);
            if (File.Exists(folderPath))
            {
                return false;
            }
            if (!Directory.Exists(folderPath))
            {
                return false;
            }
            return true;
        }

        public static string ReplaceSeparatorChar(string path)
        {
            return UtilX.ReplaceSeparatorChar(path, Path.DirectorySeparatorChar);
        }

        public static string ReplaceSeparatorChar(string path, char separatorChar)
        {
            path = path.Replace('/', separatorChar);
            path = path.Replace('\\', separatorChar);
            return path;
        }

        public static string EncodeEscapeStr(string content)
        {
            if (StrIsEmpty(content))
            {
                return content;
            }
            string myContent = content;
            myContent = myContent.Replace(" ", "&nbsp");
            myContent = myContent.Replace("\n", "\\n");
            myContent = myContent.Replace("\t","\\t");
            myContent = myContent.Replace(" ", "&emsp");
            return myContent;
        }

        public static string DecodeEscapeStr(string content)
        {
            if (StrIsEmpty(content))
            {
                return content;
            }
            string myContent = content;
            myContent = myContent.Replace("&nbsp", " ");
            myContent = myContent.Replace("\\n", "\n");
            myContent = myContent.Replace("\\t", "\t");
            myContent = myContent.Replace("&emsp", " ");
            return myContent;
        }

        public static bool StrIsEmpty(string content)
        {
            if(content == null || content == "")
            {
                return true;
            }
            return false;
        }

        public static bool ShowConfirmWindow(string content, string title)
        {
            if (StrIsEmpty(content))
            {
                content = "您确认要执行此操作吗？";
            }
            if (StrIsEmpty(title))
            {
                title = "提示";
            }
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel;
            DialogResult dialogResult = MessageBox.Show(content, title, messageBoxButtons);
            if (dialogResult != DialogResult.OK)
            {
                return false;
            }
            return true;
        }
    }
}
