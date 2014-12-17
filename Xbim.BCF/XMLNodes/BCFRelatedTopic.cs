using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    public class BCFRelatedTopic
    {
        [XmlAttribute("Guid")]
        public Guid ID { get; set; }
        public bool ShouldSerializeID()
        {
            return ID != null && ID != Guid.Empty;
        }

        public BCFRelatedTopic()
        { }

        public BCFRelatedTopic(XElement node)
        {
            ID = Guid.Parse((String)node.Attribute("Guid") ?? "");
        }
    }
}
