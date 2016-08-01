// This file is part of the TA.VellemanK8056 project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: SetupDialog.cs  Last modified: 2016-08-01@16:40 by Tim Long

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ASCOM.K8056.Properties;
using TA.Ascom.ReactiveCommunications;
using SerialPort = System.IO.Ports.SerialPort;

namespace ASCOM.K8056
    {
    public partial class SetupDialog : Form
        {
        private const string InvalidConfiguration = "(invalid configuration)";

        public SetupDialog()
            {
            InitializeComponent();
            }

        private void SetupDialog_Load(object sender, EventArgs e)
            {
            PopulatePortComboBox();
            PopulateVersionLabel();
            PopulateConnectionStringLabel();
            }

        private void PopulateConnectionStringLabel()
            {
            if (string.IsNullOrEmpty(Settings.Default.ConnectionString))
                {
                ConnectionString.Text = InvalidConfiguration;
                return;
                }
            ConnectionString.Text = Settings.Default.ConnectionString;
            }

        private void PopulateVersionLabel()
            {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();
            var fullName = assemblyName.FullName;
            VersionLabel.Text = fullName;
            }

        private void PopulatePortComboBox()
            {
            var configuredPort = Settings.Default.CommPortName;
            var portNames = SerialPort.GetPortNames();
            var ports = new List<string>(portNames);
            CommPortName.Items.Clear();
            CommPortName.Items.AddRange(portNames);
            // Try to pre-select the existing configuration.
            var configuredIndex = ports.IndexOf(configuredPort);
            if (configuredIndex >= 0)
                {
                CommPortName.SelectedIndex = configuredIndex;
                }
            }

        private void TigraAbout_Click(object sender, EventArgs e)
            {
            NavigateToWeb(Settings.Default.AboutTigra);
            }

        private void NavigateToWeb(string url)
            {
            Process.Start(url ?? "http://tigra-astronomy.com");
            }

        private void AscomAbout_Click(object sender, EventArgs e)
            {
            NavigateToWeb(Settings.Default.AboutAscom);
            }

        private void ReactiveAscomAbout_Click(object sender, EventArgs e)
            {
            NavigateToWeb(Settings.Default.AboutReactiveAscom);
            }

        private void CommPortName_SelectedIndexChanged(object sender, EventArgs e)
            {
            BuildConnectionString();
            }

        private void BuildConnectionString()
            {
            if (!SerialPort.GetPortNames().Contains(CommPortName.Text))
                {
                ConnectionString.Text = InvalidConfiguration;
                return;
                }
            var commPortName = CommPortName.Text;
            var endpoint = new SerialDeviceEndpoint(
                commPortName,
                Settings.Default.CommDataRate,
                Settings.Default.CommParity,
                Settings.Default.CommDataBits,
                Settings.Default.CommStopBits,
                Settings.Default.CommDtrActive,
                Settings.Default.CommRtsActive);
            var builder = new StringBuilder(endpoint.ToString());
            // Due to a limitation in ASCOM.ReactiveCommunications, we have to add the DTR and RTS flags manually
            builder.Append(Settings.Default.CommDtrActive ? ",DTR" : ",NoDTR");
            builder.Append(Settings.Default.CommRtsActive ? ",RTS" : ",NoRTS");
            var connectionString = builder.ToString();
            Settings.Default.ConnectionString = connectionString;
            ConnectionString.Text = connectionString;
            }
        }
    }