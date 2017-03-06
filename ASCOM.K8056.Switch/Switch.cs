// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: Switch.cs  Last modified: 2016-07-31@00:15 by Tim Long

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using ASCOM.DeviceInterface;
using ASCOM.K8056.Properties;
using JetBrains.Annotations;
using NLog;
#if DEBUG_IN_EXTERNAL_APP
using System.Windows.Forms;

#endif

namespace ASCOM.K8056
    {
    [ProgId(DeviceId)]
    [Guid("A864F06E-B5CC-4566-BCBF-59FAC56E6DDB")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [UsedImplicitly]
    public class Switch : ISwitchV2, IDisposable
        {
        internal const string DeviceName = "Velleman K8056";

        /// <summary>
        ///     Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
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
            var dialog = new SetupDialog();
            var result = dialog.ShowDialog();
            switch (result)
                {
                    case DialogResult.OK:
                        Settings.Default.Save();
                        break;
                    default:
                        Settings.Default.Reload();
                        break;
                }
            dialog.Dispose();
            }

        public string Action(string ActionName, string ActionParameters)
            {
            throw new System.NotImplementedException();
            }

        public void CommandBlind(string Command, bool Raw = false)
            {
            throw new System.NotImplementedException();
            }

        public bool CommandBool(string Command, bool Raw = false)
            {
            throw new System.NotImplementedException();
            }

        public string CommandString(string Command, bool Raw = false)
            {
            throw new System.NotImplementedException();
            }


        public string GetSwitchName(short id) => Settings.Default.SwitchNames[id] ?? $"Relay {id}";

        public void SetSwitchName(short id, string name)
            {
            Settings.Default.SwitchNames[id] = string.IsNullOrWhiteSpace(name) ? $"Relay {id}" : name;
            Settings.Default.Save();
            }

        public string GetSwitchDescription(short id) => $"Relay {id}";

        public bool CanWrite(short id) => true;

        public bool GetSwitch(short id) => shadow[id];

        public void SetSwitch(short id, bool state)
            {
            var relay = (ushort) id;
            if (state) device.SetRelay(relay);
            else device.ClearRelay(relay);
            shadow = shadow.WithBitSetTo(id, state);
            }

        /// <summary>
        ///     Returns the maximum value for this switch device.
        /// </summary>
        public double MaxSwitchValue(short id) => 1.0;

        /// <summary>
        ///     Returns the minimum value for this switch device.
        /// </summary>
        public double MinSwitchValue(short id) => 0.0;

        /// <summary>
        ///     Returns the step size that this device supports (the difference between successive values of the device).
        /// </summary>
        public double SwitchStep(short id) => 1.0;

        /// <summary>
        ///     Returns the value for switch device id as a double
        /// </summary>
        public double GetSwitchValue(short id) => shadow[id] ? 1.0 : 0.0;

        /// <summary>
        ///     Set the value for this device as a double.
        /// </summary>
        public void SetSwitchValue(short id, double value)
            {
            SetSwitch(id, value > 0.0);
            }

        /// <summary>
        ///     Gets or sets the connection state.
        /// </summary>
        /// <value><c>true</c> if connected; otherwise, <c>false</c>.</value>
        public bool Connected
            {
            get { return false; }
            set
                {
                if (value)
                    Connect();
                else
                    Disconnect();
                }
            }

        /// <summary>
        ///     Returns a description of the device, such as manufacturer and modelnumber. Any ASCII characters may be used.
        /// </summary>
        public string Description => "Velleman K8056 Relay Card";

        /// <summary>
        ///     Descriptive and version information about this ASCOM driver.
        /// </summary>
        public string DriverInfo => @"ASCOM Switch driver for Velleman K8056 8-port relay card
Developed by Tigra Astronomy
in collaboration with Oxford University Department of Astrophysics.
Project page: http://tigra-astronomy.com/oss/k8056-switch-driver
Licensed under the MIT License: http://tigra.mit-license.org/";

        /// <summary>
        ///     A string containing only the major and minor version of the driver.
        /// </summary>
        public string DriverVersion => "0.0";

        /// <summary>
        ///     The ASCOM interface version number that this device supports.
        /// </summary>
        public short InterfaceVersion => 2;

        /// <summary>
        ///     The short name of the driver, for display purposes
        /// </summary>
        public string Name => DeviceName;

        /// <summary>
        ///     Returns the list of action names supported by this driver (currently none supported).
        /// </summary>
        public ArrayList SupportedActions => new ArrayList();

        public short MaxSwitch => 8;

        private void CreateSwitchNames()
            {
            Settings.Default.SwitchNames = new StringCollection();
            for (var i = 0; i < MaxSwitch; i++)
                {
                Settings.Default.SwitchNames.Add($"Relay {i}");
                }
            }

        /// <summary>
        ///     Installs a custom assembly resolver into the AppDomain so that the driver can find its
        ///     referenced assemblies.
        /// </summary>
        private void HandleAssemblyResolveEvents()
            {
            AppDomain.CurrentDomain.AssemblyResolve += AscomDriverAssemblyResolver.ResolveSupportAssemblies;
            }

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

        #region IDisposable Pattern
        // The IDisposable pattern, as described at
        // http://www.codeproject.com/Articles/15360/Implementing-IDisposable-and-the-Dispose-Pattern-P


        /// <summary>
        ///     Finalizes this instance (called prior to garbage collection by the CLR)
        /// </summary>
        ~Switch()
            {
            Dispose(false);
            }

        public void Dispose()
            {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        private bool disposed;
        private readonly DeviceLayer device;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private Octet shadow = Octet.Zero;
        internal const string DeviceId = "ASCOM.K8056.Switch";

        protected virtual void Dispose(bool fromUserCode)
            {
            if (!disposed)
                {
                if (fromUserCode)
                    {
                    // ToDo - Dispose managed resources (call Dispose() on any owned objects).
                    // Do not dispose of any objects that may be referenced elsewhere.
                    }

                // ToDo - Release unmanaged resources here, if necessary.
                }
            disposed = true;

            // ToDo: Call the base class's Dispose(Boolean) method, if available.
            // base.Dispose(fromUserCode);
            }
        #endregion
        }
    }