using System.Drawing;
using System.Windows.Forms;

namespace MinitabMenu
{
    partial class FormDescribe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDescribe));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMean = new System.Windows.Forms.CheckBox();
            this.chkVariance = new System.Windows.Forms.CheckBox();
            this.chkSum = new System.Windows.Forms.CheckBox();
            this.chkNnonmissing = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHistogram = new System.Windows.Forms.CheckBox();
            this.chkBoxplot = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkedListBoxOfColumns = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Column(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stats";
            // 
            // chkMean
            // 
            this.chkMean.AutoSize = true;
            this.chkMean.Location = new System.Drawing.Point(274, 35);
            this.chkMean.Name = "chkMean";
            this.chkMean.Size = new System.Drawing.Size(61, 19);
            this.chkMean.TabIndex = 3;
            this.chkMean.Text = "&Mean";
            this.chkMean.UseVisualStyleBackColor = true;
            // 
            // chkVariance
            // 
            this.chkVariance.AutoSize = true;
            this.chkVariance.Location = new System.Drawing.Point(274, 65);
            this.chkVariance.Name = "chkVariance";
            this.chkVariance.Size = new System.Drawing.Size(93, 19);
            this.chkVariance.TabIndex = 4;
            this.chkVariance.Text = "&Variance";
            this.chkVariance.UseVisualStyleBackColor = true;
            // 
            // chkSum
            // 
            this.chkSum.AutoSize = true;
            this.chkSum.Location = new System.Drawing.Point(274, 95);
            this.chkSum.Name = "chkSum";
            this.chkSum.Size = new System.Drawing.Size(53, 19);
            this.chkSum.TabIndex = 5;
            this.chkSum.Text = "&Sum";
            this.chkSum.UseVisualStyleBackColor = true;
            // 
            // chkNnonmissing
            // 
            this.chkNnonmissing.AutoSize = true;
            this.chkNnonmissing.Location = new System.Drawing.Point(274, 125);
            this.chkNnonmissing.Name = "chkNnonmissing";
            this.chkNnonmissing.Size = new System.Drawing.Size(125, 19);
            this.chkNnonmissing.TabIndex = 6;
            this.chkNnonmissing.Text = "&N nonmissing";
            this.chkNnonmissing.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Graphs";
            // 
            // chkHistogram
            // 
            this.chkHistogram.AutoSize = true;
            this.chkHistogram.Location = new System.Drawing.Point(274, 181);
            this.chkHistogram.Name = "chkHistogram";
            this.chkHistogram.Size = new System.Drawing.Size(101, 19);
            this.chkHistogram.TabIndex = 8;
            this.chkHistogram.Text = "&Histogram";
            this.chkHistogram.UseVisualStyleBackColor = true;
            // 
            // chkBoxplot
            // 
            this.chkBoxplot.AutoSize = true;
            this.chkBoxplot.Location = new System.Drawing.Point(274, 211);
            this.chkBoxplot.Name = "chkBoxplot";
            this.chkBoxplot.Size = new System.Drawing.Size(85, 19);
            this.chkBoxplot.TabIndex = 9;
            this.chkBoxplot.Text = "&Boxplot";
            this.chkBoxplot.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(288, 267);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(37, 267);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxOfColumns
            // 
            this.checkedListBoxOfColumns.CheckOnClick = true;
            this.checkedListBoxOfColumns.FormattingEnabled = true;
            this.checkedListBoxOfColumns.Location = new System.Drawing.Point(26, 49);
            this.checkedListBoxOfColumns.Name = "checkedListBoxOfColumns";
            this.checkedListBoxOfColumns.Size = new System.Drawing.Size(190, 184);
            this.checkedListBoxOfColumns.TabIndex = 12;
            // 
            // FormDescribe
            // 
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(394, 304);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBoxOfColumns);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.chkBoxplot);
            this.Controls.Add(this.chkHistogram);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkNnonmissing);
            this.Controls.Add(this.chkSum);
            this.Controls.Add(this.chkVariance);
            this.Controls.Add(this.chkMean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDescribe";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Descriptive Statistics";
            this.Load += new System.EventHandler(this.FormDescribe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label label1;
        public Label label2;
        public CheckBox chkMean;
        public Label label3;
        public Button buttonOK;
        public Button buttonCancel;
        public CheckBox chkVariance;
        public CheckBox chkSum;
        public CheckBox chkNnonmissing;
        public CheckBox chkHistogram;
        public CheckBox chkBoxplot;
        public CheckedListBox checkedListBoxOfColumns;
    }
}