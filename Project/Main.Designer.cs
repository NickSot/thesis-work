namespace Project
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
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabStartRecognizing = new System.Windows.Forms.TabPage();
            this.btnRealTimeDetection = new System.Windows.Forms.Button();
            this.tabTrainAndTest = new System.Windows.Forms.TabPage();
            this.groupBoxValidate = new System.Windows.Forms.GroupBox();
            this.btnValidateModel = new System.Windows.Forms.Button();
            this.btnOpenValidation = new System.Windows.Forms.Button();
            this.txtValidateModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.groupBoxTrainTest = new System.Windows.Forms.GroupBox();
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
            this.tabCreateModels = new System.Windows.Forms.TabPage();
            this.gbCreateModel = new System.Windows.Forms.GroupBox();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.txtModelDimensions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblTabModels = new System.Windows.Forms.Label();
            this.ofdTrainingData = new System.Windows.Forms.OpenFileDialog();
            this.ofdTrainingLabels = new System.Windows.Forms.OpenFileDialog();
            this.ofdValidateModel = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModelNameTrain = new System.Windows.Forms.TextBox();
            this.tabContainer.SuspendLayout();
            this.tabStartRecognizing.SuspendLayout();
            this.tabTrainAndTest.SuspendLayout();
            this.groupBoxValidate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxTrainTest.SuspendLayout();
            this.tabCreateModels.SuspendLayout();
            this.gbCreateModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabStartRecognizing);
            this.tabContainer.Controls.Add(this.tabTrainAndTest);
            this.tabContainer.Controls.Add(this.tabCreateModels);
            this.tabContainer.Location = new System.Drawing.Point(0, 1);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(795, 446);
            this.tabContainer.TabIndex = 0;
            // 
            // tabStartRecognizing
            // 
            this.tabStartRecognizing.Controls.Add(this.btnRealTimeDetection);
            this.tabStartRecognizing.Location = new System.Drawing.Point(4, 25);
            this.tabStartRecognizing.Name = "tabStartRecognizing";
            this.tabStartRecognizing.Size = new System.Drawing.Size(787, 417);
            this.tabStartRecognizing.TabIndex = 2;
            this.tabStartRecognizing.Text = "Recognize";
            this.tabStartRecognizing.UseVisualStyleBackColor = true;
            // 
            // btnRealTimeDetection
            // 
            this.btnRealTimeDetection.Location = new System.Drawing.Point(158, 24);
            this.btnRealTimeDetection.Name = "btnRealTimeDetection";
            this.btnRealTimeDetection.Size = new System.Drawing.Size(128, 44);
            this.btnRealTimeDetection.TabIndex = 0;
            this.btnRealTimeDetection.Text = "Start real-time detection";
            this.btnRealTimeDetection.UseVisualStyleBackColor = true;
            this.btnRealTimeDetection.Click += new System.EventHandler(this.btnRealTimeDetection_Click);
            // 
            // tabTrainAndTest
            // 
            this.tabTrainAndTest.Controls.Add(this.groupBoxValidate);
            this.tabTrainAndTest.Controls.Add(this.groupBox2);
            this.tabTrainAndTest.Controls.Add(this.groupBoxTrainTest);
            this.tabTrainAndTest.Location = new System.Drawing.Point(4, 25);
            this.tabTrainAndTest.Name = "tabTrainAndTest";
            this.tabTrainAndTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainAndTest.Size = new System.Drawing.Size(787, 417);
            this.tabTrainAndTest.TabIndex = 0;
            this.tabTrainAndTest.Text = "Train and test";
            this.tabTrainAndTest.UseVisualStyleBackColor = true;
            // 
            // groupBoxValidate
            // 
            this.groupBoxValidate.Controls.Add(this.btnValidateModel);
            this.groupBoxValidate.Controls.Add(this.btnOpenValidation);
            this.groupBoxValidate.Controls.Add(this.txtValidateModel);
            this.groupBoxValidate.Controls.Add(this.label3);
            this.groupBoxValidate.Location = new System.Drawing.Point(3, 298);
            this.groupBoxValidate.Name = "groupBoxValidate";
            this.groupBoxValidate.Size = new System.Drawing.Size(411, 110);
            this.groupBoxValidate.TabIndex = 2;
            this.groupBoxValidate.TabStop = false;
            this.groupBoxValidate.Text = "Manual model validation";
            // 
            // btnValidateModel
            // 
            this.btnValidateModel.Location = new System.Drawing.Point(287, 72);
            this.btnValidateModel.Name = "btnValidateModel";
            this.btnValidateModel.Size = new System.Drawing.Size(118, 32);
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
            this.groupBox2.Location = new System.Drawing.Point(434, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 405);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "output";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(6, 21);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(334, 377);
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
            this.groupBoxTrainTest.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTrainTest.Name = "groupBoxTrainTest";
            this.groupBoxTrainTest.Size = new System.Drawing.Size(411, 294);
            this.groupBoxTrainTest.TabIndex = 0;
            this.groupBoxTrainTest.TabStop = false;
            this.groupBoxTrainTest.Text = "Data preparation and feeding";
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
            // tabCreateModels
            // 
            this.tabCreateModels.Controls.Add(this.gbCreateModel);
            this.tabCreateModels.Controls.Add(this.lblTabModels);
            this.tabCreateModels.Location = new System.Drawing.Point(4, 25);
            this.tabCreateModels.Name = "tabCreateModels";
            this.tabCreateModels.Size = new System.Drawing.Size(787, 417);
            this.tabCreateModels.TabIndex = 3;
            this.tabCreateModels.Text = "Create Models";
            this.tabCreateModels.UseVisualStyleBackColor = true;
            // 
            // gbCreateModel
            // 
            this.gbCreateModel.Controls.Add(this.btnCreateModel);
            this.gbCreateModel.Controls.Add(this.txtModelDimensions);
            this.gbCreateModel.Controls.Add(this.label5);
            this.gbCreateModel.Controls.Add(this.txtModelName);
            this.gbCreateModel.Controls.Add(this.lblModelName);
            this.gbCreateModel.Location = new System.Drawing.Point(19, 59);
            this.gbCreateModel.Name = "gbCreateModel";
            this.gbCreateModel.Size = new System.Drawing.Size(373, 169);
            this.gbCreateModel.TabIndex = 3;
            this.gbCreateModel.TabStop = false;
            this.gbCreateModel.Text = "Create model architecture";
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
            // lblTabModels
            // 
            this.lblTabModels.AutoSize = true;
            this.lblTabModels.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblTabModels.ForeColor = System.Drawing.Color.Black;
            this.lblTabModels.Location = new System.Drawing.Point(125, 14);
            this.lblTabModels.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblTabModels.Name = "lblTabModels";
            this.lblTabModels.Size = new System.Drawing.Size(524, 27);
            this.lblTabModels.TabIndex = 0;
            this.lblTabModels.Text = "In this tab you can create models and manage models";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Model Name";
            // 
            // txtModelNameTrain
            // 
            this.txtModelNameTrain.Location = new System.Drawing.Point(101, 121);
            this.txtModelNameTrain.Name = "txtModelNameTrain";
            this.txtModelNameTrain.Size = new System.Drawing.Size(289, 22);
            this.txtModelNameTrain.TabIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 459);
            this.Controls.Add(this.tabContainer);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabContainer.ResumeLayout(false);
            this.tabStartRecognizing.ResumeLayout(false);
            this.tabTrainAndTest.ResumeLayout(false);
            this.groupBoxValidate.ResumeLayout(false);
            this.groupBoxValidate.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxTrainTest.ResumeLayout(false);
            this.groupBoxTrainTest.PerformLayout();
            this.tabCreateModels.ResumeLayout(false);
            this.tabCreateModels.PerformLayout();
            this.gbCreateModel.ResumeLayout(false);
            this.gbCreateModel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabTrainAndTest;
        private System.Windows.Forms.TabPage tabStartRecognizing;
        private System.Windows.Forms.GroupBox groupBoxTrainTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.OpenFileDialog ofdTrainingData;
        private System.Windows.Forms.Button btnSelectInputFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnPrepareData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLabelFileNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdTrainingLabels;
        private System.Windows.Forms.Button btnSelectLabelsFile;
        private System.Windows.Forms.GroupBox groupBoxValidate;
        private System.Windows.Forms.Button btnOpenValidation;
        private System.Windows.Forms.TextBox txtValidateModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnValidateModel;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.OpenFileDialog ofdValidateModel;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbModelOperation;
        private System.Windows.Forms.Button btnRealTimeDetection;
        private System.Windows.Forms.TabPage tabCreateModels;
        private System.Windows.Forms.Label lblTabModels;
        private System.Windows.Forms.GroupBox gbCreateModel;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox txtModelDimensions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.TextBox txtModelNameTrain;
        private System.Windows.Forms.Label label6;
    }
}

