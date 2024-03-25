using System;
using System.IO;
using System.Linq;

namespace System2.IO
{
    public static class DirectoryExtensions
    {
        public static DirectoryInfo[] FindDirectories(
            this DirectoryInfo searchingDirectory,
            Func<DirectoryInfo, bool> predicate
        )
        {
            return Directory
                .GetDirectories(searchingDirectory.FullName)
                .Select(directoryName => new DirectoryInfo(
                    Path.Combine(searchingDirectory.FullName, directoryName)
                ))
                .Where(predicate)
                .ToArray();
        }

        public static DirectoryInfo FindDirectoryByName(
            this DirectoryInfo searchingDirectory,
            string directoryName,
            bool caseSensitive = false
        )
        {
            return searchingDirectory.FindDirectories(directory =>
                caseSensitive
                    ? directory.Name == directoryName
                    : directory.Name.ToLower().Equals(directoryName.ToLower())
            )[0];
        }

        public static DirectoryInfo[] RecursiveSearchForDirectory(
            this DirectoryInfo rootSearchDirectory,
            Func<DirectoryInfo, bool> predicate
        )
        {
            DirectoryInfo[] foundDirectories = rootSearchDirectory.FindDirectories(predicate);
            return foundDirectories
                .SelectMany(directory => directory.RecursiveSearchForDirectory(predicate))
                .Concat(foundDirectories)
                .ToArray();
        }
    }
}
