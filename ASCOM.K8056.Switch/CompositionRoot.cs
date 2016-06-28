// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: CompositionRoot.cs  Last modified: 2016-06-27@19:42 by Tim Long

using System;
using ASCOM.K8056.Properties;
using NLog;
using TA.Ascom.ReactiveCommunications;

namespace ASCOM.K8056
    {
    internal static class CompositionRoot
        {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static ICommunicationChannel GetChannelFromEndpoint(DeviceEndpoint endpoint)
            {
            if (endpoint is SerialDeviceEndpoint)
                return new SerialCommunicationChannel(endpoint);
            throw new NotSupportedException("The requested communications method is not supported by the device");
            }

        public static DeviceLayer GetDeviceLayer()
            {
            Log.Info("Composing device layer from connection string: {0}", Settings.Default.ConnectionString);
            var endpoint = DeviceEndpoint.FromConnectionString(Settings.Default.ConnectionString);
            var channel = GetChannelFromEndpoint(endpoint);
            var device = new DeviceLayer(channel);
            return device;
            }
        }
    }