using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF
{
    [XmlType("Version")]
    public class VersionXMLFile
    {
        public String DetailedVersion { get; set; }
        public bool ShouldSerializeDetailedVersion()
        {
            return !string.IsNullOrEmpty(DetailedVersion);
        }

        private String _versionId;
        [XmlAttribute]
        public String VersionId
        {
            get { return _versionId; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Validator.RaiseError(nameof(VersionXMLFile), "VersionId is mandatory");
                }
                else
                {
                    _versionId = value;
                }
            }
        }

        private VersionXMLFile()
        { }

        public VersionXMLFile(String versionID)
        {
            VersionId = versionID;
        }

        public VersionXMLFile(XDocument xdoc)
        {
            VersionId = (string)xdoc.Root.Attribute("VersionId") ?? "";
            DetailedVersion = (string)xdoc.Root.Element("DetailedVersion") ?? "";
        }
    }
}
