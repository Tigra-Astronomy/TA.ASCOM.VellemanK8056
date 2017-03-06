// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: Program.cs  Last modified: 2016-07-27@16:08 by Tim Long

using System;
using ASCOM.DriverAccess;

namespace Test.Console
    {
    internal class Program
        {
        private static void Main(string[] args)
            {
            var driverId = "ASCOM.K8056.Switch";
            var driverType = Type.GetTypeFromProgID(driverId);
            var driver = new Switch(driverId);
            driver.SetupDialog();
            }
        }
    }