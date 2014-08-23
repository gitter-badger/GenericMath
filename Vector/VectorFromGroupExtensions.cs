﻿//  *************************************************************
// <copyright file="VectorFromGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for the <see cref="Vector{T, TStruct}"/> class.
    /// </summary>
    public static class VectorFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Returns a vector with inverse values of the given vector.
        /// </summary>
        /// <returns>The inverse vector.</returns>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static Vector<T, TStruct> InverseVector<T, TStruct>(this Vector<T, TStruct> vector)
            where TStruct : IGroup<T>, new()
        {
            var vec = new Vector<T, TStruct>(vector.Dimension);

            for (UInt32 i = 0; i < vec.Dimension; i++)
            {
                vec[i] = vector.BaseStructure.Inverse(vector[i]);
            }

            return vec;
        }

        #endregion
    }
}