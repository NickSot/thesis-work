﻿namespace Project
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdTrainingData = new System.Windows.Forms.OpenFileDialog();
            this.ofdTrainingLabels = new System.Windows.Forms.OpenFileDialog();
            this.ofdValidateModel = new System.Windows.Forms.OpenFileDialog();
            this.tabCreateModels = new System.Windows.Forms.TabPage();
            this.gbViewModelDetails = new System.Windows.Forms.GroupBox();
            this.btnOutputModelDetails = new System.Windows.Forms.Button();
            this.cbModelViewDetails = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCompareModels = new System.Windows.Forms.GroupBox();
            this.gbOutputText = new System.Windows.Forms.GroupBox();
            this.rtxtComparisonResults = new System.Windows.Forms.RichTextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtSecondModelNameCmp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFirstModelNameCmp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbCreateModel = new System.Windows.Forms.GroupBox();
            this.btnClearOurpurCreate = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.txtModelDimensions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.tabTrainAndTest = new System.Windows.Forms.TabPage();
            this.groupBoxValidate = new System.Windows.Forms.GroupBox();
            this.btnCancelValidation = new System.Windows.Forms.Button();
            this.btnValidateModel = new System.Windows.Forms.Button();
            this.btnOpenValidation = new System.Windows.Forms.Button();
            this.txtValidateModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.groupBoxTrainTest = new System.Windows.Forms.GroupBox();
            this.txtModelNameTrain = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pbModelOperation = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.btnSelectLabelsFile = new System.Windows.Forms.Button();
            this.txtLabelFileNames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrepareData = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSelectInputFile = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabCreateModels.SuspendLayout();
            this.gbViewModelDetails.SuspendLayout();
            this.gbCompareModels.SuspendLayout();
            this.gbOutputText.SuspendLayout();
            this.gbCreateModel.SuspendLayout();
            this.tabTrainAndTest.SuspendLayout();
            this.groupBoxValidate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxTrainTest.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdTrainingData
            // 
            this.ofdTrainingData.FileName = "SelectedFile";
            this.ofdTrainingData.Multiselect = true;
            this.ofdTrainingData.Title = "Choose file";
            // 
            // ofdTrainingLabels
            // 
            this.ofdTrainingLabels.FileName = "SelectedFile";
            this.ofdTrainingLabels.Multiselect = true;
            // 
            // ofdValidateModel
            // 
            this.ofdValidateModel.FileName = "SelectedFile";
            // 
            // tabCreateModels
            // 
            this.tabCreateModels.Controls.Add(this.gbViewModelDetails);
            this.tabCreateModels.Controls.Add(this.gbCompareModels);
            this.tabCreateModels.Controls.Add(this.gbCreateModel);
            this.tabCreateModels.Location = new System.Drawing.Point(4, 25);
            this.tabCreateModels.Name = "tabCreateModels";
            this.tabCreateModels.Size = new System.Drawing.Size(881, 501);
            this.tabCreateModels.TabIndex = 3;
            this.tabCreateModels.Text = "Create and compare models";
            this.tabCreateModels.UseVisualStyleBackColor = true;
            // 
            // gbViewModelDetails
            // 
            this.gbViewModelDetails.Controls.Add(this.btnOutputModelDetails);
            this.gbViewModelDetails.Controls.Add(this.cbModelViewDetails);
            this.gbViewModelDetails.Controls.Add(this.label9);
            this.gbViewModelDetails.Location = new System.Drawing.Point(8, 188);
            this.gbViewModelDetails.Name = "gbViewModelDetails";
            this.gbViewModelDetails.Size = new System.Drawing.Size(373, 154);
            this.gbViewModelDetails.TabIndex = 5;
            this.gbViewModelDetails.TabStop = false;
            this.gbViewModelDetails.Text = "View model details";
            // 
            // btnOutputModelDetails
            // 
            this.btnOutputModelDetails.Location = new System.Drawing.Point(245, 99);
            this.btnOutputModelDetails.Name = "btnOutputModelDetails";
            this.btnOutputModelDetails.Size = new System.Drawing.Size(111, 36);
            this.btnOutputModelDetails.TabIndex = 2;
            this.btnOutputModelDetails.Text = "Output Details";
            this.btnOutputModelDetails.UseVisualStyleBackColor = true;
            this.btnOutputModelDetails.Click += new System.EventHandler(this.btnOutputModelDetails_Click);
            // 
            // cbModelViewDetails
            // 
            this.cbModelViewDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelViewDetails.FormattingEnabled = true;
            this.cbModelViewDetails.Location = new System.Drawing.Point(104, 46);
            this.cbModelViewDetails.Name = "cbModelViewDetails";
            this.cbModelViewDetails.Size = new System.Drawing.Size(252, 24);
            this.cbModelViewDetails.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Model name";
            // 
            // gbCompareModels
            // 
            this.gbCompareModels.Controls.Add(this.gbOutputText);
            this.gbCompareModels.Controls.Add(this.btnCompare);
            this.gbCompareModels.Controls.Add(this.txtSecondModelNameCmp);
            this.gbCompareModels.Controls.Add(this.label8);
            this.gbCompareModels.Controls.Add(this.txtFirstModelNameCmp);
            this.gbCompareModels.Controls.Add(this.label7);
            this.gbCompareModels.Location = new System.Drawing.Point(388, 3);
            this.gbCompareModels.Name = "gbCompareModels";
            this.gbCompareModels.Size = new System.Drawing.Size(448, 484);
            this.gbCompareModels.TabIndex = 4;
            this.gbCompareModels.TabStop = false;
            this.gbCompareModels.Text = "Compare models";
            // 
            // gbOutputText
            // 
            this.gbOutputText.Controls.Add(this.rtxtComparisonResults);
            this.gbOutputText.Location = new System.Drawing.Point(9, 102);
            this.gbOutputText.Name = "gbOutputText";
            this.gbOutputText.Size = new System.Drawing.Size(426, 375);
            this.gbOutputText.TabIndex = 7;
            this.gbOutputText.TabStop = false;
            this.gbOutputText.Text = "ouput";
            // 
            // rtxtComparisonResults
            // 
            this.rtxtComparisonResults.Location = new System.Drawing.Point(14, 21);
            this.rtxtComparisonResults.Name = "rtxtComparisonResults";
            this.rtxtComparisonResults.Size = new System.Drawing.Size(394, 330);
            this.rtxtComparisonResults.TabIndex = 6;
            this.rtxtComparisonResults.Text = "";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(330, 64);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(105, 32);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtSecondModelNameCmp
            // 
            this.txtSecondModelNameCmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSecondModelNameCmp.FormattingEnabled = true;
            this.txtSecondModelNameCmp.Location = new System.Drawing.Point(110, 72);
            this.txtSecondModelNameCmp.Name = "txtSecondModelNameCmp";
            this.txtSecondModelNameCmp.Size = new System.Drawing.Size(189, 24);
            this.txtSecondModelNameCmp.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Second model";
            // 
            // txtFirstModelNameCmp
            // 
            this.txtFirstModelNameCmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFirstModelNameCmp.FormattingEnabled = true;
            this.txtFirstModelNameCmp.Location = new System.Drawing.Point(110, 34);
            this.txtFirstModelNameCmp.Name = "txtFirstModelNameCmp";
            this.txtFirstModelNameCmp.Size = new System.Drawing.Size(189, 24);
            this.txtFirstModelNameCmp.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "First model";
            // 
            // gbCreateModel
            // 
            this.gbCreateModel.Controls.Add(this.btnClearOurpurCreate);
            this.gbCreateModel.Controls.Add(this.btnCreateModel);
            this.gbCreateModel.Controls.Add(this.txtModelDimensions);
            this.gbCreateModel.Controls.Add(this.label5);
            this.gbCreateModel.Controls.Add(this.txtModelName);
            this.gbCreateModel.Controls.Add(this.lblModelName);
            this.gbCreateModel.Location = new System.Drawing.Point(8, 3);
            this.gbCreateModel.Name = "gbCreateModel";
            this.gbCreateModel.Size = new System.Drawing.Size(373, 169);
            this.gbCreateModel.TabIndex = 3;
            this.gbCreateModel.TabStop = false;
            this.gbCreateModel.Text = "Create model architecture";
            // 
            // btnClearOurpurCreate
            // 
            this.btnClearOurpurCreate.Location = new System.Drawing.Point(25, 113);
            this.btnClearOurpurCreate.Name = "btnClearOurpurCreate";
            this.btnClearOurpurCreate.Size = new System.Drawing.Size(105, 38);
            this.btnClearOurpurCreate.TabIndex = 8;
            this.btnClearOurpurCreate.Text = "Clear Output";
            this.btnClearOurpurCreate.UseVisualStyleBackColor = true;
            this.btnClearOurpurCreate.Click += new System.EventHandler(this.btnClearOurpurCreate_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(245, 113);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(111, 38);
            this.btnCreateModel.TabIndex = 7;
            this.btnCreateModel.Text = "Create Model";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // txtModelDimensions
            // 
            this.txtModelDimensions.Location = new System.Drawing.Point(137, 76);
            this.txtModelDimensions.Name = "txtModelDimensions";
            this.txtModelDimensions.Size = new System.Drawing.Size(219, 22);
            this.txtModelDimensions.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Model dimensions";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(137, 35);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(219, 22);
            this.txtModelName.TabIndex = 4;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(9, 35);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(85, 17);
            this.lblModelName.TabIndex = 3;
            this.lblModelName.Text = "Model name";
            // 
            // tabTrainAndTest
            // 
            this.tabTrainAndTest.Controls.Add(this.groupBoxValidate);
            this.tabTrainAndTest.Controls.Add(this.groupBox2);
            this.tabTrainAndTest.Controls.Add(this.groupBoxTrainTest);
            this.tabTrainAndTest.Location = new System.Drawing.Point(4, 25);
            this.tabTrainAndTest.Name = "tabTrainAndTest";
            this.tabTrainAndTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainAndTest.Size = new System.Drawing.Size(881, 501);
            this.tabTrainAndTest.TabIndex = 0;
            this.tabTrainAndTest.Text = "Train and test";
            this.tabTrainAndTest.UseVisualStyleBackColor = true;
            // 
            // groupBoxValidate
            // 
            this.groupBoxValidate.Controls.Add(this.btnCancelValidation);
            this.groupBoxValidate.Controls.Add(this.btnValidateModel);
            this.groupBoxValidate.Controls.Add(this.btnOpenValidation);
            this.groupBoxValidate.Controls.Add(this.txtValidateModel);
            this.groupBoxValidate.Controls.Add(this.label3);
            this.groupBoxValidate.Location = new System.Drawing.Point(9, 366);
            this.groupBoxValidate.Name = "groupBoxValidate";
            this.groupBoxValidate.Size = new System.Drawing.Size(411, 110);
            this.groupBoxValidate.TabIndex = 2;
            this.groupBoxValidate.TabStop = false;
            this.groupBoxValidate.Text = "Manual model validation";
            // 
            // btnCancelValidation
            // 
            this.btnCancelValidation.Location = new System.Drawing.Point(6, 62);
            this.btnCancelValidation.Name = "btnCancelValidation";
            this.btnCancelValidation.Size = new System.Drawing.Size(118, 42);
            this.btnCancelValidation.TabIndex = 4;
            this.btnCancelValidation.Text = "Cancel validation";
            this.btnCancelValidation.UseVisualStyleBackColor = true;
            this.btnCancelValidation.Click += new System.EventHandler(this.btnCancelValidation_Click);
            // 
            // btnValidateModel
            // 
            this.btnValidateModel.Location = new System.Drawing.Point(287, 55);
            this.btnValidateModel.Name = "btnValidateModel";
            this.btnValidateModel.Size = new System.Drawing.Size(118, 49);
            this.btnValidateModel.TabIndex = 3;
            this.btnValidateModel.Text = "Validate";
            this.btnValidateModel.UseVisualStyleBackColor = true;
            this.btnValidateModel.Click += new System.EventHandler(this.btnValidateModel_Click);
            // 
            // btnOpenValidation
            // 
            this.btnOpenValidation.Location = new System.Drawing.Point(312, 21);
            this.btnOpenValidation.Name = "btnOpenValidation";
            this.btnOpenValidation.Size = new System.Drawing.Size(87, 28);
            this.btnOpenValidation.TabIndex = 2;
            this.btnOpenValidation.Text = "Open...";
            this.btnOpenValidation.UseVisualStyleBackColor = true;
            this.btnOpenValidation.Click += new System.EventHandler(this.btnOpenValidation_Click);
            // 
            // txtValidateModel
            // 
            this.txtValidateModel.Location = new System.Drawing.Point(105, 25);
            this.txtValidateModel.Name = "txtValidateModel";
            this.txtValidateModel.Size = new System.Drawing.Size(201, 22);
            this.txtValidateModel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Validation File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Location = new System.Drawing.Point(435, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 492);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "output";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(6, 21);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(334, 449);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // groupBoxTrainTest
            // 
            this.groupBoxTrainTest.Controls.Add(this.txtModelNameTrain);
            this.groupBoxTrainTest.Controls.Add(this.label6);
            this.groupBoxTrainTest.Controls.Add(this.pbModelOperation);
            this.groupBoxTrainTest.Controls.Add(this.label4);
            this.groupBoxTrainTest.Controls.Add(this.btnClearOutput);
            this.groupBoxTrainTest.Controls.Add(this.btnLoadModel);
            this.groupBoxTrainTest.Controls.Add(this.btnSaveModel);
            this.groupBoxTrainTest.Controls.Add(this.btnSelectLabelsFile);
            this.groupBoxTrainTest.Controls.Add(this.txtLabelFileNames);
            this.groupBoxTrainTest.Controls.Add(this.label2);
            this.groupBoxTrainTest.Controls.Add(this.label1);
            this.groupBoxTrainTest.Controls.Add(this.btnPrepareData);
            this.groupBoxTrainTest.Controls.Add(this.txtFileName);
            this.groupBoxTrainTest.Controls.Add(this.btnSelectInputFile);
            this.groupBoxTrainTest.Controls.Add(this.btnTrain);
            this.groupBoxTrainTest.Controls.Add(this.btnTest);
            this.groupBoxTrainTest.Location = new System.Drawing.Point(9, 6);
            this.groupBoxTrainTest.Name = "groupBoxTrainTest";
            this.groupBoxTrainTest.Size = new System.Drawing.Size(411, 326);
            this.groupBoxTrainTest.TabIndex = 0;
            this.groupBoxTrainTest.TabStop = false;
            this.groupBoxTrainTest.Text = "Data preparation and feeding";
            // 
            // txtModelNameTrain
            // 
            this.txtModelNameTrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModelNameTrain.FormattingEnabled = true;
            this.txtModelNameTrain.Location = new System.Drawing.Point(100, 121);
            this.txtModelNameTrain.Name = "txtModelNameTrain";
            this.txtModelNameTrain.Size = new System.Drawing.Size(290, 24);
            this.txtModelNameTrain.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Model Name";
            // 
            // pbModelOperation
            // 
            this.pbModelOperation.Location = new System.Drawing.Point(136, 262);
            this.pbModelOperation.Name = "pbModelOperation";
            this.pbModelOperation.Size = new System.Drawing.Size(265, 23);
            this.pbModelOperation.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Operation progress";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Location = new System.Drawing.Point(267, 207);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(123, 33);
            this.btnClearOutput.TabIndex = 11;
            this.btnClearOutput.Text = "Clear output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(140, 207);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(100, 33);
            this.btnLoadModel.TabIndex = 10;
            this.btnLoadModel.Text = "Load Model";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Enabled = false;
            this.btnSaveModel.Location = new System.Drawing.Point(6, 207);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(99, 33);
            this.btnSaveModel.TabIndex = 9;
            this.btnSaveModel.Text = "Save model";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btnSelectLabelsFile
            // 
            this.btnSelectLabelsFile.Location = new System.Drawing.Point(299, 79);
            this.btnSelectLabelsFile.Name = "btnSelectLabelsFile";
            this.btnSelectLabelsFile.Size = new System.Drawing.Size(95, 31);
            this.btnSelectLabelsFile.TabIndex = 8;
            this.btnSelectLabelsFile.Text = "Open...";
            this.btnSelectLabelsFile.UseVisualStyleBackColor = true;
            this.btnSelectLabelsFile.Click += new System.EventHandler(this.btnSelectLabelsFile_Click);
            // 
            // txtLabelFileNames
            // 
            this.txtLabelFileNames.Enabled = false;
            this.txtLabelFileNames.Location = new System.Drawing.Point(63, 83);
            this.txtLabelFileNames.Name = "txtLabelFileNames";
            this.txtLabelFileNames.Size = new System.Drawing.Size(230, 22);
            this.txtLabelFileNames.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Labels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input data";
            // 
            // btnPrepareData
            // 
            this.btnPrepareData.Location = new System.Drawing.Point(267, 157);
            this.btnPrepareData.Name = "btnPrepareData";
            this.btnPrepareData.Size = new System.Drawing.Size(123, 31);
            this.btnPrepareData.TabIndex = 4;
            this.btnPrepareData.Text = "Prepare Data";
            this.btnPrepareData.UseVisualStyleBackColor = true;
            this.btnPrepareData.Click += new System.EventHandler(this.btnPrepareData_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(83, 43);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(210, 22);
            this.txtFileName.TabIndex = 3;
            // 
            // btnSelectInputFile
            // 
            this.btnSelectInputFile.Location = new System.Drawing.Point(299, 39);
            this.btnSelectInputFile.Name = "btnSelectInputFile";
            this.btnSelectInputFile.Size = new System.Drawing.Size(95, 31);
            this.btnSelectInputFile.TabIndex = 2;
            this.btnSelectInputFile.Text = "Open...";
            this.btnSelectInputFile.UseVisualStyleBackColor = true;
            this.btnSelectInputFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(6, 157);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(99, 31);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(140, 157);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 31);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabTrainAndTest);
            this.tabContainer.Controls.Add(this.tabCreateModels);
            this.tabContainer.Location = new System.Drawing.Point(0, 1);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(889, 530);
            this.tabContainer.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 536);
            this.Controls.Add(this.tabContainer);
            this.Name = "Main";
            this.Text = "CyberVerse";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabCreateModels.ResumeLayout(false);
            this.gbViewModelDetails.ResumeLayout(false);
            this.gbViewModelDetails.PerformLayout();
            this.gbCompareModels.ResumeLayout(false);
            this.gbCompareModels.PerformLayout();
            this.gbOutputText.ResumeLayout(false);
            this.gbCreateModel.ResumeLayout(false);
            this.gbCreateModel.PerformLayout();
            this.tabTrainAndTest.ResumeLayout(false);
            this.groupBoxValidate.ResumeLayout(false);
            this.groupBoxValidate.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxTrainTest.ResumeLayout(false);
            this.groupBoxTrainTest.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdTrainingData;
        private System.Windows.Forms.OpenFileDialog ofdTrainingLabels;
        private System.Windows.Forms.OpenFileDialog ofdValidateModel;
        private System.Windows.Forms.TabPage tabCreateModels;
        private System.Windows.Forms.GroupBox gbCompareModels;
        private System.Windows.Forms.RichTextBox rtxtComparisonResults;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ComboBox txtSecondModelNameCmp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtFirstModelNameCmp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbCreateModel;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.TextBox txtModelDimensions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TabPage tabTrainAndTest;
        private System.Windows.Forms.GroupBox groupBoxValidate;
        private System.Windows.Forms.Button btnValidateModel;
        private System.Windows.Forms.Button btnOpenValidation;
        private System.Windows.Forms.TextBox txtValidateModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.GroupBox groupBoxTrainTest;
        private System.Windows.Forms.ComboBox txtModelNameTrain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar pbModelOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.Button btnSelectLabelsFile;
        private System.Windows.Forms.TextBox txtLabelFileNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrepareData;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSelectInputFile;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.Button btnClearOurpurCreate;
        private System.Windows.Forms.GroupBox gbViewModelDetails;
        private System.Windows.Forms.ComboBox cbModelViewDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOutputModelDetails;
        private System.Windows.Forms.GroupBox gbOutputText;
        private System.Windows.Forms.Button btnCancelValidation;
    }
}

