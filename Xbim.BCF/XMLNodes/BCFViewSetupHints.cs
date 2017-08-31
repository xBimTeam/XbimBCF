using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("ViewSetupHints")]
    public class BCFViewSetupHints
    {
        [XmlAttribute]
        public bool SpacesVisible { get; set; }

        [XmlAttribute]
        public bool SpaceBoundariesVisible { get; set; }

        [XmlAttribute]
        public bool OpeningsVisible { get; set; }

        public BCFViewSetupHints()
        { }

        public BCFViewSetupHints(XElement node)
        {
            SpacesVisible = (bool?)node.Attribute("SpacesVisible") ?? false;
            SpaceBoundariesVisible = (bool?)node.Attribute("SpaceBoundariesVisible") ?? false;
            OpeningsVisible = (bool?)node.Attribute("OpeningsVisible") ?? false;
        }
    }
}
