using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xbim.BCF.XMLNodes;

namespace Xbim.BCF
{
    [XmlType("ProjectExtension")]
    public class ProjectXMLFile
    {
        /// <summary>
        /// ProjectId of the project
        /// </summary>
        public BCFProject Project { get; set; }
        /// <summary>
        /// URI to the extension schema
        /// </summary>
        public String ExtensionSchema { get; set; }
        public bool ShouldSerializeExtensionSchema()
        {
            return !string.IsNullOrEmpty(ExtensionSchema);
        }

        public ProjectXMLFile()
        { }

        public ProjectXMLFile(XDocument xdoc)
        {
            Project = new BCFProject(xdoc.Root.Element("Project"));
            ExtensionSchema = (string)xdoc.Root.Element("ExtensionSchema") ?? "";
        }
    }
}
