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
        private String _color;
        /// <summary>
        /// Color of the component. This can be used to provide special highlighting of components in the viewpoint. The color is given in ARGB format
        /// </summary>
        [XmlAttribute]
        public String Color
        {
            get { return _color; }
            set
            {
                if (!String.IsNullOrEmpty(value) && IsHex(value))
                {
                    _color = value;
                }
                else
                {
                    throw new ArgumentException(this.GetType().Name + " - Color - must be a valid hex sequence");
                }
            }
        }
        public bool ShouldSerializeColor()
        {
            return !string.IsNullOrEmpty(Color);
        }
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
        /// <summary>
        /// This flag is true if the component is actually involved in the topic. If the flag is false, the component is involved as reference
        /// </summary>
        [XmlAttribute]
        public bool Selected { get; set; }
        /// <summary>
        /// This flag is true when the component is visible in the visualization. 
        /// By setting this false, you can hide components that would prevent seeing the topic from the camera position and angle of the viewpoint.
        /// Default is true.
        /// </summary>
        [XmlAttribute]
        public bool Visible { get; set; }

        public BCFComponent()
        { }

        public BCFComponent(XElement node)
        {
            IfcGuid = (String)node.Attribute("IfcGuid") ?? "";
            Visible = (bool?)node.Attribute("Visible") ?? true;
            Selected = (bool?)node.Attribute("Selected") ?? false;
            Color = (String)node.Attribute("Color") ?? "";
            OriginatingSystem = (String)node.Element("OriginatingSystem") ?? "";
            AuthoringToolId = (String)node.Element("AuthoringToolId") ?? "";
        }

        private bool IsHex(IEnumerable<char> chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
        }
    }
}
