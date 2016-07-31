// This file is part of the TA.VellemanK8056 project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: Switch.cs  Last modified: 2016-07-31@03:49 by Tim Long

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ASCOM.DeviceInterface;
using ASCOM.K8056.Properties;
using NLog;

namespace ASCOM.K8056
    {
    /// <summary>
    ///     ASCOM Switch Driver.
    /// </summary>
    [Guid("8127CA33-5D0B-429E-870D-D7F74093FB19")]
    [ClassInterface(ClassInterfaceType.None)]
    internal class Switch : ISwitchV2
        {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        private readonly DeviceLayer device;

        public Switch()
            {
#if DEBUG_IN_EXTERNAL_APP
            MessageBox.Show("Attach debugger now");
#endif
            HandleAssemblyResolveEvents();
            device = CompositionRoot.GetDeviceLayer();
            }


        public void SetupDialog()
            {
            var form = new SetupDialog();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
                {
                Settings.Default.Save();
                }
            else
                {
                Settings.Default.Reload();
                }
            }

        public string Action(string ActionName, string ActionParameters)
            {
            return null;
            }

        public void CommandBlind(string Command, bool Raw = false) {}

        public bool CommandBool(string Command, bool Raw = false)
            {
            return false;
            }

        public string CommandString(string Command, bool Raw = false)
            {
            return null;
            }

        public void Dispose() {}

        public string GetSwitchName(short id)
            {
            return null;
            }

        public void SetSwitchName(short id, string name) {}

        public string GetSwitchDescription(short id)
            {
            return null;
            }

        public bool CanWrite(short id)
            {
            return false;
            }

        public bool GetSwitch(short id)
            {
            return false;
            }

        public void SetSwitch(short id, bool state) {}

        public double MaxSwitchValue(short id)
            {
            return 0;
            }

        public double MinSwitchValue(short id)
            {
            return 0;
            }

        public double SwitchStep(short id)
            {
            return 0;
            }

        public double GetSwitchValue(short id)
            {
            return 0;
            }

        public void SetSwitchValue(short id, double value) {}

        public bool Connected { get; set; }

        public string Description { get; }

        public string DriverInfo { get; }

        public string DriverVersion { get; }

        public short InterfaceVersion { get; }

        public string Name { get; }

        public ArrayList SupportedActions { get; }

        public short MaxSwitch { get; }

        /// <summary>
        ///     Disconnects from the device.
        /// </summary>
        private void Disconnect()
            {
            device.Close();
            }

        /// <summary>
        ///     Connects to the device.
        /// </summary>
        /// <exception cref="ASCOM.DriverException">
        ///     Failed to connect. Open apparently succeeded but then the device reported that
        ///     is was offline.
        /// </exception>
        private void Connect()
            {
            if (!device.IsOnline) // Don't try to re-open a port that is already connected.
                device.Open();
            if (!device.IsOnline)
                {
                Log.Error("Connect failed - device reported offline");
                throw new DriverException(
                    "Failed to connect. Open apparently succeeded but then the device reported that is was offline.");
                }
            device.PerformOnConnectTasks();
            }

        /// <summary>
        ///     Installs a custom assembly resolver into the AppDomain so that the driver can find its
        ///     referenced assemblies.
        /// </summary>
        private void HandleAssemblyResolveEvents()
            {
            AppDomain.CurrentDomain.AssemblyResolve += AscomDriverAssemblyResolver.ResolveSupportAssemblies;
            }
        }
    }