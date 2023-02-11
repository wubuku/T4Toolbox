namespace T4Toolbox.EnvDteLites
{
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

            var relativeTo_dir = Path.GetDirectoryName(fromFile);
            var path_dir = Path.GetDirectoryName(toFile);
            //#if NET6_0 
            var relativePath_Dir = Path.GetRelativePath(relativeTo_dir, path_dir);
            return Path.Combine(relativePath_Dir, Path.GetFileName(toFile));
            //#else 
            //throw new NotImplementedException("GetRelativePath()");
            //#endif
        }
    }
}