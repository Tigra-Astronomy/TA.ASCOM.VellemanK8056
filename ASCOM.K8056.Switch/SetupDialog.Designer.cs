namespace ASCOM.K8056
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
            this.CommPort = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommPort
            // 
            this.CommPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.K8056.Properties.Settings.Default, "PortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CommPort.FormattingEnabled = true;
            this.CommPort.Location = new System.Drawing.Point(13, 51);
            this.CommPort.Name = "CommPort";
            this.CommPort.Size = new System.Drawing.Size(121, 21);
            this.CommPort.TabIndex = 0;
            this.CommPort.Text = global::ASCOM.K8056.Properties.Settings.Default.PortName;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(150, 162);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(69, 162);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // SetupDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 197);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.CommPort);
            this.Name = "SetupDialog";
            this.Text = "SetupDialog";
            this.Load += new System.EventHandler(this.SetupDialog_Load);
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.ComboBox CommPort;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OkButton;
        }
    }