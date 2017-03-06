// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: SetupDialog.cs  Last modified: 2016-06-29@05:26 by Tim Long

using System;
using System.IO.Ports;
using System.Windows.Forms;
using ASCOM.K8056.Properties;

namespace ASCOM.K8056
    {
    public partial class SetupDialog : Form
        {
        public SetupDialog()
            {
            InitializeComponent();
            }

        private void SetupDialog_Load(object sender, EventArgs e)
            {
            var previouslySelectedPort = Settings.Default.PortName;
            var ports = SerialPort.GetPortNames();
            CommPort.Items.Clear();
            CommPort.Items.AddRange(ports);
            if (CommPort.Items.Contains(previouslySelectedPort))
                {
                var selectedItem = CommPort.Items.IndexOf(previouslySelectedPort);
                CommPort.SelectedIndex = selectedItem;
                }
            }
        }
    }