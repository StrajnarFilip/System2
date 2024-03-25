using System;
using System.IO;
using System.Linq;

namespace System2.IO
{
    public static class DirectoryExtensions
    {
        public static DirectoryInfo FindDirectory(
            this DirectoryInfo searchingDirectory,
            Func<DirectoryInfo, bool> predicate
        )
        {
            return Directory
                .GetDirectories(searchingDirectory.FullName)
                .Select(directoryName => new DirectoryInfo(
                    Path.Combine(searchingDirectory.FullName, directoryName)
                ))
                .First(predicate);
        }

        public static DirectoryInfo FindDirectoryByName(
            this DirectoryInfo searchingDirectory,
            string directoryName,
            bool caseSensitive = false
        )
        {
            return searchingDirectory.FindDirectory(directory =>
                caseSensitive
                    ? directory.Name == directoryName
                    : directory.Name.ToLower().Equals(directoryName.ToLower())
            );
        }
    }
}
