﻿namespace ASCOM.K8056
    {
    partial class SetupDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.OkCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comm Port";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.K8056.Properties.Settings.Default, "CommPortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = global::ASCOM.K8056.Properties.Settings.Default.CommPortName;
            // 
            // CancelCommand
            // 
            this.CancelCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCommand.Location = new System.Drawing.Point(489, 351);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(75, 23);
            this.CancelCommand.TabIndex = 2;
            this.CancelCommand.Text = "Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            // 
            // OkCommand
            // 
            this.OkCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkCommand.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkCommand.Location = new System.Drawing.Point(408, 351);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new System.Drawing.Size(75, 23);
            this.OkCommand.TabIndex = 3;
            this.OkCommand.Text = "OK";
            this.OkCommand.UseVisualStyleBackColor = true;
            // 
            // SetupDialog
            // 
            this.AcceptButton = this.OkCommand;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 386);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "SetupDialog";
            this.Text = "SetupDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelCommand;
        private System.Windows.Forms.Button OkCommand;
        }
    }