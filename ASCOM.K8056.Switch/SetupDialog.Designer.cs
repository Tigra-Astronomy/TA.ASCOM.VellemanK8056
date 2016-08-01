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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.OkCommand = new System.Windows.Forms.Button();
            this.AscomAbout = new System.Windows.Forms.PictureBox();
            this.ReactiveAscomAbout = new System.Windows.Forms.PictureBox();
            this.TigraAbout = new System.Windows.Forms.PictureBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CommPortName = new System.Windows.Forms.ComboBox();
            this.ConnectionString = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AscomAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReactiveAscomAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TigraAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // CancelCommand
            // 
            this.CancelCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCommand.Location = new System.Drawing.Point(141, 86);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(75, 23);
            this.CancelCommand.TabIndex = 2;
            this.CancelCommand.Text = "Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            // 
            // OkCommand
            // 
            this.OkCommand.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkCommand.Location = new System.Drawing.Point(60, 86);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new System.Drawing.Size(75, 23);
            this.OkCommand.TabIndex = 3;
            this.OkCommand.Text = "OK";
            this.OkCommand.UseVisualStyleBackColor = true;
            // 
            // AscomAbout
            // 
            this.AscomAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AscomAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AscomAbout.Image = ((System.Drawing.Image)(resources.GetObject("AscomAbout.Image")));
            this.AscomAbout.Location = new System.Drawing.Point(373, 12);
            this.AscomAbout.Name = "AscomAbout";
            this.AscomAbout.Size = new System.Drawing.Size(100, 120);
            this.AscomAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AscomAbout.TabIndex = 4;
            this.AscomAbout.TabStop = false;
            this.AscomAbout.Click += new System.EventHandler(this.AscomAbout_Click);
            // 
            // ReactiveAscomAbout
            // 
            this.ReactiveAscomAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReactiveAscomAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReactiveAscomAbout.Image = ((System.Drawing.Image)(resources.GetObject("ReactiveAscomAbout.Image")));
            this.ReactiveAscomAbout.Location = new System.Drawing.Point(479, 12);
            this.ReactiveAscomAbout.Name = "ReactiveAscomAbout";
            this.ReactiveAscomAbout.Size = new System.Drawing.Size(117, 120);
            this.ReactiveAscomAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ReactiveAscomAbout.TabIndex = 4;
            this.ReactiveAscomAbout.TabStop = false;
            this.ReactiveAscomAbout.Click += new System.EventHandler(this.ReactiveAscomAbout_Click);
            // 
            // TigraAbout
            // 
            this.TigraAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TigraAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TigraAbout.Image = ((System.Drawing.Image)(resources.GetObject("TigraAbout.Image")));
            this.TigraAbout.Location = new System.Drawing.Point(267, 12);
            this.TigraAbout.Name = "TigraAbout";
            this.TigraAbout.Size = new System.Drawing.Size(100, 120);
            this.TigraAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TigraAbout.TabIndex = 4;
            this.TigraAbout.TabStop = false;
            this.TigraAbout.Click += new System.EventHandler(this.TigraAbout_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Enabled = false;
            this.VersionLabel.Location = new System.Drawing.Point(12, 142);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(584, 21);
            this.VersionLabel.TabIndex = 5;
            this.VersionLabel.Text = "(unknown version)";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommPortName
            // 
            this.CommPortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.K8056.Properties.Settings.Default, "CommPortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CommPortName.FormattingEnabled = true;
            this.CommPortName.Location = new System.Drawing.Point(44, 21);
            this.CommPortName.Name = "CommPortName";
            this.CommPortName.Size = new System.Drawing.Size(217, 21);
            this.CommPortName.TabIndex = 0;
            this.CommPortName.Text = global::ASCOM.K8056.Properties.Settings.Default.CommPortName;
            this.CommPortName.SelectedIndexChanged += new System.EventHandler(this.CommPortName_SelectedIndexChanged);
            // 
            // ConnectionString
            // 
            this.ConnectionString.AutoSize = true;
            this.ConnectionString.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionString.Location = new System.Drawing.Point(41, 45);
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(94, 13);
            this.ConnectionString.TabIndex = 6;
            this.ConnectionString.Text = "(connection string)";
            // 
            // SetupDialog
            // 
            this.AcceptButton = this.OkCommand;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.CancelCommand;
            this.ClientSize = new System.Drawing.Size(608, 175);
            this.ControlBox = false;
            this.Controls.Add(this.ConnectionString);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.TigraAbout);
            this.Controls.Add(this.ReactiveAscomAbout);
            this.Controls.Add(this.AscomAbout);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommPortName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(624, 39);
            this.Name = "SetupDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SetupDialog";
            this.Load += new System.EventHandler(this.SetupDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AscomAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReactiveAscomAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TigraAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.ComboBox CommPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelCommand;
        private System.Windows.Forms.Button OkCommand;
        private System.Windows.Forms.PictureBox AscomAbout;
        private System.Windows.Forms.PictureBox ReactiveAscomAbout;
        private System.Windows.Forms.PictureBox TigraAbout;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label ConnectionString;
        }
    }