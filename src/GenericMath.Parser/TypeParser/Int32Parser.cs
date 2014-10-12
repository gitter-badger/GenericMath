﻿//  *************************************************************
// <copyright file="Int32Parser.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Parser
{
    using System;

    /// <summary>
    /// Parser for integer values.
    /// </summary>
    public class Int32Parser : IParser<Int32>
    {
        #region ITypeParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>The parsed integer value.</returns>
        /// <exception cref="InvalidCastException">Thrown when the cast did not work.</exception>
        public Int32 Parse(String inputString)
        {
            Int32 value;

            if (!Int32.TryParse(inputString, out value))
            {
                throw new InvalidCastException();
            }
                
            return value;
        }

        #endregion
    }
}