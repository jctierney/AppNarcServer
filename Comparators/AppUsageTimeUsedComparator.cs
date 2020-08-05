// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Comparators
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using AppTrackerBackendService.Entity;

    /// <summary>
    /// Basic comparator used to compare the time used on the <see cref="AppUsage"/> class.
    /// </summary>
    public class AppUsageTimeUsedComparator : IComparer<AppUsage>
    {
        /// <summary>
        /// Compares two time used to see which is larger.
        /// </summary>
        /// <param name="timeUsed1">The first timeUsed to compuare.</param>
        /// <param name="timeUsed2">The second timeUsed to compare.</param>
        /// <returns>0, 1, or -1 depenfing on the value.</returns>
        public int Compare([AllowNull] AppUsage timeUsed1, [AllowNull] AppUsage timeUsed2)
        {
            return timeUsed2.TimeUsed.CompareTo(timeUsed1.TimeUsed);
        }
    }
}
