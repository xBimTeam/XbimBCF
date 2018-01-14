using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("Component")]
    public class BCFComponent
    {
        private String _ifcGuid;
        /// <summary>
        /// The id of the component selected in a BIM tool
        /// </summary>
        [XmlAttribute]
        public String IfcGuid
        {
            get { return _ifcGuid; }
            set
            {
                if (value.Length == 22)
                {
                    _ifcGuid = value;
                }
                else
                {
                    throw new ArgumentException(this.GetType().Name + " - IfcGuid - IfcGuid must be 22 chars exactly");
                }
            }
        }
        public bool ShouldSerializeIfcGuid()
        {
            return !string.IsNullOrEmpty(IfcGuid);
        }
        /// <summary>
        /// Name of the system in which the component is originated
        /// </summary>
        [XmlElement(Order = 1)]
        public String OriginatingSystem { get; set; }
        public bool ShouldSerializeOriginatingSystem()
        {
            return !string.IsNullOrEmpty(OriginatingSystem);
        }
        /// <summary>
        /// System specific identifier of the component in the originating BIM tool
        /// </summary>
        [XmlElement(Order = 2)]
        public String AuthoringToolId { get; set; }
        public bool ShouldSerializeAuthoringToolId()
        {
            return !string.IsNullOrEmpty(AuthoringToolId);
        }

        public BCFComponent()
        { }

        public BCFComponent(XElement node)
        {
            IfcGuid = (String)node.Attribute("IfcGuid") ?? "";
            OriginatingSystem = (String)node.Element("OriginatingSystem") ?? "";
            AuthoringToolId = (String)node.Element("AuthoringToolId") ?? "";
        }
    }
}
