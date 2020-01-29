namespace Project
{
    partial class Form1
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
            this.tabTrainAndTest = new System.Windows.Forms.TabPage();
            this.tabStartRecognizing = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestXOR = new System.Windows.Forms.Button();
            this.btnTrainXOR = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.tabContainer.SuspendLayout();
            this.tabTrainAndTest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabStartRecognizing);
            this.tabContainer.Controls.Add(this.tabTrainAndTest);
            this.tabContainer.Location = new System.Drawing.Point(0, 1);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(795, 446);
            this.tabContainer.TabIndex = 0;
            // 
            // tabTrainAndTest
            // 
            this.tabTrainAndTest.Controls.Add(this.groupBox2);
            this.tabTrainAndTest.Controls.Add(this.groupBox1);
            this.tabTrainAndTest.Location = new System.Drawing.Point(4, 25);
            this.tabTrainAndTest.Name = "tabTrainAndTest";
            this.tabTrainAndTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainAndTest.Size = new System.Drawing.Size(787, 417);
            this.tabTrainAndTest.TabIndex = 0;
            this.tabTrainAndTest.Text = "Train and test";
            this.tabTrainAndTest.UseVisualStyleBackColor = true;
            // 
            // tabStartRecognizing
            // 
            this.tabStartRecognizing.Location = new System.Drawing.Point(4, 25);
            this.tabStartRecognizing.Name = "tabStartRecognizing";
            this.tabStartRecognizing.Size = new System.Drawing.Size(787, 417);
            this.tabStartRecognizing.TabIndex = 2;
            this.tabStartRecognizing.Text = "Recognize";
            this.tabStartRecognizing.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTrainXOR);
            this.groupBox1.Controls.Add(this.btnTestXOR);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Train on XOR";
            // 
            // btnTestXOR
            // 
            this.btnTestXOR.Location = new System.Drawing.Point(260, 151);
            this.btnTestXOR.Name = "btnTestXOR";
            this.btnTestXOR.Size = new System.Drawing.Size(119, 31);
            this.btnTestXOR.TabIndex = 0;
            this.btnTestXOR.Text = "Test XOR";
            this.btnTestXOR.UseVisualStyleBackColor = true;
            this.btnTestXOR.Click += new System.EventHandler(this.btnTestXOR_Click);
            // 
            // btnTrainXOR
            // 
            this.btnTrainXOR.Location = new System.Drawing.Point(102, 151);
            this.btnTrainXOR.Name = "btnTrainXOR";
            this.btnTrainXOR.Size = new System.Drawing.Size(111, 31);
            this.btnTrainXOR.TabIndex = 1;
            this.btnTrainXOR.Text = "Train XOR";
            this.btnTrainXOR.UseVisualStyleBackColor = true;
            this.btnTrainXOR.Click += new System.EventHandler(this.btnTrainXOR_Click);
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
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(6, 21);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(334, 377);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabContainer.ResumeLayout(false);
            this.tabTrainAndTest.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabTrainAndTest;
        private System.Windows.Forms.TabPage tabStartRecognizing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestXOR;
        private System.Windows.Forms.Button btnTrainXOR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtOutput;
    }
}

