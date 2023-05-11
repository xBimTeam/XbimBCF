using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("Project")]
    public class BCFProject
    {
        /// <summary>
        /// ProjectId of the project
        /// </summary>
        [XmlAttribute]
        public String ProjectId { get; set; }
        public bool ShouldSerializeProjectId()
        {
            return !string.IsNullOrEmpty(ProjectId);
        }
        public String Name { get; set; }
        public bool ShouldSerializeName()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public BCFProject()
        { }

        public BCFProject(XElement node)
        {
            if(node == null)
            {
                ProjectId = "";
                Name = "";
                return;
            }
            ProjectId = (string)node.Attribute("ProjectId") ?? "";
            Name = (string)node.Element("Name") ?? "";
        }
    }
}
