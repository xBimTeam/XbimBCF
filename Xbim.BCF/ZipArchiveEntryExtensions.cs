using System;
using System.IO.Compression;

namespace Xbim.BCF
{
    public static class ZipArchiveEntryExtensions
    {
        public static Guid ExtractGuidFolderName(this ZipArchiveEntry entry)
        {
            Guid rtn;
            if (Guid.TryParse(entry.FullName.Substring(entry.FullName.LastIndexOf('/') - 36, 36), out rtn))
            {
                return rtn;
            }
            else
            {
                throw new ArgumentException("Topic folder name must be a valid Guid");
            }
        }
        
        public static string ExtractFileName(this ZipArchiveEntry entry)
        {
            string snapshotName = entry.FullName.Substring(entry.FullName.LastIndexOf('/') + 1);
            if (!string.IsNullOrWhiteSpace(snapshotName))
            {
                return snapshotName;
            }
            else
            {
                throw new ArgumentException("Invalid snapshot path");
            }
        }
    }
}
