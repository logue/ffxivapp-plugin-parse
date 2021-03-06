﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Settings.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Parse.Properties {
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using System.Xml.Linq;

    using FFXIVAPP.Common.Helpers;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using NLog;

    using ColorConverter = System.Windows.Media.ColorConverter;
    using FontFamily = System.Drawing.FontFamily;

    internal class Settings : ApplicationSettingsBase, INotifyPropertyChanged {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static Settings _default;

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static Settings Default {
            get {
                return _default ?? (_default = (Settings) Synchronized(new Settings()));
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Purple")]
        public string BLMProgressBarForeground {
            get {
                return (string) this["BLMProgressBarForeground"];
            }

            set {
                this["BLMProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GreenYellow")]
        public string BRDProgressBarForeground {
            get {
                return (string) this["BRDProgressBarForeground"];
            }

            set {
                this["BRDProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("FF00FF00")]
        public string DefaultProgressBarForeground {
            get {
                return (string) this["DefaultProgressBarForeground"];
            }

            set {
                this["DefaultProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0")]
        public string DPSVisibility {
            get {
                return (string) this["DPSVisibility"];
            }

            set {
                this["DPSVisibility"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0</string>
  <string>50</string>
  <string>100</string>
  <string>150</string>
  <string>200</string>
  <string>250</string>
  <string>300</string>
</ArrayOfString>")]
        public StringCollection DPSVisibilityList {
            get {
                return (StringCollection) this["DPSVisibilityList"];
            }

            set {
                this["DPSVisibilityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Combined")]
        public string DPSWidgetDisplayProperty {
            get {
                return (string) this["DPSWidgetDisplayProperty"];
            }

            set {
                this["DPSWidgetDisplayProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Combined</string>
  <string>Individual</string>
</ArrayOfString>")]
        public StringCollection DPSWidgetDisplayPropertyList {
            get {
                return (StringCollection) this["DPSWidgetDisplayPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int DPSWidgetHeight {
            get {
                return (int) this["DPSWidgetHeight"];
            }

            set {
                this["DPSWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int DPSWidgetLeft {
            get {
                return (int) this["DPSWidgetLeft"];
            }

            set {
                this["DPSWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Descending")]
        public string DPSWidgetSortDirection {
            get {
                return (string) this["DPSWidgetSortDirection"];
            }

            set {
                this["DPSWidgetSortDirection"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Ascending</string>
  <string>Descending</string>
</ArrayOfString>")]
        public StringCollection DPSWidgetSortDirectionList {
            get {
                return (StringCollection) this["DPSWidgetSortDirectionList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("CombinedDPS")]
        public string DPSWidgetSortProperty {
            get {
                return (string) this["DPSWidgetSortProperty"];
            }

            set {
                this["DPSWidgetSortProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Name</string>
  <string>Job</string>
  <string>DPS</string>
  <string>CombinedDPS</string>
  <string>TotalOverallDamage</string>
  <string>CombinedTotalOverallDamage</string>
  <string>PercentOfOverallDamage</string>
</ArrayOfString>")]
        public StringCollection DPSWidgetSortPropertyList {
            get {
                return (StringCollection) this["DPSWidgetSortPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int DPSWidgetTop {
            get {
                return (int) this["DPSWidgetTop"];
            }

            set {
                this["DPSWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string DPSWidgetUIScale {
            get {
                return (string) this["DPSWidgetUIScale"];
            }

            set {
                this["DPSWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection DPSWidgetUIScaleList {
            get {
                return (StringCollection) this["DPSWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int DPSWidgetWidth {
            get {
                return (int) this["DPSWidgetWidth"];
            }

            set {
                this["DPSWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("DarkSlateBlue")]
        public string DRGProgressBarForeground {
            get {
                return (string) this["DRGProgressBarForeground"];
            }

            set {
                this["DRGProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0")]
        public string DTPSVisibility {
            get {
                return (string) this["DTPSVisibility"];
            }

            set {
                this["DTPSVisibility"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0</string>
  <string>50</string>
  <string>100</string>
  <string>150</string>
  <string>200</string>
  <string>250</string>
  <string>300</string>
</ArrayOfString>")]
        public StringCollection DTPSVisibilityList {
            get {
                return (StringCollection) this["DTPSVisibilityList"];
            }

            set {
                this["DTPSVisibilityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Combined")]
        public string DTPSWidgetDisplayProperty {
            get {
                return (string) this["DTPSWidgetDisplayProperty"];
            }

            set {
                this["DTPSWidgetDisplayProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Combined</string>
  <string>Individual</string>
</ArrayOfString>")]
        public StringCollection DTPSWidgetDisplayPropertyList {
            get {
                return (StringCollection) this["DTPSWidgetDisplayPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int DTPSWidgetHeight {
            get {
                return (int) this["DTPSWidgetHeight"];
            }

            set {
                this["DTPSWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int DTPSWidgetLeft {
            get {
                return (int) this["DTPSWidgetLeft"];
            }

            set {
                this["DTPSWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Descending")]
        public string DTPSWidgetSortDirection {
            get {
                return (string) this["DTPSWidgetSortDirection"];
            }

            set {
                this["DTPSWidgetSortDirection"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Ascending</string>
  <string>Descending</string>
</ArrayOfString>")]
        public StringCollection DTPSWidgetSortDirectionList {
            get {
                return (StringCollection) this["DTPSWidgetSortDirectionList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("CombinedDTPS")]
        public string DTPSWidgetSortProperty {
            get {
                return (string) this["DTPSWidgetSortProperty"];
            }

            set {
                this["DTPSWidgetSortProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Name</string>
  <string>Job</string>
  <string>DTPS</string>
  <string>CombinedDTPS</string>
  <string>TotalOverallDamageTaken</string>
  <string>CombinedTotalOverallDamageTaken</string>
  <string>PercentOfOverallDamageTaken</string>
</ArrayOfString>")]
        public StringCollection DTPSWidgetSortPropertyList {
            get {
                return (StringCollection) this["DTPSWidgetSortPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("200")]
        public int DTPSWidgetTop {
            get {
                return (int) this["DTPSWidgetTop"];
            }

            set {
                this["DTPSWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string DTPSWidgetUIScale {
            get {
                return (string) this["DTPSWidgetUIScale"];
            }

            set {
                this["DTPSWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection DTPSWidgetUIScaleList {
            get {
                return (StringCollection) this["DTPSWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int DTPSWidgetWidth {
            get {
                return (int) this["DTPSWidgetWidth"];
            }

            set {
                this["DTPSWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool EnableStoreHistoryReset {
            get {
                return (bool) this["EnableStoreHistoryReset"];
            }

            set {
                this["EnableStoreHistoryReset"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0")]
        public string HPSVisibility {
            get {
                return (string) this["HPSVisibility"];
            }

            set {
                this["HPSVisibility"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0</string>
  <string>50</string>
  <string>100</string>
  <string>150</string>
  <string>200</string>
  <string>250</string>
  <string>300</string>
</ArrayOfString>")]
        public StringCollection HPSVisibilityList {
            get {
                return (StringCollection) this["HPSVisibilityList"];
            }

            set {
                this["HPSVisibilityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Combined")]
        public string HPSWidgetDisplayProperty {
            get {
                return (string) this["HPSWidgetDisplayProperty"];
            }

            set {
                this["HPSWidgetDisplayProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Combined</string>
  <string>Individual</string>
</ArrayOfString>")]
        public StringCollection HPSWidgetDisplayPropertyList {
            get {
                return (StringCollection) this["HPSWidgetDisplayPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int HPSWidgetHeight {
            get {
                return (int) this["HPSWidgetHeight"];
            }

            set {
                this["HPSWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int HPSWidgetLeft {
            get {
                return (int) this["HPSWidgetLeft"];
            }

            set {
                this["HPSWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Descending")]
        public string HPSWidgetSortDirection {
            get {
                return (string) this["HPSWidgetSortDirection"];
            }

            set {
                this["HPSWidgetSortDirection"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Ascending</string>
  <string>Descending</string>
</ArrayOfString>")]
        public StringCollection HPSWidgetSortDirectionList {
            get {
                return (StringCollection) this["HPSWidgetSortDirectionList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("CombinedHPS")]
        public string HPSWidgetSortProperty {
            get {
                return (string) this["HPSWidgetSortProperty"];
            }

            set {
                this["HPSWidgetSortProperty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Name</string>
  <string>Job</string>
  <string>HPS</string>
  <string>CombinedHPS</string>
  <string>TotalOverallHealing</string>
  <string>CombinedTotalOverallHealing</string>
  <string>PercentOfOverallHealing</string>
</ArrayOfString>")]
        public StringCollection HPSWidgetSortPropertyList {
            get {
                return (StringCollection) this["HPSWidgetSortPropertyList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("300")]
        public int HPSWidgetTop {
            get {
                return (int) this["HPSWidgetTop"];
            }

            set {
                this["HPSWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string HPSWidgetUIScale {
            get {
                return (string) this["HPSWidgetUIScale"];
            }

            set {
                this["HPSWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection HPSWidgetUIScaleList {
            get {
                return (StringCollection) this["HPSWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int HPSWidgetWidth {
            get {
                return (int) this["HPSWidgetWidth"];
            }

            set {
                this["HPSWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool IgnoreLimitBreaks {
            get {
                return (bool) this["IgnoreLimitBreaks"];
            }

            set {
                this["IgnoreLimitBreaks"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GoldenRod")]
        public string MNKProgressBarForeground {
            get {
                return (string) this["MNKProgressBarForeground"];
            }

            set {
                this["MNKProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ParseAdvanced {
            get {
                return (bool) this["ParseAdvanced"];
            }

            set {
                this["ParseAdvanced"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ParseAlliance {
            get {
                return (bool) this["ParseAlliance"];
            }

            set {
                this["ParseAlliance"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ParseOther {
            get {
                return (bool) this["ParseOther"];
            }

            set {
                this["ParseOther"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ParseParty {
            get {
                return (bool) this["ParseParty"];
            }

            set {
                this["ParseParty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ParseYou {
            get {
                return (bool) this["ParseYou"];
            }

            set {
                this["ParseYou"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("SkyBlue")]
        public string PLDProgressBarForeground {
            get {
                return (string) this["PLDProgressBarForeground"];
            }

            set {
                this["PLDProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("MediumPurple")]
        public string SCHProgressBarForeground {
            get {
                return (string) this["SCHProgressBarForeground"];
            }

            set {
                this["SCHProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedCriticalDamage {
            get {
                return (bool) this["ShowBasicCombinedCriticalDamage"];
            }

            set {
                this["ShowBasicCombinedCriticalDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedCriticalDamageTaken {
            get {
                return (bool) this["ShowBasicCombinedCriticalDamageTaken"];
            }

            set {
                this["ShowBasicCombinedCriticalDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedCriticalHealing {
            get {
                return (bool) this["ShowBasicCombinedCriticalHealing"];
            }

            set {
                this["ShowBasicCombinedCriticalHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageBlock {
            get {
                return (bool) this["ShowBasicCombinedDamageBlock"];
            }

            set {
                this["ShowBasicCombinedDamageBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageBlockMod {
            get {
                return (bool) this["ShowBasicCombinedDamageBlockMod"];
            }

            set {
                this["ShowBasicCombinedDamageBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageBlockModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageBlockModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageBlockPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageBlockPercent"];
            }

            set {
                this["ShowBasicCombinedDamageBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCounter {
            get {
                return (bool) this["ShowBasicCombinedDamageCounter"];
            }

            set {
                this["ShowBasicCombinedDamageCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCounterMod {
            get {
                return (bool) this["ShowBasicCombinedDamageCounterMod"];
            }

            set {
                this["ShowBasicCombinedDamageCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCounterModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageCounterModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCounterPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageCounterPercent"];
            }

            set {
                this["ShowBasicCombinedDamageCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageCritAverage"];
            }

            set {
                this["ShowBasicCombinedDamageCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritHigh {
            get {
                return (bool) this["ShowBasicCombinedDamageCritHigh"];
            }

            set {
                this["ShowBasicCombinedDamageCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritHit {
            get {
                return (bool) this["ShowBasicCombinedDamageCritHit"];
            }

            set {
                this["ShowBasicCombinedDamageCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritLow {
            get {
                return (bool) this["ShowBasicCombinedDamageCritLow"];
            }

            set {
                this["ShowBasicCombinedDamageCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritMod {
            get {
                return (bool) this["ShowBasicCombinedDamageCritMod"];
            }

            set {
                this["ShowBasicCombinedDamageCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageCritModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageCritPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageCritPercent"];
            }

            set {
                this["ShowBasicCombinedDamageCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageEvade {
            get {
                return (bool) this["ShowBasicCombinedDamageEvade"];
            }

            set {
                this["ShowBasicCombinedDamageEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageEvadeMod {
            get {
                return (bool) this["ShowBasicCombinedDamageEvadeMod"];
            }

            set {
                this["ShowBasicCombinedDamageEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageEvadeModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageEvadeModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageEvadePercent {
            get {
                return (bool) this["ShowBasicCombinedDamageEvadePercent"];
            }

            set {
                this["ShowBasicCombinedDamageEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageParry {
            get {
                return (bool) this["ShowBasicCombinedDamageParry"];
            }

            set {
                this["ShowBasicCombinedDamageParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageParryMod {
            get {
                return (bool) this["ShowBasicCombinedDamageParryMod"];
            }

            set {
                this["ShowBasicCombinedDamageParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageParryModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageParryModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageParryPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageParryPercent"];
            }

            set {
                this["ShowBasicCombinedDamageParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegAccuracy {
            get {
                return (bool) this["ShowBasicCombinedDamageRegAccuracy"];
            }

            set {
                this["ShowBasicCombinedDamageRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageRegAverage"];
            }

            set {
                this["ShowBasicCombinedDamageRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegHigh {
            get {
                return (bool) this["ShowBasicCombinedDamageRegHigh"];
            }

            set {
                this["ShowBasicCombinedDamageRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegHit {
            get {
                return (bool) this["ShowBasicCombinedDamageRegHit"];
            }

            set {
                this["ShowBasicCombinedDamageRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegLow {
            get {
                return (bool) this["ShowBasicCombinedDamageRegLow"];
            }

            set {
                this["ShowBasicCombinedDamageRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegMiss {
            get {
                return (bool) this["ShowBasicCombinedDamageRegMiss"];
            }

            set {
                this["ShowBasicCombinedDamageRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegMod {
            get {
                return (bool) this["ShowBasicCombinedDamageRegMod"];
            }

            set {
                this["ShowBasicCombinedDamageRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageRegModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageRegModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageResist {
            get {
                return (bool) this["ShowBasicCombinedDamageResist"];
            }

            set {
                this["ShowBasicCombinedDamageResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageResistMod {
            get {
                return (bool) this["ShowBasicCombinedDamageResistMod"];
            }

            set {
                this["ShowBasicCombinedDamageResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageResistModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageResistModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageResistPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageResistPercent"];
            }

            set {
                this["ShowBasicCombinedDamageResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenBlock {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenBlock"];
            }

            set {
                this["ShowBasicCombinedDamageTakenBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenBlockMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenBlockMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenBlockModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenBlockModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenBlockPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenBlockPercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCounter {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCounter"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCounterMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCounterMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCounterModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCounterModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCounterPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCounterPercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritHigh {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritHigh"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritHit {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritHit"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritLow {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritLow"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenCritPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenCritPercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenEvade {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenEvade"];
            }

            set {
                this["ShowBasicCombinedDamageTakenEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenEvadeMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenEvadeMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenEvadeModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenEvadeModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenEvadePercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenEvadePercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenParry {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenParry"];
            }

            set {
                this["ShowBasicCombinedDamageTakenParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenParryMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenParryMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenParryModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenParryModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenParryPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenParryPercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegAccuracy {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegAccuracy"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegHigh {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegHigh"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegHit {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegHit"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegLow {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegLow"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegMiss {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegMiss"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenRegModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenRegModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenResist {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenResist"];
            }

            set {
                this["ShowBasicCombinedDamageTakenResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenResistMod {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenResistMod"];
            }

            set {
                this["ShowBasicCombinedDamageTakenResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenResistModAverage {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenResistModAverage"];
            }

            set {
                this["ShowBasicCombinedDamageTakenResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDamageTakenResistPercent {
            get {
                return (bool) this["ShowBasicCombinedDamageTakenResistPercent"];
            }

            set {
                this["ShowBasicCombinedDamageTakenResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowBasicCombinedDPS {
            get {
                return (bool) this["ShowBasicCombinedDPS"];
            }

            set {
                this["ShowBasicCombinedDPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedDTPS {
            get {
                return (bool) this["ShowBasicCombinedDTPS"];
            }

            set {
                this["ShowBasicCombinedDTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritAverage {
            get {
                return (bool) this["ShowBasicCombinedHealingCritAverage"];
            }

            set {
                this["ShowBasicCombinedHealingCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritHigh {
            get {
                return (bool) this["ShowBasicCombinedHealingCritHigh"];
            }

            set {
                this["ShowBasicCombinedHealingCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritHit {
            get {
                return (bool) this["ShowBasicCombinedHealingCritHit"];
            }

            set {
                this["ShowBasicCombinedHealingCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritLow {
            get {
                return (bool) this["ShowBasicCombinedHealingCritLow"];
            }

            set {
                this["ShowBasicCombinedHealingCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritMod {
            get {
                return (bool) this["ShowBasicCombinedHealingCritMod"];
            }

            set {
                this["ShowBasicCombinedHealingCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritModAverage {
            get {
                return (bool) this["ShowBasicCombinedHealingCritModAverage"];
            }

            set {
                this["ShowBasicCombinedHealingCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingCritPercent {
            get {
                return (bool) this["ShowBasicCombinedHealingCritPercent"];
            }

            set {
                this["ShowBasicCombinedHealingCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegAverage {
            get {
                return (bool) this["ShowBasicCombinedHealingRegAverage"];
            }

            set {
                this["ShowBasicCombinedHealingRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegHigh {
            get {
                return (bool) this["ShowBasicCombinedHealingRegHigh"];
            }

            set {
                this["ShowBasicCombinedHealingRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegHit {
            get {
                return (bool) this["ShowBasicCombinedHealingRegHit"];
            }

            set {
                this["ShowBasicCombinedHealingRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegLow {
            get {
                return (bool) this["ShowBasicCombinedHealingRegLow"];
            }

            set {
                this["ShowBasicCombinedHealingRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegMod {
            get {
                return (bool) this["ShowBasicCombinedHealingRegMod"];
            }

            set {
                this["ShowBasicCombinedHealingRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHealingRegModAverage {
            get {
                return (bool) this["ShowBasicCombinedHealingRegModAverage"];
            }

            set {
                this["ShowBasicCombinedHealingRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedHPS {
            get {
                return (bool) this["ShowBasicCombinedHPS"];
            }

            set {
                this["ShowBasicCombinedHPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedRegularDamage {
            get {
                return (bool) this["ShowBasicCombinedRegularDamage"];
            }

            set {
                this["ShowBasicCombinedRegularDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedRegularDamageTaken {
            get {
                return (bool) this["ShowBasicCombinedRegularDamageTaken"];
            }

            set {
                this["ShowBasicCombinedRegularDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedRegularHealing {
            get {
                return (bool) this["ShowBasicCombinedRegularHealing"];
            }

            set {
                this["ShowBasicCombinedRegularHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedTotalDamageActionsUsed {
            get {
                return (bool) this["ShowBasicCombinedTotalDamageActionsUsed"];
            }

            set {
                this["ShowBasicCombinedTotalDamageActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedTotalDamageTakenActionsUsed {
            get {
                return (bool) this["ShowBasicCombinedTotalDamageTakenActionsUsed"];
            }

            set {
                this["ShowBasicCombinedTotalDamageTakenActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedTotalHealingActionsUsed {
            get {
                return (bool) this["ShowBasicCombinedTotalHealingActionsUsed"];
            }

            set {
                this["ShowBasicCombinedTotalHealingActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowBasicCombinedTotalOverallDamage {
            get {
                return (bool) this["ShowBasicCombinedTotalOverallDamage"];
            }

            set {
                this["ShowBasicCombinedTotalOverallDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedTotalOverallDamageTaken {
            get {
                return (bool) this["ShowBasicCombinedTotalOverallDamageTaken"];
            }

            set {
                this["ShowBasicCombinedTotalOverallDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCombinedTotalOverallHealing {
            get {
                return (bool) this["ShowBasicCombinedTotalOverallHealing"];
            }

            set {
                this["ShowBasicCombinedTotalOverallHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalDamage {
            get {
                return (bool) this["ShowBasicCriticalDamage"];
            }

            set {
                this["ShowBasicCriticalDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalDamageOverTime {
            get {
                return (bool) this["ShowBasicCriticalDamageOverTime"];
            }

            set {
                this["ShowBasicCriticalDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalDamageTaken {
            get {
                return (bool) this["ShowBasicCriticalDamageTaken"];
            }

            set {
                this["ShowBasicCriticalDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicCriticalDamageTakenOverTime"];
            }

            set {
                this["ShowBasicCriticalDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalHealing {
            get {
                return (bool) this["ShowBasicCriticalHealing"];
            }

            set {
                this["ShowBasicCriticalHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalHealingMitigated {
            get {
                return (bool) this["ShowBasicCriticalHealingMitigated"];
            }

            set {
                this["ShowBasicCriticalHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalHealingOverHealing {
            get {
                return (bool) this["ShowBasicCriticalHealingOverHealing"];
            }

            set {
                this["ShowBasicCriticalHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicCriticalHealingOverTime {
            get {
                return (bool) this["ShowBasicCriticalHealingOverTime"];
            }

            set {
                this["ShowBasicCriticalHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageBlock {
            get {
                return (bool) this["ShowBasicDamageBlock"];
            }

            set {
                this["ShowBasicDamageBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageBlockMod {
            get {
                return (bool) this["ShowBasicDamageBlockMod"];
            }

            set {
                this["ShowBasicDamageBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageBlockModAverage {
            get {
                return (bool) this["ShowBasicDamageBlockModAverage"];
            }

            set {
                this["ShowBasicDamageBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageBlockPercent {
            get {
                return (bool) this["ShowBasicDamageBlockPercent"];
            }

            set {
                this["ShowBasicDamageBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCounter {
            get {
                return (bool) this["ShowBasicDamageCounter"];
            }

            set {
                this["ShowBasicDamageCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCounterMod {
            get {
                return (bool) this["ShowBasicDamageCounterMod"];
            }

            set {
                this["ShowBasicDamageCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCounterModAverage {
            get {
                return (bool) this["ShowBasicDamageCounterModAverage"];
            }

            set {
                this["ShowBasicDamageCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCounterPercent {
            get {
                return (bool) this["ShowBasicDamageCounterPercent"];
            }

            set {
                this["ShowBasicDamageCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritAverage {
            get {
                return (bool) this["ShowBasicDamageCritAverage"];
            }

            set {
                this["ShowBasicDamageCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritHigh {
            get {
                return (bool) this["ShowBasicDamageCritHigh"];
            }

            set {
                this["ShowBasicDamageCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritHit {
            get {
                return (bool) this["ShowBasicDamageCritHit"];
            }

            set {
                this["ShowBasicDamageCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritLow {
            get {
                return (bool) this["ShowBasicDamageCritLow"];
            }

            set {
                this["ShowBasicDamageCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritMod {
            get {
                return (bool) this["ShowBasicDamageCritMod"];
            }

            set {
                this["ShowBasicDamageCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageCritModAverage {
            get {
                return (bool) this["ShowBasicDamageCritModAverage"];
            }

            set {
                this["ShowBasicDamageCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowBasicDamageCritPercent {
            get {
                return (bool) this["ShowBasicDamageCritPercent"];
            }

            set {
                this["ShowBasicDamageCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageEvade {
            get {
                return (bool) this["ShowBasicDamageEvade"];
            }

            set {
                this["ShowBasicDamageEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageEvadeMod {
            get {
                return (bool) this["ShowBasicDamageEvadeMod"];
            }

            set {
                this["ShowBasicDamageEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageEvadeModAverage {
            get {
                return (bool) this["ShowBasicDamageEvadeModAverage"];
            }

            set {
                this["ShowBasicDamageEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageEvadePercent {
            get {
                return (bool) this["ShowBasicDamageEvadePercent"];
            }

            set {
                this["ShowBasicDamageEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritAverage {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritAverage"];
            }

            set {
                this["ShowBasicDamageOverTimeCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritHigh {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritHigh"];
            }

            set {
                this["ShowBasicDamageOverTimeCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritHit {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritHit"];
            }

            set {
                this["ShowBasicDamageOverTimeCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritLow {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritLow"];
            }

            set {
                this["ShowBasicDamageOverTimeCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritMod {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritMod"];
            }

            set {
                this["ShowBasicDamageOverTimeCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritModAverage {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritModAverage"];
            }

            set {
                this["ShowBasicDamageOverTimeCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeCritPercent {
            get {
                return (bool) this["ShowBasicDamageOverTimeCritPercent"];
            }

            set {
                this["ShowBasicDamageOverTimeCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegAccuracy {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegAccuracy"];
            }

            set {
                this["ShowBasicDamageOverTimeRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegAverage {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegAverage"];
            }

            set {
                this["ShowBasicDamageOverTimeRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegHigh {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegHigh"];
            }

            set {
                this["ShowBasicDamageOverTimeRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegHit {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegHit"];
            }

            set {
                this["ShowBasicDamageOverTimeRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegLow {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegLow"];
            }

            set {
                this["ShowBasicDamageOverTimeRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegMiss {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegMiss"];
            }

            set {
                this["ShowBasicDamageOverTimeRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegMod {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegMod"];
            }

            set {
                this["ShowBasicDamageOverTimeRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageOverTimeRegModAverage {
            get {
                return (bool) this["ShowBasicDamageOverTimeRegModAverage"];
            }

            set {
                this["ShowBasicDamageOverTimeRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageParry {
            get {
                return (bool) this["ShowBasicDamageParry"];
            }

            set {
                this["ShowBasicDamageParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageParryMod {
            get {
                return (bool) this["ShowBasicDamageParryMod"];
            }

            set {
                this["ShowBasicDamageParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageParryModAverage {
            get {
                return (bool) this["ShowBasicDamageParryModAverage"];
            }

            set {
                this["ShowBasicDamageParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageParryPercent {
            get {
                return (bool) this["ShowBasicDamageParryPercent"];
            }

            set {
                this["ShowBasicDamageParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowBasicDamageRegAccuracy {
            get {
                return (bool) this["ShowBasicDamageRegAccuracy"];
            }

            set {
                this["ShowBasicDamageRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegAverage {
            get {
                return (bool) this["ShowBasicDamageRegAverage"];
            }

            set {
                this["ShowBasicDamageRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegHigh {
            get {
                return (bool) this["ShowBasicDamageRegHigh"];
            }

            set {
                this["ShowBasicDamageRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegHit {
            get {
                return (bool) this["ShowBasicDamageRegHit"];
            }

            set {
                this["ShowBasicDamageRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegLow {
            get {
                return (bool) this["ShowBasicDamageRegLow"];
            }

            set {
                this["ShowBasicDamageRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegMiss {
            get {
                return (bool) this["ShowBasicDamageRegMiss"];
            }

            set {
                this["ShowBasicDamageRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegMod {
            get {
                return (bool) this["ShowBasicDamageRegMod"];
            }

            set {
                this["ShowBasicDamageRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageRegModAverage {
            get {
                return (bool) this["ShowBasicDamageRegModAverage"];
            }

            set {
                this["ShowBasicDamageRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageResist {
            get {
                return (bool) this["ShowBasicDamageResist"];
            }

            set {
                this["ShowBasicDamageResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageResistMod {
            get {
                return (bool) this["ShowBasicDamageResistMod"];
            }

            set {
                this["ShowBasicDamageResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageResistModAverage {
            get {
                return (bool) this["ShowBasicDamageResistModAverage"];
            }

            set {
                this["ShowBasicDamageResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageResistPercent {
            get {
                return (bool) this["ShowBasicDamageResistPercent"];
            }

            set {
                this["ShowBasicDamageResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenBlock {
            get {
                return (bool) this["ShowBasicDamageTakenBlock"];
            }

            set {
                this["ShowBasicDamageTakenBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenBlockMod {
            get {
                return (bool) this["ShowBasicDamageTakenBlockMod"];
            }

            set {
                this["ShowBasicDamageTakenBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenBlockModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenBlockModAverage"];
            }

            set {
                this["ShowBasicDamageTakenBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenBlockPercent {
            get {
                return (bool) this["ShowBasicDamageTakenBlockPercent"];
            }

            set {
                this["ShowBasicDamageTakenBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCounter {
            get {
                return (bool) this["ShowBasicDamageTakenCounter"];
            }

            set {
                this["ShowBasicDamageTakenCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCounterMod {
            get {
                return (bool) this["ShowBasicDamageTakenCounterMod"];
            }

            set {
                this["ShowBasicDamageTakenCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCounterModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenCounterModAverage"];
            }

            set {
                this["ShowBasicDamageTakenCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCounterPercent {
            get {
                return (bool) this["ShowBasicDamageTakenCounterPercent"];
            }

            set {
                this["ShowBasicDamageTakenCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritAverage {
            get {
                return (bool) this["ShowBasicDamageTakenCritAverage"];
            }

            set {
                this["ShowBasicDamageTakenCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritHigh {
            get {
                return (bool) this["ShowBasicDamageTakenCritHigh"];
            }

            set {
                this["ShowBasicDamageTakenCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritHit {
            get {
                return (bool) this["ShowBasicDamageTakenCritHit"];
            }

            set {
                this["ShowBasicDamageTakenCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritLow {
            get {
                return (bool) this["ShowBasicDamageTakenCritLow"];
            }

            set {
                this["ShowBasicDamageTakenCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritMod {
            get {
                return (bool) this["ShowBasicDamageTakenCritMod"];
            }

            set {
                this["ShowBasicDamageTakenCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenCritModAverage"];
            }

            set {
                this["ShowBasicDamageTakenCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenCritPercent {
            get {
                return (bool) this["ShowBasicDamageTakenCritPercent"];
            }

            set {
                this["ShowBasicDamageTakenCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenEvade {
            get {
                return (bool) this["ShowBasicDamageTakenEvade"];
            }

            set {
                this["ShowBasicDamageTakenEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenEvadeMod {
            get {
                return (bool) this["ShowBasicDamageTakenEvadeMod"];
            }

            set {
                this["ShowBasicDamageTakenEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenEvadeModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenEvadeModAverage"];
            }

            set {
                this["ShowBasicDamageTakenEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenEvadePercent {
            get {
                return (bool) this["ShowBasicDamageTakenEvadePercent"];
            }

            set {
                this["ShowBasicDamageTakenEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritAverage {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritAverage"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritHigh {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritHigh"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritHit {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritHit"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritLow {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritLow"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritMod {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritMod"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritModAverage"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeCritPercent {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeCritPercent"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegAccuracy {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegAccuracy"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegAverage {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegAverage"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegHigh {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegHigh"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegHit {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegHit"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegLow {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegLow"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegMiss {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegMiss"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegMod {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegMod"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenOverTimeRegModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenOverTimeRegModAverage"];
            }

            set {
                this["ShowBasicDamageTakenOverTimeRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenParry {
            get {
                return (bool) this["ShowBasicDamageTakenParry"];
            }

            set {
                this["ShowBasicDamageTakenParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenParryMod {
            get {
                return (bool) this["ShowBasicDamageTakenParryMod"];
            }

            set {
                this["ShowBasicDamageTakenParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenParryModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenParryModAverage"];
            }

            set {
                this["ShowBasicDamageTakenParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenParryPercent {
            get {
                return (bool) this["ShowBasicDamageTakenParryPercent"];
            }

            set {
                this["ShowBasicDamageTakenParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegAccuracy {
            get {
                return (bool) this["ShowBasicDamageTakenRegAccuracy"];
            }

            set {
                this["ShowBasicDamageTakenRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegAverage {
            get {
                return (bool) this["ShowBasicDamageTakenRegAverage"];
            }

            set {
                this["ShowBasicDamageTakenRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegHigh {
            get {
                return (bool) this["ShowBasicDamageTakenRegHigh"];
            }

            set {
                this["ShowBasicDamageTakenRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegHit {
            get {
                return (bool) this["ShowBasicDamageTakenRegHit"];
            }

            set {
                this["ShowBasicDamageTakenRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegLow {
            get {
                return (bool) this["ShowBasicDamageTakenRegLow"];
            }

            set {
                this["ShowBasicDamageTakenRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegMiss {
            get {
                return (bool) this["ShowBasicDamageTakenRegMiss"];
            }

            set {
                this["ShowBasicDamageTakenRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegMod {
            get {
                return (bool) this["ShowBasicDamageTakenRegMod"];
            }

            set {
                this["ShowBasicDamageTakenRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenRegModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenRegModAverage"];
            }

            set {
                this["ShowBasicDamageTakenRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenResist {
            get {
                return (bool) this["ShowBasicDamageTakenResist"];
            }

            set {
                this["ShowBasicDamageTakenResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenResistMod {
            get {
                return (bool) this["ShowBasicDamageTakenResistMod"];
            }

            set {
                this["ShowBasicDamageTakenResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenResistModAverage {
            get {
                return (bool) this["ShowBasicDamageTakenResistModAverage"];
            }

            set {
                this["ShowBasicDamageTakenResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDamageTakenResistPercent {
            get {
                return (bool) this["ShowBasicDamageTakenResistPercent"];
            }

            set {
                this["ShowBasicDamageTakenResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDOTPS {
            get {
                return (bool) this["ShowBasicDOTPS"];
            }

            set {
                this["ShowBasicDOTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDPS {
            get {
                return (bool) this["ShowBasicDPS"];
            }

            set {
                this["ShowBasicDPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDTOTPS {
            get {
                return (bool) this["ShowBasicDTOTPS"];
            }

            set {
                this["ShowBasicDTOTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicDTPS {
            get {
                return (bool) this["ShowBasicDTPS"];
            }

            set {
                this["ShowBasicDTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritAverage {
            get {
                return (bool) this["ShowBasicHealingCritAverage"];
            }

            set {
                this["ShowBasicHealingCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritHigh {
            get {
                return (bool) this["ShowBasicHealingCritHigh"];
            }

            set {
                this["ShowBasicHealingCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritHit {
            get {
                return (bool) this["ShowBasicHealingCritHit"];
            }

            set {
                this["ShowBasicHealingCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritLow {
            get {
                return (bool) this["ShowBasicHealingCritLow"];
            }

            set {
                this["ShowBasicHealingCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritMod {
            get {
                return (bool) this["ShowBasicHealingCritMod"];
            }

            set {
                this["ShowBasicHealingCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritModAverage {
            get {
                return (bool) this["ShowBasicHealingCritModAverage"];
            }

            set {
                this["ShowBasicHealingCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingCritPercent {
            get {
                return (bool) this["ShowBasicHealingCritPercent"];
            }

            set {
                this["ShowBasicHealingCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritAverage {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritAverage"];
            }

            set {
                this["ShowBasicHealingMitigatedCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritHigh {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritHigh"];
            }

            set {
                this["ShowBasicHealingMitigatedCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritHit {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritHit"];
            }

            set {
                this["ShowBasicHealingMitigatedCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritLow {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritLow"];
            }

            set {
                this["ShowBasicHealingMitigatedCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritMod {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritMod"];
            }

            set {
                this["ShowBasicHealingMitigatedCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritModAverage {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritModAverage"];
            }

            set {
                this["ShowBasicHealingMitigatedCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedCritPercent {
            get {
                return (bool) this["ShowBasicHealingMitigatedCritPercent"];
            }

            set {
                this["ShowBasicHealingMitigatedCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegAverage {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegAverage"];
            }

            set {
                this["ShowBasicHealingMitigatedRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegHigh {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegHigh"];
            }

            set {
                this["ShowBasicHealingMitigatedRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegHit {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegHit"];
            }

            set {
                this["ShowBasicHealingMitigatedRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegLow {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegLow"];
            }

            set {
                this["ShowBasicHealingMitigatedRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegMod {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegMod"];
            }

            set {
                this["ShowBasicHealingMitigatedRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingMitigatedRegModAverage {
            get {
                return (bool) this["ShowBasicHealingMitigatedRegModAverage"];
            }

            set {
                this["ShowBasicHealingMitigatedRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritAverage {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritAverage"];
            }

            set {
                this["ShowBasicHealingOverHealingCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritHigh {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritHigh"];
            }

            set {
                this["ShowBasicHealingOverHealingCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritHit {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritHit"];
            }

            set {
                this["ShowBasicHealingOverHealingCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritLow {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritLow"];
            }

            set {
                this["ShowBasicHealingOverHealingCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritMod {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritMod"];
            }

            set {
                this["ShowBasicHealingOverHealingCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritModAverage {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritModAverage"];
            }

            set {
                this["ShowBasicHealingOverHealingCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingCritPercent {
            get {
                return (bool) this["ShowBasicHealingOverHealingCritPercent"];
            }

            set {
                this["ShowBasicHealingOverHealingCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegAverage {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegAverage"];
            }

            set {
                this["ShowBasicHealingOverHealingRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegHigh {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegHigh"];
            }

            set {
                this["ShowBasicHealingOverHealingRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegHit {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegHit"];
            }

            set {
                this["ShowBasicHealingOverHealingRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegLow {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegLow"];
            }

            set {
                this["ShowBasicHealingOverHealingRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegMod {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegMod"];
            }

            set {
                this["ShowBasicHealingOverHealingRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverHealingRegModAverage {
            get {
                return (bool) this["ShowBasicHealingOverHealingRegModAverage"];
            }

            set {
                this["ShowBasicHealingOverHealingRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritAverage {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritAverage"];
            }

            set {
                this["ShowBasicHealingOverTimeCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritHigh {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritHigh"];
            }

            set {
                this["ShowBasicHealingOverTimeCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritHit {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritHit"];
            }

            set {
                this["ShowBasicHealingOverTimeCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritLow {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritLow"];
            }

            set {
                this["ShowBasicHealingOverTimeCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritMod {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritMod"];
            }

            set {
                this["ShowBasicHealingOverTimeCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritModAverage {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritModAverage"];
            }

            set {
                this["ShowBasicHealingOverTimeCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeCritPercent {
            get {
                return (bool) this["ShowBasicHealingOverTimeCritPercent"];
            }

            set {
                this["ShowBasicHealingOverTimeCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegAverage {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegAverage"];
            }

            set {
                this["ShowBasicHealingOverTimeRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegHigh {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegHigh"];
            }

            set {
                this["ShowBasicHealingOverTimeRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegHit {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegHit"];
            }

            set {
                this["ShowBasicHealingOverTimeRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegLow {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegLow"];
            }

            set {
                this["ShowBasicHealingOverTimeRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegMod {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegMod"];
            }

            set {
                this["ShowBasicHealingOverTimeRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingOverTimeRegModAverage {
            get {
                return (bool) this["ShowBasicHealingOverTimeRegModAverage"];
            }

            set {
                this["ShowBasicHealingOverTimeRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegAverage {
            get {
                return (bool) this["ShowBasicHealingRegAverage"];
            }

            set {
                this["ShowBasicHealingRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegHigh {
            get {
                return (bool) this["ShowBasicHealingRegHigh"];
            }

            set {
                this["ShowBasicHealingRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegHit {
            get {
                return (bool) this["ShowBasicHealingRegHit"];
            }

            set {
                this["ShowBasicHealingRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegLow {
            get {
                return (bool) this["ShowBasicHealingRegLow"];
            }

            set {
                this["ShowBasicHealingRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegMod {
            get {
                return (bool) this["ShowBasicHealingRegMod"];
            }

            set {
                this["ShowBasicHealingRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHealingRegModAverage {
            get {
                return (bool) this["ShowBasicHealingRegModAverage"];
            }

            set {
                this["ShowBasicHealingRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHMPS {
            get {
                return (bool) this["ShowBasicHMPS"];
            }

            set {
                this["ShowBasicHMPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHOHPS {
            get {
                return (bool) this["ShowBasicHOHPS"];
            }

            set {
                this["ShowBasicHOHPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHOTPS {
            get {
                return (bool) this["ShowBasicHOTPS"];
            }

            set {
                this["ShowBasicHOTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicHPS {
            get {
                return (bool) this["ShowBasicHPS"];
            }

            set {
                this["ShowBasicHPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalDamage {
            get {
                return (bool) this["ShowBasicPercentOfCriticalDamage"];
            }

            set {
                this["ShowBasicPercentOfCriticalDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalDamageOverTime {
            get {
                return (bool) this["ShowBasicPercentOfCriticalDamageOverTime"];
            }

            set {
                this["ShowBasicPercentOfCriticalDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalDamageTaken {
            get {
                return (bool) this["ShowBasicPercentOfCriticalDamageTaken"];
            }

            set {
                this["ShowBasicPercentOfCriticalDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicPercentOfCriticalDamageTakenOverTime"];
            }

            set {
                this["ShowBasicPercentOfCriticalDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalHealing {
            get {
                return (bool) this["ShowBasicPercentOfCriticalHealing"];
            }

            set {
                this["ShowBasicPercentOfCriticalHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalHealingMitigated {
            get {
                return (bool) this["ShowBasicPercentOfCriticalHealingMitigated"];
            }

            set {
                this["ShowBasicPercentOfCriticalHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalHealingOverHealing {
            get {
                return (bool) this["ShowBasicPercentOfCriticalHealingOverHealing"];
            }

            set {
                this["ShowBasicPercentOfCriticalHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfCriticalHealingOverTime {
            get {
                return (bool) this["ShowBasicPercentOfCriticalHealingOverTime"];
            }

            set {
                this["ShowBasicPercentOfCriticalHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularDamage {
            get {
                return (bool) this["ShowBasicPercentOfRegularDamage"];
            }

            set {
                this["ShowBasicPercentOfRegularDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularDamageOverTime {
            get {
                return (bool) this["ShowBasicPercentOfRegularDamageOverTime"];
            }

            set {
                this["ShowBasicPercentOfRegularDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularDamageTaken {
            get {
                return (bool) this["ShowBasicPercentOfRegularDamageTaken"];
            }

            set {
                this["ShowBasicPercentOfRegularDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicPercentOfRegularDamageTakenOverTime"];
            }

            set {
                this["ShowBasicPercentOfRegularDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularHealing {
            get {
                return (bool) this["ShowBasicPercentOfRegularHealing"];
            }

            set {
                this["ShowBasicPercentOfRegularHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularHealingMitigated {
            get {
                return (bool) this["ShowBasicPercentOfRegularHealingMitigated"];
            }

            set {
                this["ShowBasicPercentOfRegularHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularHealingOverHealing {
            get {
                return (bool) this["ShowBasicPercentOfRegularHealingOverHealing"];
            }

            set {
                this["ShowBasicPercentOfRegularHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfRegularHealingOverTime {
            get {
                return (bool) this["ShowBasicPercentOfRegularHealingOverTime"];
            }

            set {
                this["ShowBasicPercentOfRegularHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallDamage {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallDamage"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallDamageOverTime {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallDamageOverTime"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallDamageTaken {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallDamageTaken"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallDamageTakenOverTime"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallHealing {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallHealing"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallHealingMitigated {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallHealingMitigated"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallHealingOverHealing {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallHealingOverHealing"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicPercentOfTotalOverallHealingOverTime {
            get {
                return (bool) this["ShowBasicPercentOfTotalOverallHealingOverTime"];
            }

            set {
                this["ShowBasicPercentOfTotalOverallHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularDamage {
            get {
                return (bool) this["ShowBasicRegularDamage"];
            }

            set {
                this["ShowBasicRegularDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularDamageOverTime {
            get {
                return (bool) this["ShowBasicRegularDamageOverTime"];
            }

            set {
                this["ShowBasicRegularDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularDamageTaken {
            get {
                return (bool) this["ShowBasicRegularDamageTaken"];
            }

            set {
                this["ShowBasicRegularDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicRegularDamageTakenOverTime"];
            }

            set {
                this["ShowBasicRegularDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularHealing {
            get {
                return (bool) this["ShowBasicRegularHealing"];
            }

            set {
                this["ShowBasicRegularHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularHealingMitigated {
            get {
                return (bool) this["ShowBasicRegularHealingMitigated"];
            }

            set {
                this["ShowBasicRegularHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularHealingOverHealing {
            get {
                return (bool) this["ShowBasicRegularHealingOverHealing"];
            }

            set {
                this["ShowBasicRegularHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicRegularHealingOverTime {
            get {
                return (bool) this["ShowBasicRegularHealingOverTime"];
            }

            set {
                this["ShowBasicRegularHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalDamageActionsUsed {
            get {
                return (bool) this["ShowBasicTotalDamageActionsUsed"];
            }

            set {
                this["ShowBasicTotalDamageActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalDamageOverTimeActionsUsed {
            get {
                return (bool) this["ShowBasicTotalDamageOverTimeActionsUsed"];
            }

            set {
                this["ShowBasicTotalDamageOverTimeActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalDamageTakenActionsUsed {
            get {
                return (bool) this["ShowBasicTotalDamageTakenActionsUsed"];
            }

            set {
                this["ShowBasicTotalDamageTakenActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalDamageTakenOverTimeActionsUsed {
            get {
                return (bool) this["ShowBasicTotalDamageTakenOverTimeActionsUsed"];
            }

            set {
                this["ShowBasicTotalDamageTakenOverTimeActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalHealingActionsUsed {
            get {
                return (bool) this["ShowBasicTotalHealingActionsUsed"];
            }

            set {
                this["ShowBasicTotalHealingActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalHealingMitigatedActionsUsed {
            get {
                return (bool) this["ShowBasicTotalHealingMitigatedActionsUsed"];
            }

            set {
                this["ShowBasicTotalHealingMitigatedActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalHealingOverHealingActionsUsed {
            get {
                return (bool) this["ShowBasicTotalHealingOverHealingActionsUsed"];
            }

            set {
                this["ShowBasicTotalHealingOverHealingActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalHealingOverTimeActionsUsed {
            get {
                return (bool) this["ShowBasicTotalHealingOverTimeActionsUsed"];
            }

            set {
                this["ShowBasicTotalHealingOverTimeActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallDamage {
            get {
                return (bool) this["ShowBasicTotalOverallDamage"];
            }

            set {
                this["ShowBasicTotalOverallDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallDamageOverTime {
            get {
                return (bool) this["ShowBasicTotalOverallDamageOverTime"];
            }

            set {
                this["ShowBasicTotalOverallDamageOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallDamageTaken {
            get {
                return (bool) this["ShowBasicTotalOverallDamageTaken"];
            }

            set {
                this["ShowBasicTotalOverallDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallDamageTakenOverTime {
            get {
                return (bool) this["ShowBasicTotalOverallDamageTakenOverTime"];
            }

            set {
                this["ShowBasicTotalOverallDamageTakenOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallHealing {
            get {
                return (bool) this["ShowBasicTotalOverallHealing"];
            }

            set {
                this["ShowBasicTotalOverallHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallHealingMitigated {
            get {
                return (bool) this["ShowBasicTotalOverallHealingMitigated"];
            }

            set {
                this["ShowBasicTotalOverallHealingMitigated"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallHealingOverHealing {
            get {
                return (bool) this["ShowBasicTotalOverallHealingOverHealing"];
            }

            set {
                this["ShowBasicTotalOverallHealingOverHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowBasicTotalOverallHealingOverTime {
            get {
                return (bool) this["ShowBasicTotalOverallHealingOverTime"];
            }

            set {
                this["ShowBasicTotalOverallHealingOverTime"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnCriticalDamage {
            get {
                return (bool) this["ShowColumnCriticalDamage"];
            }

            set {
                this["ShowColumnCriticalDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnCriticalDamageTaken {
            get {
                return (bool) this["ShowColumnCriticalDamageTaken"];
            }

            set {
                this["ShowColumnCriticalDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnCriticalHealing {
            get {
                return (bool) this["ShowColumnCriticalHealing"];
            }

            set {
                this["ShowColumnCriticalHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageBlock {
            get {
                return (bool) this["ShowColumnDamageBlock"];
            }

            set {
                this["ShowColumnDamageBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageBlockMod {
            get {
                return (bool) this["ShowColumnDamageBlockMod"];
            }

            set {
                this["ShowColumnDamageBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageBlockModAverage {
            get {
                return (bool) this["ShowColumnDamageBlockModAverage"];
            }

            set {
                this["ShowColumnDamageBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageBlockPercent {
            get {
                return (bool) this["ShowColumnDamageBlockPercent"];
            }

            set {
                this["ShowColumnDamageBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCounter {
            get {
                return (bool) this["ShowColumnDamageCounter"];
            }

            set {
                this["ShowColumnDamageCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCounterMod {
            get {
                return (bool) this["ShowColumnDamageCounterMod"];
            }

            set {
                this["ShowColumnDamageCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCounterModAverage {
            get {
                return (bool) this["ShowColumnDamageCounterModAverage"];
            }

            set {
                this["ShowColumnDamageCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCounterPercent {
            get {
                return (bool) this["ShowColumnDamageCounterPercent"];
            }

            set {
                this["ShowColumnDamageCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritAverage {
            get {
                return (bool) this["ShowColumnDamageCritAverage"];
            }

            set {
                this["ShowColumnDamageCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritHigh {
            get {
                return (bool) this["ShowColumnDamageCritHigh"];
            }

            set {
                this["ShowColumnDamageCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritHit {
            get {
                return (bool) this["ShowColumnDamageCritHit"];
            }

            set {
                this["ShowColumnDamageCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritLow {
            get {
                return (bool) this["ShowColumnDamageCritLow"];
            }

            set {
                this["ShowColumnDamageCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritMod {
            get {
                return (bool) this["ShowColumnDamageCritMod"];
            }

            set {
                this["ShowColumnDamageCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritModAverage {
            get {
                return (bool) this["ShowColumnDamageCritModAverage"];
            }

            set {
                this["ShowColumnDamageCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageCritPercent {
            get {
                return (bool) this["ShowColumnDamageCritPercent"];
            }

            set {
                this["ShowColumnDamageCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageEvade {
            get {
                return (bool) this["ShowColumnDamageEvade"];
            }

            set {
                this["ShowColumnDamageEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageEvadeMod {
            get {
                return (bool) this["ShowColumnDamageEvadeMod"];
            }

            set {
                this["ShowColumnDamageEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageEvadeModAverage {
            get {
                return (bool) this["ShowColumnDamageEvadeModAverage"];
            }

            set {
                this["ShowColumnDamageEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageEvadePercent {
            get {
                return (bool) this["ShowColumnDamageEvadePercent"];
            }

            set {
                this["ShowColumnDamageEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageParry {
            get {
                return (bool) this["ShowColumnDamageParry"];
            }

            set {
                this["ShowColumnDamageParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageParryMod {
            get {
                return (bool) this["ShowColumnDamageParryMod"];
            }

            set {
                this["ShowColumnDamageParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageParryModAverage {
            get {
                return (bool) this["ShowColumnDamageParryModAverage"];
            }

            set {
                this["ShowColumnDamageParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageParryPercent {
            get {
                return (bool) this["ShowColumnDamageParryPercent"];
            }

            set {
                this["ShowColumnDamageParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegAccuracy {
            get {
                return (bool) this["ShowColumnDamageRegAccuracy"];
            }

            set {
                this["ShowColumnDamageRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegAverage {
            get {
                return (bool) this["ShowColumnDamageRegAverage"];
            }

            set {
                this["ShowColumnDamageRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegHigh {
            get {
                return (bool) this["ShowColumnDamageRegHigh"];
            }

            set {
                this["ShowColumnDamageRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegHit {
            get {
                return (bool) this["ShowColumnDamageRegHit"];
            }

            set {
                this["ShowColumnDamageRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegLow {
            get {
                return (bool) this["ShowColumnDamageRegLow"];
            }

            set {
                this["ShowColumnDamageRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegMiss {
            get {
                return (bool) this["ShowColumnDamageRegMiss"];
            }

            set {
                this["ShowColumnDamageRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegMod {
            get {
                return (bool) this["ShowColumnDamageRegMod"];
            }

            set {
                this["ShowColumnDamageRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageRegModAverage {
            get {
                return (bool) this["ShowColumnDamageRegModAverage"];
            }

            set {
                this["ShowColumnDamageRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageResist {
            get {
                return (bool) this["ShowColumnDamageResist"];
            }

            set {
                this["ShowColumnDamageResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageResistMod {
            get {
                return (bool) this["ShowColumnDamageResistMod"];
            }

            set {
                this["ShowColumnDamageResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageResistModAverage {
            get {
                return (bool) this["ShowColumnDamageResistModAverage"];
            }

            set {
                this["ShowColumnDamageResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageResistPercent {
            get {
                return (bool) this["ShowColumnDamageResistPercent"];
            }

            set {
                this["ShowColumnDamageResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenBlock {
            get {
                return (bool) this["ShowColumnDamageTakenBlock"];
            }

            set {
                this["ShowColumnDamageTakenBlock"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenBlockMod {
            get {
                return (bool) this["ShowColumnDamageTakenBlockMod"];
            }

            set {
                this["ShowColumnDamageTakenBlockMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenBlockModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenBlockModAverage"];
            }

            set {
                this["ShowColumnDamageTakenBlockModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenBlockPercent {
            get {
                return (bool) this["ShowColumnDamageTakenBlockPercent"];
            }

            set {
                this["ShowColumnDamageTakenBlockPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCounter {
            get {
                return (bool) this["ShowColumnDamageTakenCounter"];
            }

            set {
                this["ShowColumnDamageTakenCounter"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCounterMod {
            get {
                return (bool) this["ShowColumnDamageTakenCounterMod"];
            }

            set {
                this["ShowColumnDamageTakenCounterMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCounterModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenCounterModAverage"];
            }

            set {
                this["ShowColumnDamageTakenCounterModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCounterPercent {
            get {
                return (bool) this["ShowColumnDamageTakenCounterPercent"];
            }

            set {
                this["ShowColumnDamageTakenCounterPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritAverage {
            get {
                return (bool) this["ShowColumnDamageTakenCritAverage"];
            }

            set {
                this["ShowColumnDamageTakenCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritHigh {
            get {
                return (bool) this["ShowColumnDamageTakenCritHigh"];
            }

            set {
                this["ShowColumnDamageTakenCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritHit {
            get {
                return (bool) this["ShowColumnDamageTakenCritHit"];
            }

            set {
                this["ShowColumnDamageTakenCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritLow {
            get {
                return (bool) this["ShowColumnDamageTakenCritLow"];
            }

            set {
                this["ShowColumnDamageTakenCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritMod {
            get {
                return (bool) this["ShowColumnDamageTakenCritMod"];
            }

            set {
                this["ShowColumnDamageTakenCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenCritModAverage"];
            }

            set {
                this["ShowColumnDamageTakenCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenCritPercent {
            get {
                return (bool) this["ShowColumnDamageTakenCritPercent"];
            }

            set {
                this["ShowColumnDamageTakenCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenEvade {
            get {
                return (bool) this["ShowColumnDamageTakenEvade"];
            }

            set {
                this["ShowColumnDamageTakenEvade"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenEvadeMod {
            get {
                return (bool) this["ShowColumnDamageTakenEvadeMod"];
            }

            set {
                this["ShowColumnDamageTakenEvadeMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenEvadeModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenEvadeModAverage"];
            }

            set {
                this["ShowColumnDamageTakenEvadeModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenEvadePercent {
            get {
                return (bool) this["ShowColumnDamageTakenEvadePercent"];
            }

            set {
                this["ShowColumnDamageTakenEvadePercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenParry {
            get {
                return (bool) this["ShowColumnDamageTakenParry"];
            }

            set {
                this["ShowColumnDamageTakenParry"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenParryMod {
            get {
                return (bool) this["ShowColumnDamageTakenParryMod"];
            }

            set {
                this["ShowColumnDamageTakenParryMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenParryModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenParryModAverage"];
            }

            set {
                this["ShowColumnDamageTakenParryModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenParryPercent {
            get {
                return (bool) this["ShowColumnDamageTakenParryPercent"];
            }

            set {
                this["ShowColumnDamageTakenParryPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegAccuracy {
            get {
                return (bool) this["ShowColumnDamageTakenRegAccuracy"];
            }

            set {
                this["ShowColumnDamageTakenRegAccuracy"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegAverage {
            get {
                return (bool) this["ShowColumnDamageTakenRegAverage"];
            }

            set {
                this["ShowColumnDamageTakenRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegHigh {
            get {
                return (bool) this["ShowColumnDamageTakenRegHigh"];
            }

            set {
                this["ShowColumnDamageTakenRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegHit {
            get {
                return (bool) this["ShowColumnDamageTakenRegHit"];
            }

            set {
                this["ShowColumnDamageTakenRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegLow {
            get {
                return (bool) this["ShowColumnDamageTakenRegLow"];
            }

            set {
                this["ShowColumnDamageTakenRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegMiss {
            get {
                return (bool) this["ShowColumnDamageTakenRegMiss"];
            }

            set {
                this["ShowColumnDamageTakenRegMiss"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegMod {
            get {
                return (bool) this["ShowColumnDamageTakenRegMod"];
            }

            set {
                this["ShowColumnDamageTakenRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenRegModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenRegModAverage"];
            }

            set {
                this["ShowColumnDamageTakenRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenResist {
            get {
                return (bool) this["ShowColumnDamageTakenResist"];
            }

            set {
                this["ShowColumnDamageTakenResist"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenResistMod {
            get {
                return (bool) this["ShowColumnDamageTakenResistMod"];
            }

            set {
                this["ShowColumnDamageTakenResistMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenResistModAverage {
            get {
                return (bool) this["ShowColumnDamageTakenResistModAverage"];
            }

            set {
                this["ShowColumnDamageTakenResistModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDamageTakenResistPercent {
            get {
                return (bool) this["ShowColumnDamageTakenResistPercent"];
            }

            set {
                this["ShowColumnDamageTakenResistPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDPS {
            get {
                return (bool) this["ShowColumnDPS"];
            }

            set {
                this["ShowColumnDPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnDTPS {
            get {
                return (bool) this["ShowColumnDTPS"];
            }

            set {
                this["ShowColumnDTPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritAverage {
            get {
                return (bool) this["ShowColumnHealingCritAverage"];
            }

            set {
                this["ShowColumnHealingCritAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritHigh {
            get {
                return (bool) this["ShowColumnHealingCritHigh"];
            }

            set {
                this["ShowColumnHealingCritHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritHit {
            get {
                return (bool) this["ShowColumnHealingCritHit"];
            }

            set {
                this["ShowColumnHealingCritHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritLow {
            get {
                return (bool) this["ShowColumnHealingCritLow"];
            }

            set {
                this["ShowColumnHealingCritLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritMod {
            get {
                return (bool) this["ShowColumnHealingCritMod"];
            }

            set {
                this["ShowColumnHealingCritMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritModAverage {
            get {
                return (bool) this["ShowColumnHealingCritModAverage"];
            }

            set {
                this["ShowColumnHealingCritModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingCritPercent {
            get {
                return (bool) this["ShowColumnHealingCritPercent"];
            }

            set {
                this["ShowColumnHealingCritPercent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegAverage {
            get {
                return (bool) this["ShowColumnHealingRegAverage"];
            }

            set {
                this["ShowColumnHealingRegAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegHigh {
            get {
                return (bool) this["ShowColumnHealingRegHigh"];
            }

            set {
                this["ShowColumnHealingRegHigh"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegHit {
            get {
                return (bool) this["ShowColumnHealingRegHit"];
            }

            set {
                this["ShowColumnHealingRegHit"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegLow {
            get {
                return (bool) this["ShowColumnHealingRegLow"];
            }

            set {
                this["ShowColumnHealingRegLow"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegMod {
            get {
                return (bool) this["ShowColumnHealingRegMod"];
            }

            set {
                this["ShowColumnHealingRegMod"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHealingRegModAverage {
            get {
                return (bool) this["ShowColumnHealingRegModAverage"];
            }

            set {
                this["ShowColumnHealingRegModAverage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnHPS {
            get {
                return (bool) this["ShowColumnHPS"];
            }

            set {
                this["ShowColumnHPS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfCriticalDamage {
            get {
                return (bool) this["ShowColumnPercentOfCriticalDamage"];
            }

            set {
                this["ShowColumnPercentOfCriticalDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfCriticalDamageTaken {
            get {
                return (bool) this["ShowColumnPercentOfCriticalDamageTaken"];
            }

            set {
                this["ShowColumnPercentOfCriticalDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfCriticalHealing {
            get {
                return (bool) this["ShowColumnPercentOfCriticalHealing"];
            }

            set {
                this["ShowColumnPercentOfCriticalHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfRegularDamage {
            get {
                return (bool) this["ShowColumnPercentOfRegularDamage"];
            }

            set {
                this["ShowColumnPercentOfRegularDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfRegularDamageTaken {
            get {
                return (bool) this["ShowColumnPercentOfRegularDamageTaken"];
            }

            set {
                this["ShowColumnPercentOfRegularDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfRegularHealing {
            get {
                return (bool) this["ShowColumnPercentOfRegularHealing"];
            }

            set {
                this["ShowColumnPercentOfRegularHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfTotalOverallDamage {
            get {
                return (bool) this["ShowColumnPercentOfTotalOverallDamage"];
            }

            set {
                this["ShowColumnPercentOfTotalOverallDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfTotalOverallDamageTaken {
            get {
                return (bool) this["ShowColumnPercentOfTotalOverallDamageTaken"];
            }

            set {
                this["ShowColumnPercentOfTotalOverallDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnPercentOfTotalOverallHealing {
            get {
                return (bool) this["ShowColumnPercentOfTotalOverallHealing"];
            }

            set {
                this["ShowColumnPercentOfTotalOverallHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnRegularDamage {
            get {
                return (bool) this["ShowColumnRegularDamage"];
            }

            set {
                this["ShowColumnRegularDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnRegularDamageTaken {
            get {
                return (bool) this["ShowColumnRegularDamageTaken"];
            }

            set {
                this["ShowColumnRegularDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnRegularHealing {
            get {
                return (bool) this["ShowColumnRegularHealing"];
            }

            set {
                this["ShowColumnRegularHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalDamageActionsUsed {
            get {
                return (bool) this["ShowColumnTotalDamageActionsUsed"];
            }

            set {
                this["ShowColumnTotalDamageActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalDamageTakenActionsUsed {
            get {
                return (bool) this["ShowColumnTotalDamageTakenActionsUsed"];
            }

            set {
                this["ShowColumnTotalDamageTakenActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalHealingActionsUsed {
            get {
                return (bool) this["ShowColumnTotalHealingActionsUsed"];
            }

            set {
                this["ShowColumnTotalHealingActionsUsed"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalOverallDamage {
            get {
                return (bool) this["ShowColumnTotalOverallDamage"];
            }

            set {
                this["ShowColumnTotalOverallDamage"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalOverallDamageTaken {
            get {
                return (bool) this["ShowColumnTotalOverallDamageTaken"];
            }

            set {
                this["ShowColumnTotalOverallDamageTaken"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowColumnTotalOverallHealing {
            get {
                return (bool) this["ShowColumnTotalOverallHealing"];
            }

            set {
                this["ShowColumnTotalOverallHealing"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowDPSWidgetOnLoad {
            get {
                return (bool) this["ShowDPSWidgetOnLoad"];
            }

            set {
                this["ShowDPSWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowDTPSWidgetOnLoad {
            get {
                return (bool) this["ShowDTPSWidgetOnLoad"];
            }

            set {
                this["ShowDTPSWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowHPSWidgetOnLoad {
            get {
                return (bool) this["ShowHPSWidgetOnLoad"];
            }

            set {
                this["ShowHPSWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowJobNameInWidgets {
            get {
                return (bool) this["ShowJobNameInWidgets"];
            }

            set {
                this["ShowJobNameInWidgets"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTitlesOnWidgets {
            get {
                return (bool) this["ShowTitlesOnWidgets"];
            }

            set {
                this["ShowTitlesOnWidgets"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("LimeGreen")]
        public string SMNProgressBarForeground {
            get {
                return (string) this["SMNProgressBarForeground"];
            }

            set {
                this["SMNProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Damage Only")]
        public string StoreHistoryEvent {
            get {
                return (string) this["StoreHistoryEvent"];
            }

            set {
                this["StoreHistoryEvent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." + "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" + "tring>Damage Only</string>\r\n  <string>Any</string>\r\n</ArrayOfString>")]
        public StringCollection StoreHistoryEventList {
            get {
                return (StringCollection) this["StoreHistoryEventList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("10000")]
        public string StoreHistoryInterval {
            get {
                return (string) this["StoreHistoryInterval"];
            }

            set {
                this["StoreHistoryInterval"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TrackXPSFromParseStartEvent {
            get {
                return (bool) this["TrackXPSFromParseStartEvent"];
            }

            set {
                this["TrackXPSFromParseStartEvent"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Red")]
        public string WARProgressBarForeground {
            get {
                return (string) this["WARProgressBarForeground"];
            }

            set {
                this["WARProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("White")]
        public string WHMProgressBarForeground {
            get {
                return (string) this["WHMProgressBarForeground"];
            }

            set {
                this["WHMProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool WidgetClickThroughEnabled {
            get {
                return (bool) this["WidgetClickThroughEnabled"];
            }

            set {
                this["WidgetClickThroughEnabled"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.7")]
        public string WidgetOpacity {
            get {
                return (string) this["WidgetOpacity"];
            }

            set {
                this["WidgetOpacity"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.5</string>
  <string>0.6</string>
  <string>0.7</string>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
</ArrayOfString>")]
        public StringCollection WidgetOpacityList {
            get {
                return (StringCollection) this["WidgetOpacityList"];
            }

            set {
                this["WidgetOpacityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public double Zoom {
            get {
                return (double) this["Zoom"];
            }

            set {
                this["Zoom"] = value;
                this.RaisePropertyChanged();
            }
        }

        public static void SetValue(string key, string value, CultureInfo cultureInfo) {
            try {
                var type = Default[key].GetType().Name;
                switch (type) {
                    case "Boolean":
                        Default[key] = bool.Parse(value);
                        break;
                    case "Color":
                        var cc = new ColorConverter();
                        object color = cc.ConvertFrom(value);
                        Default[key] = color ?? Colors.Black;
                        break;
                    case "Double":
                        Default[key] = double.Parse(value, cultureInfo);
                        break;
                    case "Font":
                        var fc = new FontConverter();
                        object font = fc.ConvertFromString(value);
                        Default[key] = font ?? new Font(new FontFamily("Microsoft Sans Serif"), 12);
                        break;
                    case "Int32":
                        Default[key] = int.Parse(value, cultureInfo);
                        break;
                    default:
                        Default[key] = value;
                        break;
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        public new void Reset() {
            this.DefaultSettings();
            foreach (var key in Constants.Settings) {
                SettingsProperty settingsProperty = Default.Properties[key];
                if (settingsProperty == null) {
                    continue;
                }

                var value = settingsProperty.DefaultValue.ToString();
                SetValue(key, value, CultureInfo.InvariantCulture);
            }
        }

        public override void Save() {
            // this call to default settings only ensures we keep the settings we want and delete the ones we don't (old)
            this.DefaultSettings();
            this.SaveSettingsNode();

            // I would make a function for each node itself; other examples such as log/event would showcase this
            Constants.XSettings.Save(Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Parse.xml"));
        }

        private void DefaultSettings() {
            Constants.Settings.Clear();
            Constants.Settings.Add("StoreHistoryEvent");
            Constants.Settings.Add("StoreHistoryInterval");
            Constants.Settings.Add("EnableStoreHistoryReset");
            Constants.Settings.Add("IgnoreLimitBreaks");
            Constants.Settings.Add("TrackXPSFromParseStartEvent");
            Constants.Settings.Add("ParseYou");
            Constants.Settings.Add("ParseParty");
            Constants.Settings.Add("ParseAlliance");
            Constants.Settings.Add("ParseOther");
            Constants.Settings.Add("ParseAdvanced");

            

            Constants.Settings.Add("ShowBasicTotalOverallDamage");
            Constants.Settings.Add("ShowBasicRegularDamage");
            Constants.Settings.Add("ShowBasicCriticalDamage");
            Constants.Settings.Add("ShowBasicTotalDamageActionsUsed");
            Constants.Settings.Add("ShowBasicDPS");
            Constants.Settings.Add("ShowBasicDamageRegHit");
            Constants.Settings.Add("ShowBasicDamageRegMiss");
            Constants.Settings.Add("ShowBasicDamageRegAccuracy");
            Constants.Settings.Add("ShowBasicDamageRegLow");
            Constants.Settings.Add("ShowBasicDamageRegHigh");
            Constants.Settings.Add("ShowBasicDamageRegAverage");
            Constants.Settings.Add("ShowBasicDamageRegMod");
            Constants.Settings.Add("ShowBasicDamageRegModAverage");
            Constants.Settings.Add("ShowBasicDamageCritHit");
            Constants.Settings.Add("ShowBasicDamageCritPercent");
            Constants.Settings.Add("ShowBasicDamageCritLow");
            Constants.Settings.Add("ShowBasicDamageCritHigh");
            Constants.Settings.Add("ShowBasicDamageCritAverage");
            Constants.Settings.Add("ShowBasicDamageCritMod");
            Constants.Settings.Add("ShowBasicDamageCritModAverage");
            Constants.Settings.Add("ShowBasicDamageCounter");
            Constants.Settings.Add("ShowBasicDamageCounterPercent");
            Constants.Settings.Add("ShowBasicDamageCounterMod");
            Constants.Settings.Add("ShowBasicDamageCounterModAverage");
            Constants.Settings.Add("ShowBasicDamageBlock");
            Constants.Settings.Add("ShowBasicDamageBlockPercent");
            Constants.Settings.Add("ShowBasicDamageBlockMod");
            Constants.Settings.Add("ShowBasicDamageBlockModAverage");
            Constants.Settings.Add("ShowBasicDamageParry");
            Constants.Settings.Add("ShowBasicDamageParryPercent");
            Constants.Settings.Add("ShowBasicDamageParryMod");
            Constants.Settings.Add("ShowBasicDamageParryModAverage");
            Constants.Settings.Add("ShowBasicDamageResist");
            Constants.Settings.Add("ShowBasicDamageResistPercent");
            Constants.Settings.Add("ShowBasicDamageResistMod");
            Constants.Settings.Add("ShowBasicDamageResistModAverage");
            Constants.Settings.Add("ShowBasicDamageEvade");
            Constants.Settings.Add("ShowBasicDamageEvadePercent");
            Constants.Settings.Add("ShowBasicDamageEvadeMod");
            Constants.Settings.Add("ShowBasicDamageEvadeModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallDamage");
            Constants.Settings.Add("ShowBasicPercentOfRegularDamage");
            Constants.Settings.Add("ShowBasicPercentOfCriticalDamage");

            Constants.Settings.Add("ShowBasicTotalOverallDamageOverTime");
            Constants.Settings.Add("ShowBasicRegularDamageOverTime");
            Constants.Settings.Add("ShowBasicCriticalDamageOverTime");
            Constants.Settings.Add("ShowBasicTotalDamageOverTimeActionsUsed");
            Constants.Settings.Add("ShowBasicDOTPS");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegHit");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegMiss");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegAccuracy");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegLow");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegHigh");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegAverage");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegMod");
            Constants.Settings.Add("ShowBasicDamageOverTimeRegModAverage");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritHit");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritPercent");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritLow");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritHigh");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritAverage");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritMod");
            Constants.Settings.Add("ShowBasicDamageOverTimeCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallDamageOverTime");
            Constants.Settings.Add("ShowBasicPercentOfRegularDamageOverTime");
            Constants.Settings.Add("ShowBasicPercentOfCriticalDamageOverTime");

            Constants.Settings.Add("ShowBasicTotalOverallHealing");
            Constants.Settings.Add("ShowBasicRegularHealing");
            Constants.Settings.Add("ShowBasicCriticalHealing");
            Constants.Settings.Add("ShowBasicTotalHealingActionsUsed");
            Constants.Settings.Add("ShowBasicHPS");
            Constants.Settings.Add("ShowBasicHealingRegHit");
            Constants.Settings.Add("ShowBasicHealingRegLow");
            Constants.Settings.Add("ShowBasicHealingRegHigh");
            Constants.Settings.Add("ShowBasicHealingRegAverage");
            Constants.Settings.Add("ShowBasicHealingRegMod");
            Constants.Settings.Add("ShowBasicHealingRegModAverage");
            Constants.Settings.Add("ShowBasicHealingCritHit");
            Constants.Settings.Add("ShowBasicHealingCritPercent");
            Constants.Settings.Add("ShowBasicHealingCritLow");
            Constants.Settings.Add("ShowBasicHealingCritHigh");
            Constants.Settings.Add("ShowBasicHealingCritAverage");
            Constants.Settings.Add("ShowBasicHealingCritMod");
            Constants.Settings.Add("ShowBasicHealingCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallHealing");
            Constants.Settings.Add("ShowBasicPercentOfRegularHealing");
            Constants.Settings.Add("ShowBasicPercentOfCriticalHealing");

            Constants.Settings.Add("ShowBasicTotalOverallHealingOverTime");
            Constants.Settings.Add("ShowBasicRegularHealingOverTime");
            Constants.Settings.Add("ShowBasicCriticalHealingOverTime");
            Constants.Settings.Add("ShowBasicTotalHealingOverTimeActionsUsed");
            Constants.Settings.Add("ShowBasicHOTPS");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegHit");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegLow");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegHigh");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegAverage");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegMod");
            Constants.Settings.Add("ShowBasicHealingOverTimeRegModAverage");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritHit");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritPercent");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritLow");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritHigh");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritAverage");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritMod");
            Constants.Settings.Add("ShowBasicHealingOverTimeCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallHealingOverTime");
            Constants.Settings.Add("ShowBasicPercentOfRegularHealingOverTime");
            Constants.Settings.Add("ShowBasicPercentOfCriticalHealingOverTime");

            Constants.Settings.Add("ShowBasicTotalOverallHealingOverHealing");
            Constants.Settings.Add("ShowBasicRegularHealingOverHealing");
            Constants.Settings.Add("ShowBasicCriticalHealingOverHealing");
            Constants.Settings.Add("ShowBasicTotalHealingOverHealingActionsUsed");
            Constants.Settings.Add("ShowBasicHOHPS");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegHit");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegLow");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegHigh");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegAverage");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegMod");
            Constants.Settings.Add("ShowBasicHealingOverHealingRegModAverage");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritHit");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritPercent");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritLow");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritHigh");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritAverage");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritMod");
            Constants.Settings.Add("ShowBasicHealingOverHealingCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallHealingOverHealing");
            Constants.Settings.Add("ShowBasicPercentOfRegularHealingOverHealing");
            Constants.Settings.Add("ShowBasicPercentOfCriticalHealingOverHealing");

            Constants.Settings.Add("ShowBasicTotalOverallHealingMitigated");
            Constants.Settings.Add("ShowBasicRegularHealingMitigated");
            Constants.Settings.Add("ShowBasicCriticalHealingMitigated");
            Constants.Settings.Add("ShowBasicTotalHealingMitigatedActionsUsed");
            Constants.Settings.Add("ShowBasicHMPS");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegHit");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegLow");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegHigh");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegAverage");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegMod");
            Constants.Settings.Add("ShowBasicHealingMitigatedRegModAverage");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritHit");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritPercent");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritLow");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritHigh");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritAverage");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritMod");
            Constants.Settings.Add("ShowBasicHealingMitigatedCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallHealingMitigated");
            Constants.Settings.Add("ShowBasicPercentOfRegularHealingMitigated");
            Constants.Settings.Add("ShowBasicPercentOfCriticalHealingMitigated");

            Constants.Settings.Add("ShowBasicTotalOverallDamageTaken");
            Constants.Settings.Add("ShowBasicRegularDamageTaken");
            Constants.Settings.Add("ShowBasicCriticalDamageTaken");
            Constants.Settings.Add("ShowBasicTotalDamageTakenActionsUsed");
            Constants.Settings.Add("ShowBasicDTPS");
            Constants.Settings.Add("ShowBasicDamageTakenRegHit");
            Constants.Settings.Add("ShowBasicDamageTakenRegMiss");
            Constants.Settings.Add("ShowBasicDamageTakenRegAccuracy");
            Constants.Settings.Add("ShowBasicDamageTakenRegLow");
            Constants.Settings.Add("ShowBasicDamageTakenRegHigh");
            Constants.Settings.Add("ShowBasicDamageTakenRegAverage");
            Constants.Settings.Add("ShowBasicDamageTakenRegMod");
            Constants.Settings.Add("ShowBasicDamageTakenRegModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenCritHit");
            Constants.Settings.Add("ShowBasicDamageTakenCritPercent");
            Constants.Settings.Add("ShowBasicDamageTakenCritLow");
            Constants.Settings.Add("ShowBasicDamageTakenCritHigh");
            Constants.Settings.Add("ShowBasicDamageTakenCritAverage");
            Constants.Settings.Add("ShowBasicDamageTakenCritMod");
            Constants.Settings.Add("ShowBasicDamageTakenCritModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenCounter");
            Constants.Settings.Add("ShowBasicDamageTakenCounterPercent");
            Constants.Settings.Add("ShowBasicDamageTakenCounterMod");
            Constants.Settings.Add("ShowBasicDamageTakenCounterModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenBlock");
            Constants.Settings.Add("ShowBasicDamageTakenBlockPercent");
            Constants.Settings.Add("ShowBasicDamageTakenBlockMod");
            Constants.Settings.Add("ShowBasicDamageTakenBlockModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenParry");
            Constants.Settings.Add("ShowBasicDamageTakenParryPercent");
            Constants.Settings.Add("ShowBasicDamageTakenParryMod");
            Constants.Settings.Add("ShowBasicDamageTakenParryModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenResist");
            Constants.Settings.Add("ShowBasicDamageTakenResistPercent");
            Constants.Settings.Add("ShowBasicDamageTakenResistMod");
            Constants.Settings.Add("ShowBasicDamageTakenResistModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenEvade");
            Constants.Settings.Add("ShowBasicDamageTakenEvadePercent");
            Constants.Settings.Add("ShowBasicDamageTakenEvadeMod");
            Constants.Settings.Add("ShowBasicDamageTakenEvadeModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallDamageTaken");
            Constants.Settings.Add("ShowBasicPercentOfRegularDamageTaken");
            Constants.Settings.Add("ShowBasicPercentOfCriticalDamageTaken");

            Constants.Settings.Add("ShowBasicTotalOverallDamageTakenOverTime");
            Constants.Settings.Add("ShowBasicRegularDamageTakenOverTime");
            Constants.Settings.Add("ShowBasicCriticalDamageTakenOverTime");
            Constants.Settings.Add("ShowBasicTotalDamageTakenOverTimeActionsUsed");
            Constants.Settings.Add("ShowBasicDTOTPS");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegHit");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegMiss");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegAccuracy");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegLow");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegHigh");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegAverage");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegMod");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeRegModAverage");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritHit");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritPercent");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritLow");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritHigh");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritAverage");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritMod");
            Constants.Settings.Add("ShowBasicDamageTakenOverTimeCritModAverage");
            Constants.Settings.Add("ShowBasicPercentOfTotalOverallDamageTakenOverTime");
            Constants.Settings.Add("ShowBasicPercentOfRegularDamageTakenOverTime");
            Constants.Settings.Add("ShowBasicPercentOfCriticalDamageTakenOverTime");

            

            #region Basic Combined Settings

            Constants.Settings.Add("ShowBasicCombinedTotalOverallDamage");
            Constants.Settings.Add("ShowBasicCombinedRegularDamage");
            Constants.Settings.Add("ShowBasicCombinedCriticalDamage");
            Constants.Settings.Add("ShowBasicCombinedTotalDamageActionsUsed");
            Constants.Settings.Add("ShowBasicCombinedDPS");
            Constants.Settings.Add("ShowBasicCombinedDamageRegHit");
            Constants.Settings.Add("ShowBasicCombinedDamageRegMiss");
            Constants.Settings.Add("ShowBasicCombinedDamageRegAccuracy");
            Constants.Settings.Add("ShowBasicCombinedDamageRegLow");
            Constants.Settings.Add("ShowBasicCombinedDamageRegHigh");
            Constants.Settings.Add("ShowBasicCombinedDamageRegAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageRegMod");
            Constants.Settings.Add("ShowBasicCombinedDamageRegModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageCritHit");
            Constants.Settings.Add("ShowBasicCombinedDamageCritPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageCritLow");
            Constants.Settings.Add("ShowBasicCombinedDamageCritHigh");
            Constants.Settings.Add("ShowBasicCombinedDamageCritAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageCritMod");
            Constants.Settings.Add("ShowBasicCombinedDamageCritModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageCounter");
            Constants.Settings.Add("ShowBasicCombinedDamageCounterPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageCounterMod");
            Constants.Settings.Add("ShowBasicCombinedDamageCounterModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageBlock");
            Constants.Settings.Add("ShowBasicCombinedDamageBlockPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageBlockMod");
            Constants.Settings.Add("ShowBasicCombinedDamageBlockModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageParry");
            Constants.Settings.Add("ShowBasicCombinedDamageParryPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageParryMod");
            Constants.Settings.Add("ShowBasicCombinedDamageParryModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageResist");
            Constants.Settings.Add("ShowBasicCombinedDamageResistPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageResistMod");
            Constants.Settings.Add("ShowBasicCombinedDamageResistModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageEvade");
            Constants.Settings.Add("ShowBasicCombinedDamageEvadePercent");
            Constants.Settings.Add("ShowBasicCombinedDamageEvadeMod");
            Constants.Settings.Add("ShowBasicCombinedDamageEvadeModAverage");
            Constants.Settings.Add("ShowBasicCombinedTotalOverallHealing");
            Constants.Settings.Add("ShowBasicCombinedRegularHealing");
            Constants.Settings.Add("ShowBasicCombinedCriticalHealing");
            Constants.Settings.Add("ShowBasicCombinedTotalHealingActionsUsed");
            Constants.Settings.Add("ShowBasicCombinedHPS");
            Constants.Settings.Add("ShowBasicCombinedHealingRegHit");
            Constants.Settings.Add("ShowBasicCombinedHealingRegLow");
            Constants.Settings.Add("ShowBasicCombinedHealingRegHigh");
            Constants.Settings.Add("ShowBasicCombinedHealingRegAverage");
            Constants.Settings.Add("ShowBasicCombinedHealingRegMod");
            Constants.Settings.Add("ShowBasicCombinedHealingRegModAverage");
            Constants.Settings.Add("ShowBasicCombinedHealingCritHit");
            Constants.Settings.Add("ShowBasicCombinedHealingCritPercent");
            Constants.Settings.Add("ShowBasicCombinedHealingCritLow");
            Constants.Settings.Add("ShowBasicCombinedHealingCritHigh");
            Constants.Settings.Add("ShowBasicCombinedHealingCritAverage");
            Constants.Settings.Add("ShowBasicCombinedHealingCritMod");
            Constants.Settings.Add("ShowBasicCombinedHealingCritModAverage");
            Constants.Settings.Add("ShowBasicCombinedTotalOverallDamageTaken");
            Constants.Settings.Add("ShowBasicCombinedRegularDamageTaken");
            Constants.Settings.Add("ShowBasicCombinedCriticalDamageTaken");
            Constants.Settings.Add("ShowBasicCombinedTotalDamageTakenActionsUsed");
            Constants.Settings.Add("ShowBasicCombinedDTPS");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegHit");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegMiss");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegAccuracy");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegLow");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegHigh");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenRegModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritHit");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritLow");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritHigh");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCritModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCounter");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCounterPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCounterMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenCounterModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenBlock");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenBlockPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenBlockMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenBlockModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenParry");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenParryPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenParryMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenParryModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenResist");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenResistPercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenResistMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenResistModAverage");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenEvade");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenEvadePercent");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenEvadeMod");
            Constants.Settings.Add("ShowBasicCombinedDamageTakenEvadeModAverage");

            #endregion

            #region Column Settings

            Constants.Settings.Add("ShowColumnTotalOverallDamage");
            Constants.Settings.Add("ShowColumnRegularDamage");
            Constants.Settings.Add("ShowColumnCriticalDamage");
            Constants.Settings.Add("ShowColumnTotalDamageActionsUsed");
            Constants.Settings.Add("ShowColumnDPS");
            Constants.Settings.Add("ShowColumnDamageRegHit");
            Constants.Settings.Add("ShowColumnDamageRegMiss");
            Constants.Settings.Add("ShowColumnDamageRegAccuracy");
            Constants.Settings.Add("ShowColumnDamageRegLow");
            Constants.Settings.Add("ShowColumnDamageRegHigh");
            Constants.Settings.Add("ShowColumnDamageRegAverage");
            Constants.Settings.Add("ShowColumnDamageRegMod");
            Constants.Settings.Add("ShowColumnDamageRegModAverage");
            Constants.Settings.Add("ShowColumnDamageCritHit");
            Constants.Settings.Add("ShowColumnDamageCritPercent");
            Constants.Settings.Add("ShowColumnDamageCritLow");
            Constants.Settings.Add("ShowColumnDamageCritHigh");
            Constants.Settings.Add("ShowColumnDamageCritAverage");
            Constants.Settings.Add("ShowColumnDamageCritMod");
            Constants.Settings.Add("ShowColumnDamageCritModAverage");
            Constants.Settings.Add("ShowColumnDamageCounter");
            Constants.Settings.Add("ShowColumnDamageCounterPercent");
            Constants.Settings.Add("ShowColumnDamageCounterMod");
            Constants.Settings.Add("ShowColumnDamageCounterModAverage");
            Constants.Settings.Add("ShowColumnDamageBlock");
            Constants.Settings.Add("ShowColumnDamageBlockPercent");
            Constants.Settings.Add("ShowColumnDamageBlockMod");
            Constants.Settings.Add("ShowColumnDamageBlockModAverage");
            Constants.Settings.Add("ShowColumnDamageParry");
            Constants.Settings.Add("ShowColumnDamageParryPercent");
            Constants.Settings.Add("ShowColumnDamageParryMod");
            Constants.Settings.Add("ShowColumnDamageParryModAverage");
            Constants.Settings.Add("ShowColumnDamageResist");
            Constants.Settings.Add("ShowColumnDamageResistPercent");
            Constants.Settings.Add("ShowColumnDamageResistMod");
            Constants.Settings.Add("ShowColumnDamageResistModAverage");
            Constants.Settings.Add("ShowColumnDamageEvade");
            Constants.Settings.Add("ShowColumnDamageEvadePercent");
            Constants.Settings.Add("ShowColumnDamageEvadeMod");
            Constants.Settings.Add("ShowColumnDamageEvadeModAverage");
            Constants.Settings.Add("ShowColumnPercentOfTotalOverallDamage");
            Constants.Settings.Add("ShowColumnPercentOfRegularDamage");
            Constants.Settings.Add("ShowColumnPercentOfCriticalDamage");
            Constants.Settings.Add("ShowColumnTotalOverallHealing");
            Constants.Settings.Add("ShowColumnRegularHealing");
            Constants.Settings.Add("ShowColumnCriticalHealing");
            Constants.Settings.Add("ShowColumnTotalHealingActionsUsed");
            Constants.Settings.Add("ShowColumnHPS");
            Constants.Settings.Add("ShowColumnHealingRegHit");
            Constants.Settings.Add("ShowColumnHealingRegLow");
            Constants.Settings.Add("ShowColumnHealingRegHigh");
            Constants.Settings.Add("ShowColumnHealingRegAverage");
            Constants.Settings.Add("ShowColumnHealingRegMod");
            Constants.Settings.Add("ShowColumnHealingRegModAverage");
            Constants.Settings.Add("ShowColumnHealingCritHit");
            Constants.Settings.Add("ShowColumnHealingCritPercent");
            Constants.Settings.Add("ShowColumnHealingCritLow");
            Constants.Settings.Add("ShowColumnHealingCritHigh");
            Constants.Settings.Add("ShowColumnHealingCritAverage");
            Constants.Settings.Add("ShowColumnHealingCritMod");
            Constants.Settings.Add("ShowColumnHealingCritModAverage");
            Constants.Settings.Add("ShowColumnPercentOfTotalOverallHealing");
            Constants.Settings.Add("ShowColumnPercentOfRegularHealing");
            Constants.Settings.Add("ShowColumnPercentOfCriticalHealing");
            Constants.Settings.Add("ShowColumnTotalOverallDamageTaken");
            Constants.Settings.Add("ShowColumnRegularDamageTaken");
            Constants.Settings.Add("ShowColumnCriticalDamageTaken");
            Constants.Settings.Add("ShowColumnTotalDamageTakenActionsUsed");
            Constants.Settings.Add("ShowColumnDTPS");
            Constants.Settings.Add("ShowColumnDamageTakenRegHit");
            Constants.Settings.Add("ShowColumnDamageTakenRegMiss");
            Constants.Settings.Add("ShowColumnDamageTakenRegAccuracy");
            Constants.Settings.Add("ShowColumnDamageTakenRegLow");
            Constants.Settings.Add("ShowColumnDamageTakenRegHigh");
            Constants.Settings.Add("ShowColumnDamageTakenRegAverage");
            Constants.Settings.Add("ShowColumnDamageTakenRegMod");
            Constants.Settings.Add("ShowColumnDamageTakenRegModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenCritHit");
            Constants.Settings.Add("ShowColumnDamageTakenCritPercent");
            Constants.Settings.Add("ShowColumnDamageTakenCritLow");
            Constants.Settings.Add("ShowColumnDamageTakenCritHigh");
            Constants.Settings.Add("ShowColumnDamageTakenCritAverage");
            Constants.Settings.Add("ShowColumnDamageTakenCritMod");
            Constants.Settings.Add("ShowColumnDamageTakenCritModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenCounter");
            Constants.Settings.Add("ShowColumnDamageTakenCounterPercent");
            Constants.Settings.Add("ShowColumnDamageTakenCounterMod");
            Constants.Settings.Add("ShowColumnDamageTakenCounterModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenBlock");
            Constants.Settings.Add("ShowColumnDamageTakenBlockPercent");
            Constants.Settings.Add("ShowColumnDamageTakenBlockMod");
            Constants.Settings.Add("ShowColumnDamageTakenBlockModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenParry");
            Constants.Settings.Add("ShowColumnDamageTakenParryPercent");
            Constants.Settings.Add("ShowColumnDamageTakenParryMod");
            Constants.Settings.Add("ShowColumnDamageTakenParryModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenResist");
            Constants.Settings.Add("ShowColumnDamageTakenResistPercent");
            Constants.Settings.Add("ShowColumnDamageTakenResistMod");
            Constants.Settings.Add("ShowColumnDamageTakenResistModAverage");
            Constants.Settings.Add("ShowColumnDamageTakenEvade");
            Constants.Settings.Add("ShowColumnDamageTakenEvadePercent");
            Constants.Settings.Add("ShowColumnDamageTakenEvadeMod");
            Constants.Settings.Add("ShowColumnDamageTakenEvadeModAverage");
            Constants.Settings.Add("ShowColumnPercentOfTotalOverallDamageTaken");
            Constants.Settings.Add("ShowColumnPercentOfRegularDamageTaken");
            Constants.Settings.Add("ShowColumnPercentOfCriticalDamageTaken");

            #endregion

            #region Widgets

            Constants.Settings.Add("DPSWidgetWidth");
            Constants.Settings.Add("DPSWidgetHeight");
            Constants.Settings.Add("DPSWidgetSortDirection");
            Constants.Settings.Add("DPSWidgetSortProperty");
            Constants.Settings.Add("DPSWidgetDisplayProperty");
            Constants.Settings.Add("DPSWidgetUIScale");
            Constants.Settings.Add("ShowDPSWidgetOnLoad");
            Constants.Settings.Add("DPSWidgetTop");
            Constants.Settings.Add("DPSWidgetLeft");
            Constants.Settings.Add("DPSVisibility");
            Constants.Settings.Add("HPSWidgetWidth");
            Constants.Settings.Add("HPSWidgetHeight");
            Constants.Settings.Add("HPSWidgetSortDirection");
            Constants.Settings.Add("HPSWidgetSortProperty");
            Constants.Settings.Add("HPSWidgetDisplayProperty");
            Constants.Settings.Add("HPSWidgetUIScale");
            Constants.Settings.Add("ShowHPSWidgetOnLoad");
            Constants.Settings.Add("HPSWidgetTop");
            Constants.Settings.Add("HPSWidgetLeft");
            Constants.Settings.Add("HPSVisibility");
            Constants.Settings.Add("DTPSWidgetWidth");
            Constants.Settings.Add("DTPSWidgetHeight");
            Constants.Settings.Add("DTPSWidgetSortDirection");
            Constants.Settings.Add("DTPSWidgetSortProperty");
            Constants.Settings.Add("DTPSWidgetDisplayProperty");
            Constants.Settings.Add("DTPSWidgetUIScale");
            Constants.Settings.Add("ShowDTPSWidgetOnLoad");
            Constants.Settings.Add("DTPSWidgetTop");
            Constants.Settings.Add("DTPSWidgetLeft");
            Constants.Settings.Add("DTPSVisibility");

            #endregion

            Constants.Settings.Add("ShowJobNameInWidgets");
            Constants.Settings.Add("WidgetClickThroughEnabled");
            Constants.Settings.Add("ShowTitlesOnWidgets");
            Constants.Settings.Add("WidgetOpacity");

            #region Colors

            Constants.Settings.Add("DefaultProgressBarForeground");
            Constants.Settings.Add("PLDProgressBarForeground");
            Constants.Settings.Add("DRGProgressBarForeground");
            Constants.Settings.Add("BLMProgressBarForeground");
            Constants.Settings.Add("WARProgressBarForeground");
            Constants.Settings.Add("WHMProgressBarForeground");
            Constants.Settings.Add("SCHProgressBarForeground");
            Constants.Settings.Add("MNKProgressBarForeground");
            Constants.Settings.Add("BRDProgressBarForeground");
            Constants.Settings.Add("SMNProgressBarForeground");

            #endregion
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        private void SaveSettingsNode() {
            if (Constants.XSettings == null) {
                return;
            }

            IEnumerable<XElement> xElements = Constants.XSettings.Descendants().Elements("Setting");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var setting in Constants.Settings) {
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key").Value == setting);
                var xKey = setting;
                if (Default[xKey] == null) {
                    continue;
                }

                if (element == null) {
                    var xValue = Default[xKey].ToString();
                    List<XValuePair> keyPairList = new List<XValuePair> {
                        new XValuePair {
                            Key = "Value",
                            Value = xValue
                        }
                    };
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Setting", xKey, keyPairList);
                }
                else {
                    XElement xElement = element.Element("Value");
                    if (xElement != null) {
                        xElement.Value = Default[setting].ToString();
                    }
                }
            }
        }
    }
}