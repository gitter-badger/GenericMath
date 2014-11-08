﻿//  *************************************************************
// <copyright file="RegexAdapter.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Common
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Adapter for the <see cref="Regex"/> class.
    /// </summary>
    public class RegexAdapter : IRegex
    {
        #region IRegex implementation

        /// <summary>
        /// Split the specified input at the specified pattern.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>An array with the split string.</returns>
        public String[] Split(String input, String pattern)
        {
            return Regex.Split(input, pattern);
        }

        /// <summary>
        /// Replace at the specified input the pattern with the replacement.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns>A string with the replaced characters.</returns>
        public String Replace(String input, String pattern, String replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        #endregion
    }
}