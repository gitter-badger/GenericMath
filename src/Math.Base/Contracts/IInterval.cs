﻿//  *************************************************************
// <copyright file="IInterval.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    using Math.Base;

    /// <summary>
    /// Interface for defining intervals for a set T.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    public interface IInterval<T, TStructure>
        where T : IComparable
        where TStructure : IStructure<T>, new()
    {
        /// <summary>
        /// Gets the max element.
        /// </summary>
        /// <value>The max element.</value>
        T MaxElement { get; }

        /// <summary>
        /// Gets the minimum element.
        /// </summary>
        /// <value>The minimum element.</value>
        T MinElement { get; }

        /// <summary>
        /// Determines whether this element is within interval.
        /// </summary>
        /// <returns><c>true</c> if the element lies in the interval; otherwise, <c>false</c>.</returns>
        /// <param name="elementToCheck">Element to check.</param>
        Boolean IsinInterval(T elementToCheck);
    }
}