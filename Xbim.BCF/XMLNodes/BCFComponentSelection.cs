using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("ComponentSelection")]
    public class BCFComponentSelection
    {
        [XmlElement(ElementName = "Component")]
        public List<BCFComponent> Components;
        public bool ShouldSerializeComponent()
        {
            return Components != null && Components.Count > 0;
        }

        public BCFComponentSelection()
        {
            Components = new List<BCFComponent>();
        }

        public BCFComponentSelection(XElement node)
        {
            Components = new List<BCFComponent>(node.Elements("Component").Select(c => new BCFComponent(c)));
        }
    }
}
