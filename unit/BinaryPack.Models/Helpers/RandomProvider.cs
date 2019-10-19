﻿using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BinaryPack.Models.Helpers
{
    /// <summary>
    /// A helper <see langword="class"/> with helper methods to create random values
    /// </summary>
    internal static class RandomProvider
    {
        /// <summary>
        /// Singleton <see cref="System.Random"/> instance (not thread safe)
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Creates a new random <see cref="bool"/> value
        /// </summary>
        [Pure]
        public static bool NextBool() => Random.Next() % 2 == 1;

        /// <summary>
        /// Creates a new random <see cref="int"/> value
        /// </summary>
        [Pure]
        public static int NextInt() => Random.Next();

        /// <summary>
        /// Creates a new random <see cref="DateTime"/> value
        /// </summary>
        /// <returns></returns>
        [Pure]
        public static DateTime NextDateTime()
        {
            int max = (DateTime.MaxValue - DateTime.MinValue).Milliseconds - 1000;
            return DateTime.MinValue.AddMilliseconds(Random.Next(500, max));
        }

        private const string Characters = " !\"#$&\'()*+,-./0123456789:;<=>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]_abcdefghijklmnopqrstuvwxyz{}'";

        /// <summary>
        /// Creates a new random <see langword="string"/> with a specified length
        /// </summary>
        /// <param name="length">The length of the new <see langword="string"/> to create</param>
        [Pure]
        public static string NextString(int length) => new string((
            from _ in Enumerable.Range(0, length)
            let i = Random.Next(0, Characters.Length)
            select Characters[i]).ToArray());
    }
}