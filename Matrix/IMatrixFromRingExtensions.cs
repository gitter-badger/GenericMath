﻿//  *************************************************************
// <copyright file="MatrixFromRingExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for the <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    public static class IMatrixFromRingExtensions
    {
        #region methods

        /// <summary>
        /// Multiply the matrix power times.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The power of the matrix with power.</returns>
        public static IMatrix<T, TStruct> Pow<T, TStruct>(this IMatrix<T, TStruct> matrix, UInt32 power)
            where TStruct : IRing<T>, new()
        {
            var result = matrix.Copy();

            for (UInt32 i = 0; i < power - 1; i++)
            {
                result = result.MultiplyMatrix(matrix);
            }

            return result;
        }

        /// <summary>
        /// Multiply a scalar lambda with the matrix A.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scalar">The scalar.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>Lambda * A.</returns>
        public static IMatrix<T, TStruct> ScalarMultiply<T, TStruct>(this IMatrix<T, TStruct> matrix, T scalar)
            where TStruct : IRing<T>, new()
        {
            var result = matrix.ReturnNewInstanceWithSameDimensions();

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                result[j] = matrix[j].ScalarMultiply(scalar);
            }

            return result;
        }

        /// <summary>
        /// Multiplies the matrix A with matrix B 
        /// A * B.
        /// </summary>
        /// <returns>The resulted matrix.</returns>
        /// <param name="matrix1">The left Matrix.</param>
        /// <param name="matrix2">The right Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IMatrix<T, TStruct> MultiplyMatrix<T, TStruct>(this IMatrix<T, TStruct> matrix1, IMatrix<T, TStruct> matrix2)
            where TStruct : IRing<T>, new()
        {
            if (matrix1.ColumnDimension != matrix2.RowDimension)
                throw new IndexOutOfRangeException("The ColumnDimension of matrix1 needs to be the same like the RowDimension of matrix2");

            var result = matrix1.ReturnNewInstance(matrix1.RowDimension, matrix2.ColumnDimension);

            var baseStructure = new TStruct();

            for (UInt32 i = 0; i < result.RowDimension; i++)
            {
                for (UInt32 j = 0; j < result.ColumnDimension; j++)
                {
                    for (UInt32 k = 0; k < matrix1.ColumnDimension; k++)
                    {
                        result[i, j] = baseStructure.Addition(result[i, j], baseStructure.Multiplication(matrix1[i, k], matrix2[k, j]));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the Matrix A with a vector v.
        /// A * v.
        /// </summary>
        /// <returns>The new vector.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IVector<T, TStruct> MultiplyVector<T, TStruct>(this IMatrix<T, TStruct> matrix, IVector<T, TStruct> vector)
            where TStruct : IRing<T>, new()
        {
            if (matrix.ColumnDimension != vector.Dimension)
                throw new IndexOutOfRangeException("The ColumnDimension of the matrix needs to equal the row dimension of the vector");

            var baseStructure = new TStruct();
            var vect = vector.ReturnNewInstance(matrix.RowDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    vect[i] = baseStructure.Addition(vect[i], baseStructure.Multiplication(matrix[i, j], vector[j]));
                }
            }

            return vect;
        }

        #endregion
    }
}