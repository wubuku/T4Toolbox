﻿// <copyright file="FileMethods.cs" company="Oleg Sych">
//  Copyright © Oleg Sych. All Rights Reserved.
// </copyright>

namespace T4Toolbox
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// File access utility methods.
    /// </summary>
    public static class FileMethods
    {
        /// <summary>
        /// Converts absolute path to a relative path.
        /// </summary>
        /// <param name="fromFile">
        /// Full path to the base file.
        /// </param>
        /// <param name="toFile">
        /// Full path to the target file.
        /// </param>
        /// <returns>
        /// Relative path to the specified file.
        /// </returns>
        public static string GetRelativePath(string fromFile, string toFile)
        {
            // var relativePath = new StringBuilder(260);
            // if (!NativeMethods.PathRelativePathTo(relativePath, fromFile, 0, toFile, 0))
            // {
            //     throw new ArgumentException(
            //         string.Format(
            //             CultureInfo.CurrentCulture,
            //             "Cannot convert '{0}' to a path relative to the location of '{1}'.",
            //             toFile,
            //             fromFile));
            // }

            // return relativePath.ToString();
            var relativeToDir = Path.GetDirectoryName(toFile);
            var fromDir = Path.GetDirectoryName(fromFile);
            #if NET6_0 
            var dirRel = Path.GetRelativePath(relativeToDir, fromDir);
            return Path.Combine(dirRel, Path.GetFileName(fromFile));
            #else 
            throw new NotImplementedException("GetRelativePath()");
            #endif
        }
    }
}
