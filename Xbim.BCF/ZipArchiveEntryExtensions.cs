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
    }
}
