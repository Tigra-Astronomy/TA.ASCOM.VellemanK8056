// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2017 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: ServerStatusDisplay.cs  Last modified: 2017-03-07@22:20 by Tim Long

using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;
using TA.VellemanK8056.Server.Properties;

namespace TA.VellemanK8056.Server
    {
    public partial class ServerStatusDisplay : Form
        {
        private IDisposable clientStatusSubscription;

        public ServerStatusDisplay()
            {
            InitializeComponent();
            }

        private void CalibrateCommand_Click(object sender, EventArgs e)
            {
            if (!SharedResources.ConnectionManager.MaybeControllerInstance.Any())
                return;
            //SharedResources.ConnectionManager.MaybeControllerInstance.Single().CalibrateFocuserAsync();
            }

        /// <summary>
        ///     Begins or terminates UI updates depending on the number of online clients.
        /// </summary>
        private void ConfigureUiPropertyNotifications()
            {
            var clientsOnline = SharedResources.ConnectionManager.OnlineClientCount;
            if (clientsOnline > 0)
                SubscribePropertyChangeNotifications();
            else
                UnsubscribePropertyChangeNotifications();
            }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
            {
            clientStatusSubscription?.Dispose();
            UnsubscribePropertyChangeNotifications();
            var clients = SharedResources.ConnectionManager.Clients;
            foreach (var client in clients)
                {
                SharedResources.ConnectionManager.GoOffline(client.ClientId);
                }
            Application.Exit();
            }

        private void frmMain_Load(object sender, EventArgs e)
            {
            var clientStatusObservable = Observable.FromEventPattern<EventHandler<EventArgs>, EventArgs>(
                handler => SharedResources.ConnectionManager.ClientStatusChanged += handler,
                handler => SharedResources.ConnectionManager.ClientStatusChanged -= handler);
            clientStatusSubscription = clientStatusObservable
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(ObserveClientStatusChanged);
            ObserveClientStatusChanged(null); // This sets the initial UI state before any notifications arrive
            }

        private void frmMain_LocationChanged(object sender, EventArgs e)
            {
            Settings.Default.Save();
            }


        private void ObserveClientStatusChanged(EventPattern<EventArgs> eventPattern)
            {
            SetUiButtonState();
            SetUiDeviceConnectedState();
            var clientStatus = SharedResources.ConnectionManager.Clients;
            try
                {
                ClientStatus.BeginUpdate();
                ClientStatus.Items.Clear();
                foreach (var client in clientStatus)
                    {
                    ClientStatus.Items.Add(client);
                    }
                }
            finally
                {
                ClientStatus.EndUpdate();
                }
            registeredClientCount.Text = clientStatus.Count().ToString();
            OnlineClients.Text = clientStatus.Count(p => p.Online).ToString();
            ConfigureUiPropertyNotifications();
            }


        private void SetPaCommand_Click(object sender, EventArgs e)
            {
            if (!SharedResources.ConnectionManager.MaybeControllerInstance.Any())
                return;
            //SharedResources.ConnectionManager.MaybeControllerInstance.Single().SetRotatorPositionAngle(0.0);
            }

        private void SetUiButtonState() {}

        /// <summary>
        ///     Enables each device activity annunciator if there are any clients connected to that
        ///     device.
        /// </summary>
        private void SetUiDeviceConnectedState() {}

        private void SetupCommand_Click(object sender, EventArgs e)
            {
            SharedResources.DoSetupDialog(default(Guid));
            }

        /// <summary>
        ///     Creates subscriptions that observe property change notifications and update the UI as changes occur.
        /// </summary>
        private void SubscribePropertyChangeNotifications()
            {
            if (!SharedResources.ConnectionManager.MaybeControllerInstance.Any())
                return;
            var controller = SharedResources.ConnectionManager.MaybeControllerInstance.Single();
            /*
             * The following pattern can be used to marshal property change events
             * into the UI thread for safe control updates.
             */
            //rotatorPositionSubscription = controller
            //    .GetObservableValueFor(m => m.RotatorPositionAngle)
            //    .ObserveOn(SynchronizationContext.Current)
            //    .Subscribe(angle => RotatorPosition.Text = $"{angle:000.00}°");
            }

        /// <summary>
        ///     Stops observing the controller property change notifications.
        /// </summary>
        private void UnsubscribePropertyChangeNotifications()
            {
            /* Dispose any observable subscriptions like this:
            rotatorPositionSubscription?.Dispose();
            */
            }
        }
    }