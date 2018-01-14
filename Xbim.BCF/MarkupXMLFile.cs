using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xbim.BCF.XMLNodes;

namespace Xbim.BCF
{
    [XmlType("Markup")]
    public class MarkupXMLFile
    {
        [XmlElement(Order = 1)]
        public BCFHeader Header { get; set; }
        [XmlElement(Order = 2)]
        public BCFTopic Topic { get; set; }
        [XmlElement(ElementName = "Comment", Order = 3)]
        public List<BCFComment> Comments;
        [XmlElement(Order = 4)]
        public List<BCFViewpoint> Viewpoints;

        public MarkupXMLFile()
        {
            Comments = new List<BCFComment>();
            Viewpoints = new List<BCFViewpoint>();
        }

        public MarkupXMLFile(XDocument xdoc, string version)
        {
            Comments = new List<BCFComment>();
            Viewpoints = new List<BCFViewpoint>();

            Header = new BCFHeader(xdoc.Root.Element("Header"));
            Topic = new BCFTopic(xdoc.Root.Element("Topic"), version);
            foreach (var comment in (xdoc.Root.Elements("Comment")))
            {
                Comments.Add(new BCFComment(comment));
            }
            foreach (var v in xdoc.Root.Elements("Viewpoints"))
            {
                Viewpoints.Add(new BCFViewpoint(v));
            }
        }
    }
}
