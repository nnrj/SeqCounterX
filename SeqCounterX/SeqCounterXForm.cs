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
        /// ��������
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
                ShowNotice("�������ںˣ�", NoticeType.ERROR);
                return;
            }
            if (!File.Exists(seqCounterPath))
            {
                ShowNotice("ָ�����ں˲����ڣ�", NoticeType.ERROR);
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
                ShowNotice("ָ�������·�������ڣ����Զ�����ʧ�ܣ�", NoticeType.ERROR);
            }
            
            if(monitorRichTextBox.Text == "")
            {
                monitorRichTextBox.AppendText("����ִ��...\n");
            }
            else
            {
                monitorRichTextBox.AppendText("\n����ִ��...\n");
            }
            ShowNotice("����ִ��...");
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
            monitorRichTextBox.AppendText("\nִ����ϡ�\n");
            ShowNotice("ִ����ϡ�");
        }

        private void ExecuteProgramByCMD(string exePath, string parameters)
        {
            // ���̵�����
            string fileName = exePath;
            //���Բ���
            // string para = @"avrdude\avrdude.exe -C avrdude\avrdude.conf -v -p atmega32u4 -c avr109 -P " + portname + " -b 57600 -D -U flash:w:node.hex:i";
            string para = parameters;
            //����
            Process p = new Process();

            // ��������Ĳ�����Ҫ�ǽ������������¶���Process����ڴ��У��������ǾͿ���ͨ��Process��ʵ��������cmd�����룬ͬʱҲ���Զ��������е����
            p.StartInfo.CreateNoWindow = true;         // �������´���    
            p.StartInfo.UseShellExecute = false;       //������shell��������  
            p.StartInfo.RedirectStandardInput = true;  // �ض�������    
            p.StartInfo.RedirectStandardOutput = true; // �ض����׼���    
            p.StartInfo.RedirectStandardError = true;  // �ض���������  
            p.StartInfo.FileName = fileName;

            p.Start();

            // ģ������Ĳ����Ѿ�������������Ҫ���õĳ����Լ�����������������cmd�����Կ�
            p.StandardInput.WriteLine(para + "&exit");
            p.StandardInput.AutoFlush = true;
            p.StandardInput.Close();

            // ��һ���ֿ��Ի�ȡ��cmd��ִ�еĳ�����ִ����ɺ����������Ϣ��WaitForExit������д����Ҳ���Բ�д
            p.StandardOutput.ReadToEnd();
            string output = p.StandardError.ReadToEnd();
            // p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputDataReceived);
            p.WaitForExit();//������λ���룬��ָ��ʱ����û��ִ������ǿ�ƽ���������д�����޵ȴ�
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
        /// �����������߳���ʹ��
        /// </summary>
        private void ShowOutputProxy(string text)
        {
            //�ж����̵߳Ŀؼ��Ƿ���Ҫʹ�ô���������
            if (this.monitorRichTextBox.InvokeRequired)
            {
                //����һ������
                SetTextCallBack stcb = new SetTextCallBack(ShowOutputProxy);
                //ִ�д���
                this.Invoke(stcb, new object[] { text });
            }
            else
            {
                //�������̵߳ķ����������ݲ����������Ϳ�����_tip��������������̵߳Ŀؼ����޸�������
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
            ShowNotice("����̨�������ա�");
        }

        private void copeyToClipboardButton_Click(object sender, EventArgs e)
        {
            if(monitorRichTextBox.Text != "")
            {
                Clipboard.SetDataObject(monitorRichTextBox.Text);
                ShowNotice("����̨����ѳɹ����Ƶ������壡");
            }
            else
            {
                ShowNotice("����̨���Ϊ�գ����Ʋ�����ȡ����", NoticeType.WARNING);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportFileDialog.FileName = "SeqResultsExport_" + UtilX.GetTimeStringNow() + ".zip";
            exportFileDialog.Filter = "ZIP Files (*.zip)|*.zip";
            DialogResult exportStatus = exportFileDialog.ShowDialog();
            if (exportStatus == DialogResult.OK)
            {
                //ʵ����ѹ��������
                ZipHelper zipHelper = new ZipHelper();
                //���ô���ѹ�����ķ���
                // zipHelper.CreatZip(@".//results", exportFileDialog.FileName);
                zipHelper.CreatZip(UtilX.ReplaceSeparatorChar(setting.seqCounter.outputOptions.resultPath), exportFileDialog.FileName);
                // ShowNotice("�����ɹ����ļ�λ�ã�[" + exportFileDialog.FileName + "]��");
                ShowNotice("�����ɹ���");
                return;
            }
            else if (exportStatus == DialogResult.Cancel)
            {
                ShowNotice("����������ȡ����");
                return;
            }
            ShowNotice("����ʧ�ܣ�", NoticeType.ERROR);
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
                    ShowNotice("��ʹ��Ĭ��pdf�Ķ����򿪰����ļ���");
                }
                catch (Exception)
                {
                    ShowNotice("�����ļ���ʧ�ܣ����ܵ�ԭ��δ��װ��δ����Ĭ��pdf�Ķ�����", NoticeType.ERROR);
                }
            }
            else
            {
                ShowNotice("�����ļ��Ѷ�ʧ���𻵣��޷��鿴��", NoticeType.ERROR);
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
                noticeLabel.Text = "[��ʾ] " + msg;
            }
            else if(noticeType == NoticeType.WARNING)
            {
                noticeLabel.ForeColor = Color.Blue;
                // noticeLabel.ForeColor = Color.FromArgb(251, 188, 5);
                noticeLabel.Text = "[����] " + msg;
            }
            else if(noticeType == NoticeType.ERROR)
            {
                noticeLabel.ForeColor = Color.Red;
                // noticeLabel.ForeColor = Color.FromArgb(234, 67, 53);
                noticeLabel.Text = "[����] " + msg;
            }
            else
            {
                noticeLabel.ForeColor = DefaultForeColor;
                // noticeLabel.ForeColor = Color.FromArgb(66, 133, 244);
                noticeLabel.Text = "[��ʾ] " + msg;
            }
        }

        private void inputFolderOpenButton_Click(object sender, EventArgs e)
        {
            ShowFolder(setting.seqCounter.inputOptions.seqPath, "ָ��������·��");
        }

        private void outputFlolderOpenButton_Click(object sender, EventArgs e)
        {
            ShowFolder(setting.seqCounter.outputOptions.resultPath, "ָ�������·��");
        }

        private void ShowFolder(string folderPath)
        {
            ShowFolder(folderPath, "��·��");
        }

        private void ShowFolder(string folderPath, string noticeObjName)
        {
            folderPath = UtilX.ReplaceSeparatorChar(folderPath);
            if (File.Exists(folderPath))
            {
                ShowNotice(noticeObjName + "����Ŀ¼��", NoticeType.ERROR);
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                ShowNotice(noticeObjName + "�����ڣ�", NoticeType.ERROR);
                return;
            }
            Process.Start("Explorer.exe", folderPath);
            ShowNotice("������Դ�������д�" + noticeObjName + "��");
            return;
        }

        private void ShowFile(string filePath)
        {
            ShowFile(filePath, "���ļ�");
        }

        private void ShowFile(string filePath, string noticeObjName)
        {
            filePath = UtilX.ReplaceSeparatorChar(filePath);
            if (Directory.Exists(filePath))
            {
                ShowNotice(noticeObjName + "�����ļ���", NoticeType.ERROR);
                return;
            }
            if (!File.Exists(filePath))
            {
                ShowNotice(noticeObjName + "�����ڣ�", NoticeType.ERROR);
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
                ShowNotice("��ʹ��Ĭ��Ӧ�ô�" + noticeObjName + "��");
                return;
            }
            catch (Exception)
            {
                // Console.WriteLine(e);
                ShowNotice(noticeObjName + "��ʧ�ܣ����ܵ�ԭ��δ��װ��δ����Ĭ��Ӧ�á�", NoticeType.ERROR);
            }
            return;
        }

        private void constrainFileEditButton_Click(object sender, EventArgs e)
        {
            ShowFile(setting.seqCounter.constraintOptions.seqTypeList, "ָ����Լ���ļ�");
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
                        ShowNotice("��������ļ�����ʧ�ܣ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
                    }
                }
                else
                {
                    ShowNotice("��������ļ�Ϊ�գ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
                }
            }
            else
            {
                ShowNotice("��������ļ������ڣ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
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
                        ShowNotice("ָ���������ļ�����ʧ�ܣ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
                    }
                }
                else
                {
                    ShowNotice("ָ���������ļ�Ϊ�գ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
                }
            }
            else
            {
                ShowNotice("ָ���������ļ������ڣ��Ѽ���Ĭ�����á�", NoticeType.WARNING);
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
            if(!UtilX.ShowConfirmWindow("��ȷ��Ҫ�ָ���Ĭ��������", "��ʾ"))
            {
                return;
            }
            string settingJsonBackPath = "./ini/setting.json_back";
            if (!UtilX.CheckFilePath(settingJsonBackPath))
            {
                ShowNotice("����ʧ�ܣ������ļ��Ѷ�ʧ��", NoticeType.ERROR);
                return;
            }
            string settingJsonBack = UtilX.ReadFileToStr(settingJsonBackPath);
            if(settingJsonBack == null || settingJsonBack == "")
            {
                ShowNotice("����ʧ�ܣ������ļ�Ϊ�ա�", NoticeType.ERROR);
                return;
            }
            try
            {
                SettingEntity testSettingEntity = JsonConvert.DeserializeObject<SettingEntity>(settingJsonBack);
            }
            catch(Exception)
            {
                ShowNotice("����ʧ�ܣ������ļ����𻵡�", NoticeType.ERROR);
                return;
            }
            string defaultSettingPath = "./ini/setting.json";
            UtilX.SaveStrToFile(settingJsonBack, defaultSettingPath);
            scqxSetting.coreSetting = defaultSettingPath;
            ShowNotice("�����ļ����óɹ����������������Ч��", NoticeType.WARNING);
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
                ShowNotice("�Զ�����ʧ�ܣ�ָ����Լ���ļ������ڣ�");
                return;
            }
            UtilX.SaveStrToFile(seqTypeListTextBox.Text, setting.seqCounter.constraintOptions.seqTypeList);
        }

        private void SeqCounterXForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UtilX.ShowConfirmWindow("��ȷ��Ҫ�˳�SeqCounterX��", "��ʾ"))
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