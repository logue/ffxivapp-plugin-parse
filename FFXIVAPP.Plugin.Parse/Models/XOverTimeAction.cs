﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XOverTimeAction.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   XOverTimeAction.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Parse.Models {
    public class XOverTimeAction {
        public int ActionOverTimePotency { get; set; }

        public int ActionPotency { get; set; }

        public int Duration { get; set; }

        public bool HasNoInitialResult { get; set; }
    }
}