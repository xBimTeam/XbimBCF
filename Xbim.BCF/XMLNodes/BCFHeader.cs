using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    public class BCFHeader
    {
        [XmlElement("File")]
        public List<BCFFile> Files { get; set; }

        public BCFHeader()
        {
            Files = new List<BCFFile>();
        }

        public BCFHeader(XElement node)
        {
            Files = new List<BCFFile>();

            foreach (var file in node.Elements("File"))
            {
                Files.Add(new BCFFile(file));
            }
        }
    }
}
