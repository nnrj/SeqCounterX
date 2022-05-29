namespace SeqCounterX
{
    partial class SeqCounterXForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeqCounterXForm));
            this.constrainFileChooseDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.readmeButton = new System.Windows.Forms.Button();
            this.inputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monitorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.exitedButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.copeyToClipboardButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.recoverSettingButton = new System.Windows.Forms.Button();
            this.coreVerisonLabel = new System.Windows.Forms.Label();
            this.ignoreEmptySeqCheckBox = new System.Windows.Forms.CheckBox();
            this.coreSettingChooseButton = new System.Windows.Forms.Button();
            this.settingFileTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.seqTypeListTextBox = new System.Windows.Forms.TextBox();
            this.removeSymbolsTextBox = new System.Windows.Forms.TextBox();
            this.combineCompareCheckBox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.coreChooseButton = new System.Windows.Forms.Button();
            this.coreText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.extractExtensionNameComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.symbolsTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.singleExtractCheckBox = new System.Windows.Forms.CheckBox();
            this.compareCheckBox = new System.Windows.Forms.CheckBox();
            this.extractSeqCheckBox = new System.Windows.Forms.CheckBox();
            this.seqTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.outputEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resultExtensionNameComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.seqExtensionNameComboBox = new System.Windows.Forms.ComboBox();
            this.constrainFileChooseButton = new System.Windows.Forms.Button();
            this.outputFlolderOpenButton = new System.Windows.Forms.Button();
            this.inputFolderOpenButton = new System.Windows.Forms.Button();
            this.constrainFileEditButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.constrainFileText = new System.Windows.Forms.TextBox();
            this.outputFlolderChooseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputFolderText = new System.Windows.Forms.TextBox();
            this.inputFolderChooseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputFolderText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.coreChooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.coreSettingChooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // constrainFileChooseDialog
            // 
            this.constrainFileChooseDialog.FileName = "openFileDialog1";
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.FileName = "openFileDialog2";
            // 
            // readmeButton
            // 
            this.readmeButton.AutoSize = true;
            this.readmeButton.Location = new System.Drawing.Point(413, 22);
            this.readmeButton.Margin = new System.Windows.Forms.Padding(4);
            this.readmeButton.Name = "readmeButton";
            this.readmeButton.Size = new System.Drawing.Size(75, 35);
            this.readmeButton.TabIndex = 4;
            this.readmeButton.Text = "帮助";
            this.readmeButton.UseVisualStyleBackColor = true;
            this.readmeButton.Click += new System.EventHandler(this.readmeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monitorRichTextBox);
            this.groupBox1.Controls.Add(this.exitedButton);
            this.groupBox1.Controls.Add(this.runButton);
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.copeyToClipboardButton);
            this.groupBox1.Controls.Add(this.exportButton);
            this.groupBox1.Controls.Add(this.readmeButton);
            this.groupBox1.Location = new System.Drawing.Point(539, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(586, 608);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            // 
            // monitorRichTextBox
            // 
            this.monitorRichTextBox.BackColor = System.Drawing.Color.Black;
            this.monitorRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.monitorRichTextBox.Location = new System.Drawing.Point(14, 67);
            this.monitorRichTextBox.Name = "monitorRichTextBox";
            this.monitorRichTextBox.Size = new System.Drawing.Size(565, 532);
            this.monitorRichTextBox.TabIndex = 6;
            this.monitorRichTextBox.Text = "";
            this.monitorRichTextBox.TextChanged += new System.EventHandler(this.monitorRichTextBox_TextChanged);
            // 
            // exitedButton
            // 
            this.exitedButton.AutoSize = true;
            this.exitedButton.Location = new System.Drawing.Point(504, 21);
            this.exitedButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitedButton.Name = "exitedButton";
            this.exitedButton.Size = new System.Drawing.Size(75, 35);
            this.exitedButton.TabIndex = 5;
            this.exitedButton.Text = "退出";
            this.exitedButton.UseVisualStyleBackColor = true;
            this.exitedButton.Click += new System.EventHandler(this.exitedButton_Click);
            // 
            // runButton
            // 
            this.runButton.AutoSize = true;
            this.runButton.Location = new System.Drawing.Point(14, 25);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 35);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "运行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Location = new System.Drawing.Point(312, 23);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 35);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "清空";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // copeyToClipboardButton
            // 
            this.copeyToClipboardButton.AutoSize = true;
            this.copeyToClipboardButton.Location = new System.Drawing.Point(111, 23);
            this.copeyToClipboardButton.Margin = new System.Windows.Forms.Padding(4);
            this.copeyToClipboardButton.Name = "copeyToClipboardButton";
            this.copeyToClipboardButton.Size = new System.Drawing.Size(75, 35);
            this.copeyToClipboardButton.TabIndex = 1;
            this.copeyToClipboardButton.Text = "复制";
            this.copeyToClipboardButton.UseVisualStyleBackColor = true;
            this.copeyToClipboardButton.Click += new System.EventHandler(this.copeyToClipboardButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.Location = new System.Drawing.Point(212, 25);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 35);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "导出";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.recoverSettingButton);
            this.groupBox3.Controls.Add(this.coreVerisonLabel);
            this.groupBox3.Controls.Add(this.ignoreEmptySeqCheckBox);
            this.groupBox3.Controls.Add(this.coreSettingChooseButton);
            this.groupBox3.Controls.Add(this.settingFileTextBox);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.seqTypeListTextBox);
            this.groupBox3.Controls.Add(this.removeSymbolsTextBox);
            this.groupBox3.Controls.Add(this.combineCompareCheckBox);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.coreChooseButton);
            this.groupBox3.Controls.Add(this.coreText);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.extractExtensionNameComboBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.symbolsTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.singleExtractCheckBox);
            this.groupBox3.Controls.Add(this.compareCheckBox);
            this.groupBox3.Controls.Add(this.extractSeqCheckBox);
            this.groupBox3.Controls.Add(this.seqTypeCheckBox);
            this.groupBox3.Controls.Add(this.outputEncodingComboBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.inputEncodingComboBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.resultExtensionNameComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.seqExtensionNameComboBox);
            this.groupBox3.Controls.Add(this.constrainFileChooseButton);
            this.groupBox3.Controls.Add(this.outputFlolderOpenButton);
            this.groupBox3.Controls.Add(this.inputFolderOpenButton);
            this.groupBox3.Controls.Add(this.constrainFileEditButton);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.constrainFileText);
            this.groupBox3.Controls.Add(this.outputFlolderChooseButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.outputFolderText);
            this.groupBox3.Controls.Add(this.inputFolderChooseButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.inputFolderText);
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(517, 533);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配置";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // recoverSettingButton
            // 
            this.recoverSettingButton.Location = new System.Drawing.Point(409, 489);
            this.recoverSettingButton.Margin = new System.Windows.Forms.Padding(4);
            this.recoverSettingButton.Name = "recoverSettingButton";
            this.recoverSettingButton.Size = new System.Drawing.Size(96, 27);
            this.recoverSettingButton.TabIndex = 28;
            this.recoverSettingButton.Text = "重置";
            this.recoverSettingButton.UseVisualStyleBackColor = true;
            this.recoverSettingButton.Click += new System.EventHandler(this.recoverSettingButton_Click);
            // 
            // coreVerisonLabel
            // 
            this.coreVerisonLabel.AutoSize = true;
            this.coreVerisonLabel.Location = new System.Drawing.Point(460, 459);
            this.coreVerisonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.coreVerisonLabel.Name = "coreVerisonLabel";
            this.coreVerisonLabel.Size = new System.Drawing.Size(44, 20);
            this.coreVerisonLabel.TabIndex = 98;
            this.coreVerisonLabel.Text = "1.0.0";
            // 
            // ignoreEmptySeqCheckBox
            // 
            this.ignoreEmptySeqCheckBox.AutoSize = true;
            this.ignoreEmptySeqCheckBox.Location = new System.Drawing.Point(409, 241);
            this.ignoreEmptySeqCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ignoreEmptySeqCheckBox.Name = "ignoreEmptySeqCheckBox";
            this.ignoreEmptySeqCheckBox.Size = new System.Drawing.Size(91, 24);
            this.ignoreEmptySeqCheckBox.TabIndex = 23;
            this.ignoreEmptySeqCheckBox.Text = "忽略空值";
            this.ignoreEmptySeqCheckBox.UseVisualStyleBackColor = true;
            this.ignoreEmptySeqCheckBox.CheckedChanged += new System.EventHandler(this.ignoreEmptySeqCheckBox_CheckedChanged);
            // 
            // coreSettingChooseButton
            // 
            this.coreSettingChooseButton.Location = new System.Drawing.Point(305, 489);
            this.coreSettingChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.coreSettingChooseButton.Name = "coreSettingChooseButton";
            this.coreSettingChooseButton.Size = new System.Drawing.Size(96, 27);
            this.coreSettingChooseButton.TabIndex = 27;
            this.coreSettingChooseButton.Text = "选择";
            this.coreSettingChooseButton.UseVisualStyleBackColor = true;
            this.coreSettingChooseButton.Click += new System.EventHandler(this.coreSettingChooseButton_Click);
            // 
            // settingFileTextBox
            // 
            this.settingFileTextBox.Location = new System.Drawing.Point(90, 493);
            this.settingFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.settingFileTextBox.Name = "settingFileTextBox";
            this.settingFileTextBox.ReadOnly = true;
            this.settingFileTextBox.Size = new System.Drawing.Size(207, 27);
            this.settingFileTextBox.TabIndex = 95;
            this.settingFileTextBox.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 496);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 94;
            this.label12.Text = "配置文件";
            // 
            // seqTypeListTextBox
            // 
            this.seqTypeListTextBox.Location = new System.Drawing.Point(305, 311);
            this.seqTypeListTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.seqTypeListTextBox.Multiline = true;
            this.seqTypeListTextBox.Name = "seqTypeListTextBox";
            this.seqTypeListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.seqTypeListTextBox.Size = new System.Drawing.Size(199, 137);
            this.seqTypeListTextBox.TabIndex = 25;
            this.seqTypeListTextBox.TextChanged += new System.EventHandler(this.seqTypeListTextBox_TextChanged);
            // 
            // removeSymbolsTextBox
            // 
            this.removeSymbolsTextBox.Location = new System.Drawing.Point(10, 311);
            this.removeSymbolsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.removeSymbolsTextBox.Multiline = true;
            this.removeSymbolsTextBox.Name = "removeSymbolsTextBox";
            this.removeSymbolsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.removeSymbolsTextBox.Size = new System.Drawing.Size(287, 137);
            this.removeSymbolsTextBox.TabIndex = 24;
            // 
            // combineCompareCheckBox
            // 
            this.combineCompareCheckBox.AutoSize = true;
            this.combineCompareCheckBox.Location = new System.Drawing.Point(310, 241);
            this.combineCompareCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combineCompareCheckBox.Name = "combineCompareCheckBox";
            this.combineCompareCheckBox.Size = new System.Drawing.Size(91, 24);
            this.combineCompareCheckBox.TabIndex = 22;
            this.combineCompareCheckBox.Text = "跨域比较";
            this.combineCompareCheckBox.UseVisualStyleBackColor = true;
            this.combineCompareCheckBox.CheckedChanged += new System.EventHandler(this.combineCompareCheckBox_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(411, 459);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 20);
            this.label17.TabIndex = 89;
            this.label17.Text = "版本";
            // 
            // coreChooseButton
            // 
            this.coreChooseButton.Location = new System.Drawing.Point(305, 455);
            this.coreChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.coreChooseButton.Name = "coreChooseButton";
            this.coreChooseButton.Size = new System.Drawing.Size(96, 27);
            this.coreChooseButton.TabIndex = 26;
            this.coreChooseButton.Text = "选择";
            this.coreChooseButton.UseVisualStyleBackColor = true;
            this.coreChooseButton.Click += new System.EventHandler(this.coreChooseButton_Click);
            // 
            // coreText
            // 
            this.coreText.Location = new System.Drawing.Point(90, 455);
            this.coreText.Margin = new System.Windows.Forms.Padding(4);
            this.coreText.Name = "coreText";
            this.coreText.ReadOnly = true;
            this.coreText.Size = new System.Drawing.Size(207, 27);
            this.coreText.TabIndex = 87;
            this.coreText.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 459);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 20);
            this.label16.TabIndex = 86;
            this.label16.Text = "内核位置";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(305, 268);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 51);
            this.label11.TabIndex = 78;
            this.label11.Text = "序列类型列表";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // extractExtensionNameComboBox
            // 
            this.extractExtensionNameComboBox.FormattingEnabled = true;
            this.extractExtensionNameComboBox.Items.AddRange(new object[] {
            ".fasta",
            ".txt"});
            this.extractExtensionNameComboBox.Location = new System.Drawing.Point(86, 239);
            this.extractExtensionNameComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.extractExtensionNameComboBox.Name = "extractExtensionNameComboBox";
            this.extractExtensionNameComboBox.Size = new System.Drawing.Size(93, 28);
            this.extractExtensionNameComboBox.TabIndex = 17;
            this.extractExtensionNameComboBox.SelectedIndexChanged += new System.EventHandler(this.extractExtensionNameComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 246);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 75;
            this.label10.Text = "提取格式";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 275);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 35);
            this.label9.TabIndex = 74;
            this.label9.Text = "移除字符列表";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // symbolsTextBox
            // 
            this.symbolsTextBox.Location = new System.Drawing.Point(86, 127);
            this.symbolsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.symbolsTextBox.Name = "symbolsTextBox";
            this.symbolsTextBox.Size = new System.Drawing.Size(418, 27);
            this.symbolsTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 131);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 72;
            this.label8.Text = "分隔符";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // singleExtractCheckBox
            // 
            this.singleExtractCheckBox.AutoSize = true;
            this.singleExtractCheckBox.Location = new System.Drawing.Point(411, 208);
            this.singleExtractCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.singleExtractCheckBox.Name = "singleExtractCheckBox";
            this.singleExtractCheckBox.Size = new System.Drawing.Size(91, 24);
            this.singleExtractCheckBox.TabIndex = 21;
            this.singleExtractCheckBox.Text = "逐个提取";
            this.singleExtractCheckBox.UseVisualStyleBackColor = true;
            this.singleExtractCheckBox.CheckedChanged += new System.EventHandler(this.singleExtractCheckBox_CheckedChanged);
            // 
            // compareCheckBox
            // 
            this.compareCheckBox.AutoSize = true;
            this.compareCheckBox.Location = new System.Drawing.Point(409, 172);
            this.compareCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.compareCheckBox.Name = "compareCheckBox";
            this.compareCheckBox.Size = new System.Drawing.Size(91, 24);
            this.compareCheckBox.TabIndex = 19;
            this.compareCheckBox.Text = "同类标识";
            this.compareCheckBox.UseVisualStyleBackColor = true;
            this.compareCheckBox.CheckedChanged += new System.EventHandler(this.compareCheckBox_CheckedChanged);
            // 
            // extractSeqCheckBox
            // 
            this.extractSeqCheckBox.AutoSize = true;
            this.extractSeqCheckBox.Location = new System.Drawing.Point(310, 208);
            this.extractSeqCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.extractSeqCheckBox.Name = "extractSeqCheckBox";
            this.extractSeqCheckBox.Size = new System.Drawing.Size(91, 24);
            this.extractSeqCheckBox.TabIndex = 20;
            this.extractSeqCheckBox.Text = "提取序列";
            this.extractSeqCheckBox.UseVisualStyleBackColor = true;
            this.extractSeqCheckBox.CheckedChanged += new System.EventHandler(this.extractSeqCheckBox_CheckedChanged);
            // 
            // seqTypeCheckBox
            // 
            this.seqTypeCheckBox.AutoSize = true;
            this.seqTypeCheckBox.Location = new System.Drawing.Point(310, 171);
            this.seqTypeCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.seqTypeCheckBox.Name = "seqTypeCheckBox";
            this.seqTypeCheckBox.Size = new System.Drawing.Size(91, 24);
            this.seqTypeCheckBox.TabIndex = 18;
            this.seqTypeCheckBox.Text = "类型识别";
            this.seqTypeCheckBox.UseVisualStyleBackColor = true;
            this.seqTypeCheckBox.CheckedChanged += new System.EventHandler(this.seqTypeCheckBox_CheckedChanged);
            // 
            // outputEncodingComboBox
            // 
            this.outputEncodingComboBox.FormattingEnabled = true;
            this.outputEncodingComboBox.Items.AddRange(new object[] {
            "utf-8",
            "gbk"});
            this.outputEncodingComboBox.Location = new System.Drawing.Point(233, 204);
            this.outputEncodingComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outputEncodingComboBox.Name = "outputEncodingComboBox";
            this.outputEncodingComboBox.Size = new System.Drawing.Size(64, 28);
            this.outputEncodingComboBox.TabIndex = 16;
            this.outputEncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.outputEncodingComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 207);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "输出编码";
            // 
            // inputEncodingComboBox
            // 
            this.inputEncodingComboBox.FormattingEnabled = true;
            this.inputEncodingComboBox.Items.AddRange(new object[] {
            "utf-8",
            "gbk"});
            this.inputEncodingComboBox.Location = new System.Drawing.Point(233, 169);
            this.inputEncodingComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputEncodingComboBox.Name = "inputEncodingComboBox";
            this.inputEncodingComboBox.Size = new System.Drawing.Size(64, 28);
            this.inputEncodingComboBox.TabIndex = 14;
            this.inputEncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.inputEncodingComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "输入编码";
            // 
            // resultExtensionNameComboBox
            // 
            this.resultExtensionNameComboBox.FormattingEnabled = true;
            this.resultExtensionNameComboBox.Items.AddRange(new object[] {
            ".log",
            ".txt",
            ".xlsx"});
            this.resultExtensionNameComboBox.Location = new System.Drawing.Point(86, 204);
            this.resultExtensionNameComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resultExtensionNameComboBox.Name = "resultExtensionNameComboBox";
            this.resultExtensionNameComboBox.Size = new System.Drawing.Size(64, 28);
            this.resultExtensionNameComboBox.TabIndex = 15;
            this.resultExtensionNameComboBox.SelectedIndexChanged += new System.EventHandler(this.resultExtensionNameComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 207);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "输出格式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "输入格式";
            // 
            // seqExtensionNameComboBox
            // 
            this.seqExtensionNameComboBox.FormattingEnabled = true;
            this.seqExtensionNameComboBox.Items.AddRange(new object[] {
            ".txt",
            ".fasta"});
            this.seqExtensionNameComboBox.Location = new System.Drawing.Point(86, 168);
            this.seqExtensionNameComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.seqExtensionNameComboBox.Name = "seqExtensionNameComboBox";
            this.seqExtensionNameComboBox.Size = new System.Drawing.Size(64, 28);
            this.seqExtensionNameComboBox.TabIndex = 13;
            this.seqExtensionNameComboBox.SelectedIndexChanged += new System.EventHandler(this.seqExtensionNameComboBox_SelectedIndexChanged);
            // 
            // constrainFileChooseButton
            // 
            this.constrainFileChooseButton.Location = new System.Drawing.Point(305, 98);
            this.constrainFileChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.constrainFileChooseButton.Name = "constrainFileChooseButton";
            this.constrainFileChooseButton.Size = new System.Drawing.Size(96, 27);
            this.constrainFileChooseButton.TabIndex = 10;
            this.constrainFileChooseButton.Text = "选择";
            this.constrainFileChooseButton.UseVisualStyleBackColor = true;
            this.constrainFileChooseButton.Click += new System.EventHandler(this.constrainFileChooseButton_Click);
            // 
            // outputFlolderOpenButton
            // 
            this.outputFlolderOpenButton.Location = new System.Drawing.Point(409, 62);
            this.outputFlolderOpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.outputFlolderOpenButton.Name = "outputFlolderOpenButton";
            this.outputFlolderOpenButton.Size = new System.Drawing.Size(96, 27);
            this.outputFlolderOpenButton.TabIndex = 9;
            this.outputFlolderOpenButton.Text = "打开";
            this.outputFlolderOpenButton.UseVisualStyleBackColor = true;
            this.outputFlolderOpenButton.Click += new System.EventHandler(this.outputFlolderOpenButton_Click);
            // 
            // inputFolderOpenButton
            // 
            this.inputFolderOpenButton.Location = new System.Drawing.Point(409, 27);
            this.inputFolderOpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.inputFolderOpenButton.Name = "inputFolderOpenButton";
            this.inputFolderOpenButton.Size = new System.Drawing.Size(96, 27);
            this.inputFolderOpenButton.TabIndex = 7;
            this.inputFolderOpenButton.Text = "打开";
            this.inputFolderOpenButton.UseVisualStyleBackColor = true;
            this.inputFolderOpenButton.Click += new System.EventHandler(this.inputFolderOpenButton_Click);
            // 
            // constrainFileEditButton
            // 
            this.constrainFileEditButton.Location = new System.Drawing.Point(409, 98);
            this.constrainFileEditButton.Margin = new System.Windows.Forms.Padding(4);
            this.constrainFileEditButton.Name = "constrainFileEditButton";
            this.constrainFileEditButton.Size = new System.Drawing.Size(96, 27);
            this.constrainFileEditButton.TabIndex = 11;
            this.constrainFileEditButton.Text = "编辑";
            this.constrainFileEditButton.UseVisualStyleBackColor = true;
            this.constrainFileEditButton.Click += new System.EventHandler(this.constrainFileEditButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "约束文件";
            // 
            // constrainFileText
            // 
            this.constrainFileText.Location = new System.Drawing.Point(86, 94);
            this.constrainFileText.Margin = new System.Windows.Forms.Padding(4);
            this.constrainFileText.Name = "constrainFileText";
            this.constrainFileText.ReadOnly = true;
            this.constrainFileText.Size = new System.Drawing.Size(211, 27);
            this.constrainFileText.TabIndex = 54;
            this.constrainFileText.TabStop = false;
            // 
            // outputFlolderChooseButton
            // 
            this.outputFlolderChooseButton.Location = new System.Drawing.Point(305, 62);
            this.outputFlolderChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.outputFlolderChooseButton.Name = "outputFlolderChooseButton";
            this.outputFlolderChooseButton.Size = new System.Drawing.Size(96, 27);
            this.outputFlolderChooseButton.TabIndex = 8;
            this.outputFlolderChooseButton.Text = "选择";
            this.outputFlolderChooseButton.UseVisualStyleBackColor = true;
            this.outputFlolderChooseButton.Click += new System.EventHandler(this.outputFolderChooseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "输出目录";
            // 
            // outputFolderText
            // 
            this.outputFolderText.Location = new System.Drawing.Point(86, 59);
            this.outputFolderText.Margin = new System.Windows.Forms.Padding(4);
            this.outputFolderText.Name = "outputFolderText";
            this.outputFolderText.ReadOnly = true;
            this.outputFolderText.Size = new System.Drawing.Size(211, 27);
            this.outputFolderText.TabIndex = 51;
            this.outputFolderText.TabStop = false;
            // 
            // inputFolderChooseButton
            // 
            this.inputFolderChooseButton.Location = new System.Drawing.Point(305, 26);
            this.inputFolderChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.inputFolderChooseButton.Name = "inputFolderChooseButton";
            this.inputFolderChooseButton.Size = new System.Drawing.Size(96, 27);
            this.inputFolderChooseButton.TabIndex = 6;
            this.inputFolderChooseButton.Text = "选择";
            this.inputFolderChooseButton.UseVisualStyleBackColor = true;
            this.inputFolderChooseButton.Click += new System.EventHandler(this.inputFolderChooseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "输入目录";
            // 
            // inputFolderText
            // 
            this.inputFolderText.Location = new System.Drawing.Point(86, 25);
            this.inputFolderText.Margin = new System.Windows.Forms.Padding(4);
            this.inputFolderText.Name = "inputFolderText";
            this.inputFolderText.ReadOnly = true;
            this.inputFolderText.Size = new System.Drawing.Size(211, 27);
            this.inputFolderText.TabIndex = 48;
            this.inputFolderText.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.noticeLabel);
            this.groupBox2.Location = new System.Drawing.Point(15, 552);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(517, 68);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通知";
            // 
            // noticeLabel
            // 
            this.noticeLabel.Location = new System.Drawing.Point(10, 22);
            this.noticeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(499, 39);
            this.noticeLabel.TabIndex = 0;
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.FileName = "results.zip";
            this.exportFileDialog.Title = "导出到...";
            // 
            // coreChooseFileDialog
            // 
            this.coreChooseFileDialog.FileName = "openFileDialog1";
            // 
            // coreSettingChooseFileDialog
            // 
            this.coreSettingChooseFileDialog.FileName = "openFileDialog1";
            // 
            // SeqCounterXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 630);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SeqCounterXForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeqCounterX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeqCounterXForm_FormClosing);
            this.Load += new System.EventHandler(this.SeqCounterXForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog constrainFileChooseDialog;
        private OpenFileDialog outputFileDialog;
        private Button readmeButton;
        private FolderBrowserDialog inputFolderBrowserDialog;
        private FolderBrowserDialog outputFolderBrowserDialog;
        private GroupBox groupBox1;
        private Button clearButton;
        private Button copeyToClipboardButton;
        private Button exportButton;
        private Button runButton;
        private GroupBox groupBox3;
        private Label label17;
        private Button coreChooseButton;
        private TextBox coreText;
        private Label label16;
        private Label label11;
        private ComboBox extractExtensionNameComboBox;
        private Label label10;
        private Label label9;
        private TextBox symbolsTextBox;
        private Label label8;
        private CheckBox singleExtractCheckBox;
        private CheckBox compareCheckBox;
        private CheckBox extractSeqCheckBox;
        private CheckBox seqTypeCheckBox;
        private ComboBox outputEncodingComboBox;
        private Label label7;
        private ComboBox inputEncodingComboBox;
        private Label label6;
        private ComboBox resultExtensionNameComboBox;
        private Label label5;
        private Label label4;
        private ComboBox seqExtensionNameComboBox;
        private Button constrainFileChooseButton;
        private Button outputFlolderOpenButton;
        private Button inputFolderOpenButton;
        private Button constrainFileEditButton;
        private Label label3;
        private TextBox constrainFileText;
        private Button outputFlolderChooseButton;
        private Label label2;
        private TextBox outputFolderText;
        private Button inputFolderChooseButton;
        private Label label1;
        private TextBox inputFolderText;
        private GroupBox groupBox2;
        private Button exitedButton;
        private Label noticeLabel;
        private SaveFileDialog exportFileDialog;
        private CheckBox combineCompareCheckBox;
        private TextBox removeSymbolsTextBox;
        private TextBox seqTypeListTextBox;
        private Button coreSettingChooseButton;
        private TextBox settingFileTextBox;
        private Label label12;
        private CheckBox ignoreEmptySeqCheckBox;
        private Label coreVerisonLabel;
        private Button recoverSettingButton;
        private OpenFileDialog coreChooseFileDialog;
        private OpenFileDialog coreSettingChooseFileDialog;
        private RichTextBox monitorRichTextBox;
    }
}