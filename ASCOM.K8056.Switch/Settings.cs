// This file is part of the TA.VellemanK8056 project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: Settings.cs  Last modified: 2016-07-31@03:16 by Tim Long

using System.ComponentModel;
using System.Configuration;

namespace ASCOM.K8056.Properties
    {
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    [SettingsProvider(typeof(SettingsProvider))]
    [DeviceId("ASCOM.K8056.Switch", DeviceName = "Velleman K8056 Relay Module")]
    internal sealed partial class Settings
        {
        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
            {
            // Add code to handle the SettingChangingEvent event here.
            }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
            {
            // Add code to handle the SettingsSaving event here.
            }
        }
    }