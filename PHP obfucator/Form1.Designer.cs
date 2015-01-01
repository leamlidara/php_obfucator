namespace PHP_obfucator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAdvanceProtect = new System.Windows.Forms.CheckBox();
            this.chkProtectFunction = new System.Windows.Forms.CheckBox();
            this.chkProtectClass = new System.Windows.Forms.CheckBox();
            this.chkProtectVariable = new System.Windows.Forms.CheckBox();
            this.chkCopyPhpOnly = new System.Windows.Forms.CheckBox();
            this.btnProtect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnDest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fileFolderDialog1 = new PHP_obfucator.FileFolderDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ទីតាំងប្រភពឯកសារ";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(167, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(439, 32);
            this.txtSource.TabIndex = 0;
            // 
            // btnSource
            // 
            this.btnSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSource.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSource.Location = new System.Drawing.Point(612, 12);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(88, 32);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "ជ្រើសររើស";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkAdvanceProtect);
            this.groupBox1.Controls.Add(this.chkProtectFunction);
            this.groupBox1.Controls.Add(this.chkProtectClass);
            this.groupBox1.Controls.Add(this.chkProtectVariable);
            this.groupBox1.Controls.Add(this.chkCopyPhpOnly);
            this.groupBox1.Location = new System.Drawing.Point(19, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ជម្រើសសុវត្ថិភាព";
            // 
            // chkAdvanceProtect
            // 
            this.chkAdvanceProtect.AutoSize = true;
            this.chkAdvanceProtect.Checked = true;
            this.chkAdvanceProtect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdvanceProtect.Location = new System.Drawing.Point(210, 31);
            this.chkAdvanceProtect.Name = "chkAdvanceProtect";
            this.chkAdvanceProtect.Size = new System.Drawing.Size(166, 31);
            this.chkAdvanceProtect.TabIndex = 1;
            this.chkAdvanceProtect.Text = "ធ្វើការការពារកម្រិតខ្ពស់";
            this.chkAdvanceProtect.UseVisualStyleBackColor = true;
            this.chkAdvanceProtect.CheckedChanged += new System.EventHandler(this.chkAdvanceProtect_CheckedChanged);
            // 
            // chkProtectFunction
            // 
            this.chkProtectFunction.AutoSize = true;
            this.chkProtectFunction.Checked = true;
            this.chkProtectFunction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProtectFunction.Location = new System.Drawing.Point(210, 68);
            this.chkProtectFunction.Name = "chkProtectFunction";
            this.chkProtectFunction.Size = new System.Drawing.Size(158, 31);
            this.chkProtectFunction.TabIndex = 3;
            this.chkProtectFunction.Text = "ការពារឈ្មោះអនុគមន៍";
            this.chkProtectFunction.UseVisualStyleBackColor = true;
            this.chkProtectFunction.CheckedChanged += new System.EventHandler(this.chkAdvanceProtect_CheckedChanged);
            // 
            // chkProtectClass
            // 
            this.chkProtectClass.AutoSize = true;
            this.chkProtectClass.Checked = true;
            this.chkProtectClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProtectClass.Location = new System.Drawing.Point(398, 68);
            this.chkProtectClass.Name = "chkProtectClass";
            this.chkProtectClass.Size = new System.Drawing.Size(144, 31);
            this.chkProtectClass.TabIndex = 4;
            this.chkProtectClass.Text = "ការពារឈ្មោះ Class";
            this.chkProtectClass.UseVisualStyleBackColor = true;
            this.chkProtectClass.CheckedChanged += new System.EventHandler(this.chkAdvanceProtect_CheckedChanged);
            // 
            // chkProtectVariable
            // 
            this.chkProtectVariable.AutoSize = true;
            this.chkProtectVariable.Checked = true;
            this.chkProtectVariable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProtectVariable.Location = new System.Drawing.Point(16, 65);
            this.chkProtectVariable.Name = "chkProtectVariable";
            this.chkProtectVariable.Size = new System.Drawing.Size(138, 31);
            this.chkProtectVariable.TabIndex = 2;
            this.chkProtectVariable.Text = "ការពារឈ្មោះអថេរ";
            this.chkProtectVariable.UseVisualStyleBackColor = true;
            this.chkProtectVariable.CheckedChanged += new System.EventHandler(this.chkAdvanceProtect_CheckedChanged);
            // 
            // chkCopyPhpOnly
            // 
            this.chkCopyPhpOnly.AutoSize = true;
            this.chkCopyPhpOnly.Checked = true;
            this.chkCopyPhpOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyPhpOnly.Location = new System.Drawing.Point(16, 31);
            this.chkCopyPhpOnly.Name = "chkCopyPhpOnly";
            this.chkCopyPhpOnly.Size = new System.Drawing.Size(166, 31);
            this.chkCopyPhpOnly.TabIndex = 0;
            this.chkCopyPhpOnly.Text = "ចម្លងឯកសារត្រួវការពារ";
            this.chkCopyPhpOnly.UseVisualStyleBackColor = true;
            this.chkCopyPhpOnly.CheckedChanged += new System.EventHandler(this.chkAdvanceProtect_CheckedChanged);
            // 
            // btnProtect
            // 
            this.btnProtect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProtect.Location = new System.Drawing.Point(603, 98);
            this.btnProtect.Name = "btnProtect";
            this.btnProtect.Size = new System.Drawing.Size(97, 45);
            this.btnProtect.TabIndex = 5;
            this.btnProtect.Text = "ការពារ";
            this.btnProtect.UseVisualStyleBackColor = true;
            this.btnProtect.Click += new System.EventHandler(this.btnProtect_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(12, 210);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(693, 213);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(603, 429);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(102, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "ទីតាំងគោលដៅឯកសារ";
            // 
            // txtDest
            // 
            this.txtDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDest.Location = new System.Drawing.Point(167, 50);
            this.txtDest.Name = "txtDest";
            this.txtDest.ReadOnly = true;
            this.txtDest.Size = new System.Drawing.Size(439, 32);
            this.txtDest.TabIndex = 2;
            // 
            // btnDest
            // 
            this.btnDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDest.Location = new System.Drawing.Point(612, 50);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(88, 32);
            this.btnDest.TabIndex = 3;
            this.btnDest.Text = "ជ្រើសររើស";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Help;
            this.label3.Location = new System.Drawing.Point(645, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "?";
            this.toolTip1.SetToolTip(this.label3, "ជំនួយ");
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fileFolderDialog1
            // 
            this.fileFolderDialog1.SelectedPath = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 462);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnProtect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDest);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khmer OS", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "កម្មវិធីការពារកូដ PHP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private FileFolderDialog fileFolderDialog1;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCopyPhpOnly;
        private System.Windows.Forms.CheckBox chkAdvanceProtect;
        private System.Windows.Forms.Button btnProtect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkProtectFunction;
        private System.Windows.Forms.CheckBox chkProtectVariable;
        private System.Windows.Forms.CheckBox chkProtectClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

