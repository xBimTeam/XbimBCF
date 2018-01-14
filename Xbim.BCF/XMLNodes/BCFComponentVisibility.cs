using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("ComponentVisibility")]
    public class BCFComponentVisibility
    {
        [XmlAttribute]
        public bool DefaultVisibility { get; set; }

        [XmlArray("Exceptions")]
        public List<BCFComponent> Exceptions;
        public bool ShouldSerializeExceptions()
        {
            return Exceptions != null && Exceptions.Count > 0;
        }

        public BCFComponentVisibility()
        {
            DefaultVisibility = false;
            Exceptions = new List<BCFComponent>();
        }

        public BCFComponentVisibility(XElement node, string version)
        {
            if (version == "2.0")
            {
                var component = node.Elements("Component").FirstOrDefault();
                if (component == null || !((bool?)component.Attribute("Visible") ?? true))
                {
                    DefaultVisibility = true;
                    Exceptions = new List<BCFComponent>();
                }
                else
                {
                    DefaultVisibility = false;
                    Exceptions = new List<BCFComponent>(node.Elements("Component").Select(n => new BCFComponent(n)));
                }
            }
            else
            {
                DefaultVisibility = (bool?)node.Attribute("DefaultVisibility") ?? false;
                Exceptions = new List<BCFComponent>(node.Element("Exceptions")?.Elements("Component").Select(n => new BCFComponent(n)) ?? Enumerable.Empty<BCFComponent>());
            }
        }
    }
}
