﻿//  *************************************************************
// <copyright file="IPolynomialFromMonoidExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra.Contracts
{
	using System;

	using GenericMath.Base;

	/// <summary>
	/// Extensions methods for the <see cref="Polynomial{T, TStruct}"/> class.
	/// TStruct needs to be of type <see cref="IMonoid{T}"/>
	/// </summary>
	public static class IPolynomialFromMonoidExtensions
	{
		#region methods

		/// <summary>
		/// Add the specified polynomial1 and polynomial2.
		/// </summary>
		/// <param name="polynomial1">The left polynomial.</param>
		/// <param name="polynomial2">The right polynomial.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TMonoid">The underlying structure.</typeparam>
		/// <returns>A new polynomial as a sum of polynomial1 and polynomial2.</returns>
		public static IPolynomial<T, TMonoid> Add<T, TMonoid> (
			this IPolynomial<T, TMonoid> polynomial1,
			IPolynomial<T, TMonoid> polynomial2)
            where TMonoid : IMonoid<T>, new()
		{
			var poly1HasMaxDegree = polynomial1.Degree >= polynomial2.Degree;

			var polyWithMaxDegree = poly1HasMaxDegree ? polynomial1 : polynomial2;
			var polyWithLowerOrEqualMaxDegree = poly1HasMaxDegree ? polynomial2 : polynomial1;

			var poly = polyWithMaxDegree.ReturnNewInstance(polyWithMaxDegree.Degree);
			var monoid = new TMonoid ();

			for (UInt32 i = 0; i < polyWithMaxDegree.Degree + 1; i++) {
				// TODO implement left and right elements (do not necessary need to be commutative)
				var otherDegreeValid = polyWithLowerOrEqualMaxDegree.Degree >= polyWithMaxDegree.Degree;
				poly [i] = monoid.Addition(
					polyWithMaxDegree [i],
					otherDegreeValid ? polyWithLowerOrEqualMaxDegree [i] : monoid.Zero);
			}

			return poly;
		}

		#endregion
	}
}