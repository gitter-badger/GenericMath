﻿//  *************************************************************
// <copyright file="PolynomialParser.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

using System;
using System.Collections.Generic;

using GenericMath.Base.Contracts;
using GenericMath.Common;
using GenericMath.LinearAlgebra;
using System.Text.RegularExpressions;

namespace GenericMath.Parser
{
    /// <summary>
    /// Polynomial parser.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    /// <typeparam name="TParser">The parser for the set.</typeparam>
    public class PolynomialParser<T, TStruct, TParser> : IParser<Polynomial<T, TStruct>>
        where TStruct : IStructure, new()
        where TParser : IParser<T>, new()
    {
        #region fields

        private readonly TParser _typeParser = new TParser();
        private List<T> _entries = new List<T>();

        #endregion

        #region IParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <example>
        /// Input: 2, 4, 5
        /// Will be parsed to 5x^2+4x+2
        /// </example>
        /// <param name="inputString">Input string.</param>
        /// <returns>A new polynomial with values from the string.</returns>
        public Polynomial<T, TStruct> Parse (String inputString)
        {
            var matchArray = Regex.Split(inputString, ",");

            if (matchArray.Length <= 0) {
                throw new NotSupportedException("No match");
            }

            var tuple = new Polynomial<T, TStruct>((UInt32)matchArray.Length - 1);

            for (UInt32 i = 0; i < matchArray.Length; i++) {
                tuple[i] = this._typeParser.Parse(matchArray[i]);
            }

            return tuple;
        }

        #endregion
    }
}