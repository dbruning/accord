﻿// Accord Statistics Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2015
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Statistics
{
    using Accord.Math;
    using System;

    // TODO: Rename to Measures
    public static partial class Tools
    {

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// 
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(this double[][] matrix, double[] weights)
        {
            return WeightedMean(matrix, weights, 0);
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// <param name="dimension">
        ///   The dimension along which the means will be calculated. Pass
        ///   0 to compute a row vector containing the mean of each column,
        ///   or 1 to compute a column vector containing the mean of each row.
        ///   Default value is 0.
        /// </param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(double[][] matrix, double[] weights, int dimension = 0)
        {
            int rows = matrix.Length;

            if (rows == 0)
                return new double[0];

            int cols = matrix[0].Length;

            double[] mean;

            if (dimension == 0)
            {
                mean = new double[cols];

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                // for each row
                for (int i = 0; i < rows; i++)
                {
                    double[] row = matrix[i];
                    double w = weights[i];

                    // for each column
                    for (int j = 0; j < cols; j++)
                        mean[j] += row[j] * w;
                }
            }
            else if (dimension == 1)
            {
                mean = new double[rows];

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                // for each row
                for (int j = 0; j < rows; j++)
                {
                    double[] row = matrix[j];
                    double w = weights[j];

                    // for each column
                    for (int i = 0; i < cols; i++)
                        mean[j] += row[i] * w;
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }

            double weightSum = weights.Sum();

            if (weightSum != 0)
                for (int i = 0; i < mean.Length; i++)
                    mean[i] /= weightSum;

            return mean;
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// 
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(this double[,] matrix, double[] weights)
        {
            return WeightedMean(matrix, weights, 0);
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// <param name="dimension">
        ///   The dimension along which the means will be calculated. Pass
        ///   0 to compute a row vector containing the mean of each column,
        ///   or 1 to compute a column vector containing the mean of each row.
        ///   Default value is 0.
        /// </param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(double[,] matrix, double[] weights, int dimension = 0)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            double[] mean;

            if (dimension == 0)
            {
                mean = new double[cols];

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                // for each row
                for (int i = 0; i < rows; i++)
                {
                    double w = weights[i];

                    // for each column
                    for (int j = 0; j < cols; j++)
                        mean[j] += matrix[i, j] * w;
                }
            }
            else if (dimension == 1)
            {
                mean = new double[rows];

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                // for each row
                for (int j = 0; j < rows; j++)
                {
                    double w = weights[j];

                    // for each column
                    for (int i = 0; i < cols; i++)
                        mean[j] += matrix[j, i] * w;
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }


            double weightSum = weights.Sum();

            if (weightSum != 0)
                for (int i = 0; i < mean.Length; i++)
                    mean[i] /= weightSum;

            return mean;
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// 
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(this double[][] matrix, int[] weights)
        {
            return WeightedMean(matrix, weights, 0);
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// <param name="dimension">
        ///   The dimension along which the means will be calculated. Pass
        ///   0 to compute a row vector containing the mean of each column,
        ///   or 1 to compute a column vector containing the mean of each row.
        ///   Default value is 0.
        /// </param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(double[][] matrix, int[] weights, int dimension = 0)
        {
            int rows = matrix.Length;

            if (rows == 0)
                return new double[0];

            int cols = matrix[0].Length;

            double[] mean;

            if (dimension == 0)
            {
                mean = new double[cols];

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                // for each row
                for (int i = 0; i < rows; i++)
                {
                    double[] row = matrix[i];
                    double w = weights[i];

                    // for each column
                    for (int j = 0; j < cols; j++)
                        mean[j] += row[j] * w;
                }
            }
            else if (dimension == 1)
            {
                mean = new double[rows];

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                // for each row
                for (int j = 0; j < rows; j++)
                {
                    double[] row = matrix[j];
                    double w = weights[j];

                    // for each column
                    for (int i = 0; i < cols; i++)
                        mean[j] += row[i] * w;
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }

            double weightSum = weights.Sum();

            if (weightSum != 0)
                for (int i = 0; i < mean.Length; i++)
                    mean[i] /= weightSum;

            return mean;
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// 
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(this double[,] matrix, int[] weights)
        {
            return WeightedMean(matrix, weights, 0);
        }

        /// <summary>
        ///   Calculates the weighted matrix Mean vector.
        /// </summary>
        /// <param name="matrix">A matrix whose means will be calculated.</param>
        /// <param name="weights">A vector containing the importance of each sample in the matrix.</param>
        /// <param name="dimension">
        ///   The dimension along which the means will be calculated. Pass
        ///   0 to compute a row vector containing the mean of each column,
        ///   or 1 to compute a column vector containing the mean of each row.
        ///   Default value is 0.
        /// </param>
        /// <returns>Returns a vector containing the means of the given matrix.</returns>
        /// 
        public static double[] WeightedMean(double[,] matrix, int[] weights, int dimension = 0)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            double[] mean;

            if (dimension == 0)
            {
                mean = new double[cols];

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                // for each row
                for (int i = 0; i < rows; i++)
                {
                    double w = weights[i];

                    // for each column
                    for (int j = 0; j < cols; j++)
                        mean[j] += matrix[i, j] * w;
                }
            }
            else if (dimension == 1)
            {
                mean = new double[rows];

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                // for each row
                for (int j = 0; j < rows; j++)
                {
                    double w = weights[j];

                    // for each column
                    for (int i = 0; i < cols; i++)
                        mean[j] += matrix[j, i] * w;
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }


            double weightSum = weights.Sum();

            if (weightSum != 0)
                for (int i = 0; i < mean.Length; i++)
                    mean[i] /= weightSum;

            return mean;
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[,] matrix, int[] weights)
        {
            return WeightedStandardDeviation(matrix, weights, WeightedMean(matrix, weights));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="means">The mean vector containing already calculated means for each column of the matrix.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[,] matrix, int[] weights, double[] means)
        {
            return Matrix.Sqrt(WeightedVariance(matrix, weights, means));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="means">The mean vector containing already calculated means for each column of the matrix.</param>
        /// <param name="unbiased">
        ///   Pass true to compute the standard deviation using the sample variance.
        ///   Pass false to compute it using the population variance. See remarks
        ///   for more details.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <remarks>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>true</c> will make this method 
        ///     compute the standard deviation σ using the sample variance, which is an unbiased 
        ///     estimator of the true population variance. Setting this parameter to true will
        ///     thus compute σ using the following formula:</para>
        ///     <code>
        ///                           N
        ///        σ² = 1 / (N - 1)  ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>false</c> will assume the given values
        ///     already represent the whole population, and will compute the population variance
        ///     using the formula: </para>
        ///     <code>
        ///                           N
        ///        σ² =   (1 / N)    ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        /// </remarks>
        ///   
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[][] matrix, int[] weights, double[] means, bool unbiased = true)
        {
            return Matrix.Sqrt(WeightedVariance(matrix, weights, means, unbiased));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="unbiased">
        ///   Pass true to compute the standard deviation using the sample variance.
        ///   Pass false to compute it using the population variance. See remarks
        ///   for more details.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <remarks>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>true</c> will make this method 
        ///     compute the standard deviation σ using the sample variance, which is an unbiased 
        ///     estimator of the true population variance. Setting this parameter to true will
        ///     thus compute σ using the following formula:</para>
        ///     <code>
        ///                           N
        ///        σ² = 1 / (N - 1)  ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>false</c> will assume the given values
        ///     already represent the whole population, and will compute the population variance
        ///     using the formula: </para>
        ///     <code>
        ///                           N
        ///        σ² =   (1 / N)    ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        /// </remarks>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[][] matrix, int[] weights, bool unbiased = true)
        {
            return WeightedStandardDeviation(matrix, weights, WeightedMean(matrix, weights), unbiased);
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[,] matrix, double[] weights)
        {
            return WeightedStandardDeviation(matrix, weights, WeightedMean(matrix, weights));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="means">The mean vector containing already calculated means for each column of the matrix.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[,] matrix, double[] weights, double[] means)
        {
            return Matrix.Sqrt(WeightedVariance(matrix, weights, means));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="means">The mean vector containing already calculated means for each column of the matrix.</param>
        /// <param name="unbiased">
        ///   Pass true to compute the standard deviation using the sample variance.
        ///   Pass false to compute it using the population variance. See remarks
        ///   for more details.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        ///   
        /// <remarks>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>true</c> will make this method 
        ///     compute the standard deviation σ using the sample variance, which is an unbiased 
        ///     estimator of the true population variance. Setting this parameter to true will
        ///     thus compute σ using the following formula:</para>
        ///     <code>
        ///                           N
        ///        σ² = 1 / (N - 1)  ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>false</c> will assume the given values
        ///     already represent the whole population, and will compute the population variance
        ///     using the formula: </para>
        ///     <code>
        ///                           N
        ///        σ² =   (1 / N)    ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        /// </remarks>
        ///   
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[][] matrix, double[] weights, double[] means, bool unbiased = true)
        {
            return Matrix.Sqrt(WeightedVariance(matrix, weights, means, unbiased));
        }

        /// <summary>
        ///   Calculates the matrix Standard Deviations vector.
        /// </summary>
        /// 
        /// <param name="matrix">A matrix whose deviations will be calculated.</param>
        /// <param name="unbiased">
        ///   Pass true to compute the standard deviation using the sample variance.
        ///   Pass false to compute it using the population variance. See remarks
        ///   for more details.</param>
        /// <param name="weights">The number of times each sample should be repeated.</param>
        ///   
        /// <remarks>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>true</c> will make this method 
        ///     compute the standard deviation σ using the sample variance, which is an unbiased 
        ///     estimator of the true population variance. Setting this parameter to true will
        ///     thus compute σ using the following formula:</para>
        ///     <code>
        ///                           N
        ///        σ² = 1 / (N - 1)  ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        ///   <para>
        ///     Setting <paramref name="unbiased"/> to <c>false</c> will assume the given values
        ///     already represent the whole population, and will compute the population variance
        ///     using the formula: </para>
        ///     <code>
        ///                           N
        ///        σ² =   (1 / N)    ∑   (x_i − μ)²
        ///                           i=1
        ///     </code>
        /// </remarks>
        /// 
        /// <returns>Returns a vector containing the standard deviations of the given matrix.</returns>
        /// 
        public static double[] WeightedStandardDeviation(this double[][] matrix, double[] weights, bool unbiased = true)
        {
            return WeightedStandardDeviation(matrix, weights, WeightedMean(matrix, weights), unbiased);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="weights">An unit vector containing the importance of each sample
        /// in <see param="values"/>. The sum of this array elements should add up to 1.</param>
        /// <param name="means">The mean value of the given values, if already known.</param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedCovariance(double[][] matrix, double[] weights, double[] means)
        {
            return Tools.WeightedCovariance(matrix, weights, means, dimension: 0);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// <param name="weights">An unit vector containing the importance of each sample
        /// in <see param="values"/>. The sum of this array elements should add up to 1.</param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedCovariance(double[][] matrix, double[] weights, int dimension = 0)
        {
            double[] mean = Tools.WeightedMean(matrix, weights, dimension);
            return Tools.WeightedCovariance(matrix, weights, mean, dimension);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedCovariance(double[][] matrix, int[] weights, int dimension = 0)
        {
            double[] mean = Tools.WeightedMean(matrix, weights, dimension);
            return Tools.WeightedCovariance(matrix, weights, mean, dimension);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="weights">An unit vector containing the importance of each sample
        /// in <see param="values"/>. The sum of this array elements should add up to 1.</param>
        /// <param name="means">The mean value of the given values, if already known.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedCovariance(double[][] matrix, double[] weights, double[] means, int dimension)
        {
            double s1 = 0, s2 = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                s1 += weights[i];
                s2 += weights[i] * weights[i];
            }

            double factor = s1 / (s1 * s1 - s2);
            return WeightedScatter(matrix, weights, means, factor, dimension);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="means">The mean value of the given values, if already known.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedCovariance(double[][] matrix, int[] weights, double[] means, int dimension)
        {
            double s1 = 0, s2 = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                s1 += weights[i];
                s2 += weights[i] * weights[i];
            }

            double factor = s1 / (s1 * s1 - s2);
            return WeightedScatter(matrix, weights, means, factor, dimension);
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="weights">An unit vector containing the importance of each sample
        /// in <see param="values"/>. The sum of this array elements should add up to 1.</param>
        /// <param name="means">The mean value of the given values, if already known.</param>
        /// <param name="factor">A real number to multiply each member of the matrix.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedScatter(double[][] matrix, double[] weights,
            double[] means, double factor, int dimension)
        {
            int rows = matrix.Length;
            if (rows == 0)
                return new double[0, 0];
            int cols = matrix[0].Length;

            double[,] cov;

            if (dimension == 0)
            {
                if (means.Length != cols)
                {
                    throw new DimensionMismatchException("means",
                        "Length of the mean vector should equal the number of columns.");
                }

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                cov = new double[cols, cols];
                for (int i = 0; i < cols; i++)
                {
                    for (int j = i; j < cols; j++)
                    {
                        double s = 0.0;
                        for (int k = 0; k < rows; k++)
                            s += weights[k] * (matrix[k][j] - means[j]) * (matrix[k][i] - means[i]);
                        cov[i, j] = s * factor;
                        cov[j, i] = s * factor;
                    }
                }
            }
            else if (dimension == 1)
            {
                if (means.Length != rows)
                {
                    throw new DimensionMismatchException("means",
                        "Length of the mean vector should equal the number of rows.");
                }

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                cov = new double[rows, rows];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = i; j < rows; j++)
                    {
                        double s = 0.0;
                        for (int k = 0; k < cols; k++)
                            s += weights[k] * (matrix[j][k] - means[j]) * (matrix[i][k] - means[i]);
                        cov[i, j] = s * factor;
                        cov[j, i] = s * factor;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }

            return cov;
        }

        /// <summary>
        ///   Calculates the scatter matrix of a sample matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   By dividing the Scatter matrix by the sample size, we get the population
        ///   Covariance matrix. By dividing by the sample size minus one, we get the
        ///   sample Covariance matrix.
        /// </remarks>
        /// 
        /// <param name="weights">The number of times each sample should be repeated.</param>
        /// <param name="matrix">A number multi-dimensional array containing the matrix values.</param>
        /// <param name="means">The mean value of the given values, if already known.</param>
        /// <param name="factor">A real number to multiply each member of the matrix.</param>
        /// <param name="dimension">
        ///   Pass 0 to if mean vector is a row vector, 1 otherwise. Default value is 0.
        /// </param>
        /// 
        /// <returns>The covariance matrix.</returns>
        /// 
        public static double[,] WeightedScatter(double[][] matrix, int[] weights,
            double[] means, double factor, int dimension)
        {
            int rows = matrix.Length;
            if (rows == 0)
                return new double[0, 0];
            int cols = matrix[0].Length;

            double[,] cov;

            if (dimension == 0)
            {
                if (means.Length != cols)
                {
                    throw new DimensionMismatchException("means",
                        "Length of the mean vector should equal the number of columns.");
                }

                if (rows != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of rows and weights must match.");
                }

                cov = new double[cols, cols];
                for (int i = 0; i < cols; i++)
                {
                    for (int j = i; j < cols; j++)
                    {
                        double s = 0.0;
                        for (int k = 0; k < rows; k++)
                            s += weights[k] * (matrix[k][j] - means[j]) * (matrix[k][i] - means[i]);
                        cov[i, j] = s * factor;
                        cov[j, i] = s * factor;
                    }
                }
            }
            else if (dimension == 1)
            {
                if (means.Length != rows)
                {
                    throw new DimensionMismatchException("means",
                        "Length of the mean vector should equal the number of rows.");
                }

                if (cols != weights.Length)
                {
                    throw new DimensionMismatchException("weights",
                        "The number of columns and weights must match.");
                }

                cov = new double[rows, rows];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = i; j < rows; j++)
                    {
                        double s = 0.0;
                        for (int k = 0; k < cols; k++)
                            s += weights[k] * (matrix[j][k] - means[j]) * (matrix[i][k] - means[i]);
                        cov[i, j] = s * factor;
                        cov[j, i] = s * factor;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid dimension.", "dimension");
            }

            return cov;
        }

    }
}

