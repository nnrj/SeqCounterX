namespace SeqCounterX
{
    using System;

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using System.Text;

    using System.Threading.Tasks;

    using SeqCounterX.Model;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    // using System.ComponentModel;
  




    // using Utils.Zip;
    public partial class SeqCounterXForm : Form
    {
        private string scqxSettingJsonPath = "./sqcxSetting.json";

        private string scqxSettingJsonStr = "";

        private ScqxSettingEntity scqxSetting = new ScqxSettingEntity();

        private SettingEntity setting = new SettingEntity();

        private string settingJsonStr = "";

        private string settingJsonPath = @".\ini\setting.json";

        /// <summary>
        /// 声明代理
        /// </summary>
        private delegate void SetTextCallBack(string text);

        public SeqCounterXForm()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string seqCounterPath = UtilX.ReplaceSeparatorChar(scqxSetting.seqCOunterCore);
            if (UtilX.StrIsEmpty(seqCounterPath))
            {
                ShowNotice("请配置内核！", NoticeType.ERROR);
                return;
            }
            if (!File.Exists(seqCounterPath))
            {
                ShowNotice("指定的内核不存在！", NoticeType.ERROR);
                return;
            }
            string parameters = "";
            //if (!UtilX.StrIsEmpty(setting.seqCounter.inputOptions.seqPath))
            //{
            //    parameters = "-i  " + UtilX.ReplaceSeparatorChar(setting.seqCounter.inputOptions.seqPath);
            //}
            //if (!UtilX.StrIsEmpty(setting.seqCounter.outputOptions.resultPath))
            //{
            //    if (UtilX.StrIsEmpty(parameters))
            //    {
            //        parameters = "-o  " + UtilX.ReplaceSeparatorChar(setting.seqCounter.outputOptions.resultPath);
            //    }
            //    else
            //    {
            //        parameters += " -o  " + UtilX.ReplaceSeparatorChar(setting.seqCounter.outputOptions.resultPath);
            //    }
            //}
            //if (!UtilX.StrIsEmpty(setting.seqCounter.constraintOptions.seqTypeList))
            //{
            //    if (UtilX.StrIsEmpty(parameters))
            //    {
            //        parameters = "-c  " + UtilX.ReplaceSeparatorChar(setting.seqCounter.constraintOptions.seqTypeList);
            //    }
            //    else
            //    {
            //        parameters += " -c  " + UtilX.ReplaceSeparatorChar(setting.seqCounter.constraintOptions.seqTypeList);
            //    }
            //}
            try
            {
                if (!UtilX.CheckFolderPath(setting.seqCounter.outputOptions.resultPath))
                {
                    Directory.CreateDirectory(setting.seqCounter.outputOptions.resultPath);
                }
            }
            catch (Exception)
            {
                ShowNotice("指定的输出路径不存在，且自动创建失败！", NoticeType.ERROR);
            }
            
            if(monitorRichTextBox.Text == "")
            {
                monitorRichTextBox.AppendText("正在执行...\n");
            }
            else
            {
                monitorRichTextBox.AppendText("\n正在执行...\n");
            }
            ShowNotice("正在执行...");
            ExecuteProgramSync(seqCounterPath, parameters);
        }

        public void ExecuteProgramSync(string exePath, string parameters)
        {
            if(!File.Exists(exePath) || parameters == null)
            {
                return;
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.FileName = exePath;
            psi.Arguments = parameters;
            psi.CreateNoWindow = true;
            Process process = Process.Start(psi);
            
            StreamReader outputStreamReader = process.StandardOutput;
            StreamReader errStreamReader = process.StandardError;
            process.WaitForExit(2000);
            if (process.HasExited)
            {
                string output = outputStreamReader.ReadToEnd();
                string error = errStreamReader.ReadToEnd();
                //MessageBox.Show(output);
                //MessageBox.Show(error);
                monitorRichTextBox.AppendText(output + "\n");
                monitorRichTextBox.AppendText(error);

            }
            monitorRichTextBox.AppendText("\n执行完毕。\n");
            ShowNotice("执行完毕。");
        }

        private void ExecuteProgramByCMD(string exePath, string parameters)
        {
            // 进程的名称
            string fileName = exePath;
            //测试参数
            // string para = @"avrdude\avrdude.exe -C avrdude\avrdude.conf -v -p atmega32u4 -c avr109 -P " + portname + " -b 57600 -D -U flash:w:node.hex:i";
            string para = parameters;
            //声明
            Process p = new Process();

            // 这里所需的参数主要是将输入和输出重新定向到Process类的内存中，这样我们就可以通过Process类实例来操作cmd的输入，同时也可以读出命令行的输出
            p.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            p.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
            p.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            p.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            p.StartInfo.FileName = fileName;

            p.Start();

            // 模拟输入的部分已经包括了我们需要调用的程序以及参数，可以事先用cmd来试试看
            p.StandardInput.WriteLine(para + "&exit");
            p.StandardInput.AutoFlush = true;
            p.StandardInput.Close();

            // 这一部分可以获取在cmd中执行的程序在执行完成后所输出的信息，WaitForExit可以填写参数也可以不写
            p.StandardOutput.ReadToEnd();
            string output = p.StandardError.ReadToEnd();
            // p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputDataReceived);
            p.WaitForExit();//参数单位毫秒，在指定时间内没有执行完则强制结束，不填写则无限等待
            p.Close();
            ShowOutput(output);
        }

        private void ExecuteProgramAsync(string exePath, string parameters)
        {
            if (!File.Exists(exePath))
            {
                return;
            }
            Process process = new Process();
            process.StartInfo.FileName = exePath;
            process.StartInfo.Arguments = parameters;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.BeginOutputReadLine();
            process.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputDataReceived);
        }

        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ShowOutputProxy(e.Data);

        }

        /// <summary>
        /// 代理函数，在线程中使用
        /// </summary>
        private void ShowOutputProxy(string text)
        {
            //判断主线程的控件是否需要使用代理来访问
            if (this.monitorRichTextBox.InvokeRequired)
            {
                //创建一个代理
                SetTextCallBack stcb = new SetTextCallBack(ShowOutputProxy);
                //执行代理
                this.Invoke(stcb, new object[] { text });
            }
            else
            {
                //调用主线程的方法，并传递参数，这样就可以在_tip方法里面调用主线程的控件并修改属性了
                ShowOutput(text);
            }
        }

        private void ShowOutput(string text)
        {
            monitorRichTextBox.AppendText(text + "\n");
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inputFolderChooseButton_Click(object sender, EventArgs e)
        {
            if (inputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                setting.seqCounter.inputOptions.seqPath = UtilX.ReplaceSeparatorChar(inputFolderBrowserDialog.SelectedPath, '/') + "/";
                SaveSettingData();
            }
        }

        private void outputFolderChooseButton_Click(object sender, EventArgs e)
        {
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                setting.seqCounter.outputOptions.resultPath = UtilX.ReplaceSeparatorChar(outputFolderBrowserDialog.SelectedPath, '/') + "/";
                SaveSettingData();
            }
        }

        private void constrainFileChooseButton_Click(object sender, EventArgs e)
        {
            if (constrainFileChooseDialog.ShowDialog() == DialogResult.OK)
            {
                setting.seqCounter.constraintOptions.seqTypeList = UtilX.ReplaceSeparatorChar(constrainFileChooseDialog.FileName, '/');
                SaveSettingData();
            }
        }

        private void exitedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            monitorRichTextBox.Clear();
            ShowNotice("控制台输出已清空。");
        }

        private void copeyToClipboardButton_Click(object sender, EventArgs e)
        {
            if(monitorRichTextBox.Text != "")
            {
                Clipboard.SetDataObject(monitorRichTextBox.Text);
                ShowNotice("控制台输出已成功复制到剪贴板！");
            }
            else
            {
                ShowNotice("控制台输出为空，复制操作已取消。", NoticeType.WARNING);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportFileDialog.FileName = "SeqResultsExport_" + UtilX.GetTimeStringNow() + ".zip";
            exportFileDialog.Filter = "ZIP Files (*.zip)|*.zip";
            DialogResult exportStatus = exportFileDialog.ShowDialog();
            if (exportStatus == DialogResult.OK)
            {
                //实例化压缩帮助类
                ZipHelper zipHelper = new ZipHelper();
                //调用创建压缩包的方法
                // zipHelper.CreatZip(@".//results", exportFileDialog.FileName);
                zipHelper.CreatZip(UtilX.ReplaceSeparatorChar(setting.seqCounter.outputOptions.resultPath), exportFileDialog.FileName);
                // ShowNotice("导出成功！文件位置：[" + exportFileDialog.FileName + "]。");
                ShowNotice("导出成功！");
                return;
            }
            else if (exportStatus == DialogResult.Cancel)
            {
                ShowNotice("导出操作已取消。");
                return;
            }
            ShowNotice("导出失败！", NoticeType.ERROR);
            return;
        }
        
        private void readmeButton_Click(object sender, EventArgs e)
        {
            string readmePath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "README.pdf";
            if (File.Exists(readmePath))
            {
                try
                {
                    Process.Start("explorer.exe", readmePath);
                    ShowNotice("已使用默认pdf阅读器打开帮助文件。");
                }
                catch (Exception)
                {
                    ShowNotice("帮助文件打开失败！可能的原因：未安装或未设置默认pdf阅读器。", NoticeType.ERROR);
                }
            }
            else
            {
                ShowNotice("帮助文件已丢失或损坏，无法查看。", NoticeType.ERROR);
            }

        }

        private void ShowNotice(string msg)
        {
            ShowNotice(msg, NoticeType.INFO);
        }

        private void ShowNotice(string msg, NoticeType noticeType)
        {
            if(msg == null || msg == "")
            {
                return;
            }
            if(noticeType == null)
            {
                noticeType = NoticeType.INFO;
            }
            if(noticeType == NoticeType.INFO)
            {
                noticeLabel.ForeColor = DefaultForeColor;
                // noticeLabel.ForeColor = Color.FromArgb(66, 133, 244);
                noticeLabel.Text = "[提示] " + msg;
            }
            else if(noticeType == NoticeType.WARNING)
            {
                noticeLabel.ForeColor = Color.Blue;
                // noticeLabel.ForeColor = Color.FromArgb(251, 188, 5);
                noticeLabel.Text = "[警告] " + msg;
            }
            else if(noticeType == NoticeType.ERROR)
            {
                noticeLabel.ForeColor = Color.Red;
                // noticeLabel.ForeColor = Color.FromArgb(234, 67, 53);
                noticeLabel.Text = "[错误] " + msg;
            }
            else
            {
                noticeLabel.ForeColor = DefaultForeColor;
                // noticeLabel.ForeColor = Color.FromArgb(66, 133, 244);
                noticeLabel.Text = "[提示] " + msg;
            }
        }

        private void inputFolderOpenButton_Click(object sender, EventArgs e)
        {
            ShowFolder(setting.seqCounter.inputOptions.seqPath, "指定的输入路径");
        }

        private void outputFlolderOpenButton_Click(object sender, EventArgs e)
        {
            ShowFolder(setting.seqCounter.outputOptions.resultPath, "指定的输出路径");
        }

        private void ShowFolder(string folderPath)
        {
            ShowFolder(folderPath, "该路径");
        }

        private void ShowFolder(string folderPath, string noticeObjName)
        {
            folderPath = UtilX.ReplaceSeparatorChar(folderPath);
            if (File.Exists(folderPath))
            {
                ShowNotice(noticeObjName + "不是目录！", NoticeType.ERROR);
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                ShowNotice(noticeObjName + "不存在！", NoticeType.ERROR);
                return;
            }
            Process.Start("Explorer.exe", folderPath);
            ShowNotice("已在资源管理器中打开" + noticeObjName + "。");
            return;
        }

        private void ShowFile(string filePath)
        {
            ShowFile(filePath, "该文件");
        }

        private void ShowFile(string filePath, string noticeObjName)
        {
            filePath = UtilX.ReplaceSeparatorChar(filePath);
            if (Directory.Exists(filePath))
            {
                ShowNotice(noticeObjName + "不是文件！", NoticeType.ERROR);
                return;
            }
            if (!File.Exists(filePath))
            {
                ShowNotice(noticeObjName + "不存在！", NoticeType.ERROR);
                return;
            }
            // Process.Start("Explorer.exe", folderPath);
            try
            {
                string fileExtensionName = Path.GetExtension(filePath);
                //if (fileExtensionName == ".ini" || fileExtensionName == ".txt" || fileExtensionName == ".fasta" || fileExtensionName == ".json")
                //{
                //    Process.Start("explorer.exe", filePath);
                //}
                //else
                //{
                //    UtilX.CallCMD(filePath);
                //}
                Process.Start("explorer.exe", filePath);
                ShowNotice("已使用默认应用打开" + noticeObjName + "。");
                return;
            }
            catch (Exception)
            {
                // Console.WriteLine(e);
                ShowNotice(noticeObjName + "打开失败！可能的原因：未安装或未设置默认应用。", NoticeType.ERROR);
            }
            return;
        }

        private void constrainFileEditButton_Click(object sender, EventArgs e)
        {
            ShowFile(setting.seqCounter.constraintOptions.seqTypeList, "指定的约束文件");
        }

        private void SeqCounterXForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitLostFocusEvent()
        {
            symbolsTextBox.LostFocus += symbolsTextBox_LostFocus;
            removeSymbolsTextBox.LostFocus += removeSymbolsTextBox_LostFocus;
        }

        private void symbolsTextBox_LostFocus(object sender, EventArgs e)
        {
            setting.seqCounter.inputOptions.symbolsStr = symbolsTextBox.Text;
            SaveSettingData();
        }

        private void removeSymbolsTextBox_LostFocus(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.removeSymbolsStr = removeSymbolsTextBox.Text;
            SaveSettingData();
        }

        private void InitData()
        {
            LoadSettingData();
            BindSettingData();
            InitLostFocusEvent();
        }

        private void LoadSettingData()
        {
            if (File.Exists(UtilX.ReplaceSeparatorChar(scqxSettingJsonPath)))
            {
                scqxSettingJsonStr = UtilX.ReadFileToStr(scqxSettingJsonPath);
                if (scqxSettingJsonStr != null && scqxSettingJsonStr.Length != 0 && scqxSettingJsonStr != "")
                {
                    scqxSetting = JsonConvert.DeserializeObject<ScqxSettingEntity>(scqxSettingJsonStr);
                    if (scqxSetting == null)
                    {
                        scqxSetting = new ScqxSettingEntity();
                        ShowNotice("外壳配置文件解析失败，已加载默认配置。", NoticeType.WARNING);
                    }
                }
                else
                {
                    ShowNotice("外壳配置文件为空，已加载默认配置。", NoticeType.WARNING);
                }
            }
            else
            {
                ShowNotice("外壳配置文件不存在，已加载默认配置。", NoticeType.WARNING);
            }
            settingJsonPath = scqxSetting.coreSetting;
            if (File.Exists(UtilX.ReplaceSeparatorChar(settingJsonPath)))
            {
                settingJsonStr = UtilX.ReadFileToStr(settingJsonPath);
                if (settingJsonStr != null && settingJsonStr.Length != 0 && settingJsonStr != "")
                {
                    setting = JsonConvert.DeserializeObject<SettingEntity>(settingJsonStr);
                    if (setting == null)
                    {
                        setting = new SettingEntity();
                        ShowNotice("指定的配置文件解析失败，已加载默认配置。", NoticeType.WARNING);
                    }
                }
                else
                {
                    ShowNotice("指定的配置文件为空，已加载默认配置。", NoticeType.WARNING);
                }
            }
            else
            {
                ShowNotice("指定的配置文件不存在，已加载默认配置。", NoticeType.WARNING);
            }
        }

        private void BindSettingData()
        {
            settingJsonPath = scqxSetting.coreSetting;
            settingFileTextBox.DataBindings.Add("Text", scqxSetting, "coreSetting");
            coreText.DataBindings.Add("Text", scqxSetting, "seqCOunterCore");
            
            inputFolderText.DataBindings.Add("Text", setting.seqCounter.inputOptions, "seqPath");
            outputFolderText.DataBindings.Add("Text", setting.seqCounter.outputOptions, "resultPath");
            constrainFileText.DataBindings.Add("Text", setting.seqCounter.constraintOptions, "seqTypeList");
            symbolsTextBox.DataBindings.Add("Text", setting.seqCounter.inputOptions, "symbolsStr");
            

            seqExtensionNameComboBox.DataBindings.Add("Text", setting.seqCounter.inputOptions, "seqExtensionName");
            inputEncodingComboBox.DataBindings.Add("Text", setting.seqCounter.inputOptions, "encoding");
            resultExtensionNameComboBox.DataBindings.Add("Text", setting.seqCounter.outputOptions, "resultExtensionName");
            outputEncodingComboBox.DataBindings.Add("Text", setting.seqCounter.outputOptions, "encoding");
            extractExtensionNameComboBox.DataBindings.Add("Text", setting.seqCounter.outputOptions, "extractExtensionName");

            removeSymbolsTextBox.DataBindings.Add("Text", setting.seqCounter.outputOptions, "removeSymbolsStr");
            seqTypeListTextBox.DataBindings.Add("Text", setting.seqCounter.constraintOptions, "seqTypeStr");


            seqTypeCheckBox.DataBindings.Add("Checked", setting.seqCounter.constraintOptions, "seqTypeCheck");
            compareCheckBox.DataBindings.Add("Checked", setting.seqCounter.outputOptions, "compare");
            extractSeqCheckBox.DataBindings.Add("Checked", setting.seqCounter.outputOptions, "extractSeq");
            singleExtractCheckBox.DataBindings.Add("Checked", setting.seqCounter.outputOptions, "singleExtract");
            combineCompareCheckBox.DataBindings.Add("Checked", setting.seqCounter.outputOptions, "combineCompare");
            ignoreEmptySeqCheckBox.DataBindings.Add("Checked", setting.seqCounter.outputOptions, "ignoreEmptySeq");

            coreVerisonLabel.Text = setting.version;
        }

        public void SaveAllData()
        {
            SaveScqxSetting();
            SaveSettingData();
        }

        public void SaveScqxSetting()
        {
            string scqxSettingJson = JsonConvert.SerializeObject(scqxSetting, Formatting.Indented);
            UtilX.SaveStrToFile(scqxSettingJson, scqxSettingJsonPath);
        }

        public void SaveSettingData()
        {
            string settingJson = JsonConvert.SerializeObject(setting, Formatting.Indented);
            UtilX.SaveStrToFile(settingJson, scqxSetting.coreSetting);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void recoverSettingButton_Click(object sender, EventArgs e)
        {
            if(!UtilX.ShowConfirmWindow("您确定要恢复到默认设置吗？", "提示"))
            {
                return;
            }
            string settingJsonBackPath = "./ini/setting.json_back";
            if (!UtilX.CheckFilePath(settingJsonBackPath))
            {
                ShowNotice("重置失败，备份文件已丢失。", NoticeType.ERROR);
                return;
            }
            string settingJsonBack = UtilX.ReadFileToStr(settingJsonBackPath);
            if(settingJsonBack == null || settingJsonBack == "")
            {
                ShowNotice("重置失败，备份文件为空。", NoticeType.ERROR);
                return;
            }
            try
            {
                SettingEntity testSettingEntity = JsonConvert.DeserializeObject<SettingEntity>(settingJsonBack);
            }
            catch(Exception)
            {
                ShowNotice("重置失败，备份文件已损坏。", NoticeType.ERROR);
                return;
            }
            string defaultSettingPath = "./ini/setting.json";
            UtilX.SaveStrToFile(settingJsonBack, defaultSettingPath);
            scqxSetting.coreSetting = defaultSettingPath;
            ShowNotice("配置文件重置成功，重启本程序后生效。", NoticeType.WARNING);
        }

        private void outputFolderText_TextChanged(object sender, EventArgs e)
        {
            // SaveSettingData();
        }

        private void monitorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void coreChooseButton_Click(object sender, EventArgs e)
        {
            if (coreChooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                scqxSetting.seqCOunterCore = UtilX.ReplaceSeparatorChar(coreChooseFileDialog.FileName, '/');
                SaveScqxSetting();
            }
        }

        private void coreSettingChooseButton_Click(object sender, EventArgs e)
        {
            if(coreSettingChooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                scqxSetting.coreSetting = UtilX.ReplaceSeparatorChar(coreSettingChooseFileDialog.FileName, '/');
                SaveScqxSetting();
                LoadSettingData();
            }
        }

        private void seqExtensionNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.seqCounter.inputOptions.seqExtensionName = seqExtensionNameComboBox.Text;
            SaveSettingData();
        }

        private void inputEncodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.seqCounter.inputOptions.encoding = inputEncodingComboBox.Text;
            SaveSettingData();
        }

        private void resultExtensionNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.resultExtensionName = resultExtensionNameComboBox.Text;
            SaveSettingData();
        }

        private void outputEncodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.encoding = outputEncodingComboBox.Text;
            SaveSettingData();
        }

        private void extractExtensionNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.extractExtensionName = extractExtensionNameComboBox.Text;
            SaveSettingData();
        }

        private void seqTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.constraintOptions.seqTypeCheck = seqTypeCheckBox.Checked;
            SaveSettingData();
        }

        private void compareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.compare = compareCheckBox.Checked;
            SaveSettingData();
        }

        private void extractSeqCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.extractSeq = extractSeqCheckBox.Checked;
            SaveSettingData();
        }

        private void singleExtractCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.singleExtract = singleExtractCheckBox.Checked;
            SaveSettingData();
        }

        private void combineCompareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.combineCompare = combineCompareCheckBox.Checked;
            SaveSettingData();
        }

        private void ignoreEmptySeqCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setting.seqCounter.outputOptions.ignoreEmptySeq = ignoreEmptySeqCheckBox.Checked;
            SaveSettingData();
        }

        private void seqTypeListTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!UtilX.CheckFilePath(setting.seqCounter.constraintOptions.seqTypeList))
            {
                ShowNotice("自动保存失败，指定的约束文件不存在！");
                return;
            }
            UtilX.SaveStrToFile(seqTypeListTextBox.Text, setting.seqCounter.constraintOptions.seqTypeList);
        }

        private void SeqCounterXForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UtilX.ShowConfirmWindow("您确定要退出SeqCounterX吗？", "提示"))
            {
                e.Cancel = true;
            }
            SaveAllData();
        }

        private void monitorRichTextBox_TextChanged(object sender, EventArgs e)
        {
            monitorRichTextBox.SelectionStart = monitorRichTextBox.Text.Length;
            monitorRichTextBox.ScrollToCaret();
        }
    }
}