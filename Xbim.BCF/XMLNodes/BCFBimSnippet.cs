using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    public class BCFBimSnippet
    {
        private String _snippetType;
        /// <summary>
        /// Type of the Snippet (Predefined list in "extension.xsd")
        /// </summary>
        [XmlAttribute]
        public String SnippetType
        {
            get { return _snippetType; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Validator.RaiseError(nameof(BCFBimSnippet), "SnippetType is mandatory");
                }
                else
                {
                    _snippetType = value;
                }
            }
        }
        private String _reference;
        /// <summary>
        /// URI to BimSnippet. IsExternal=false "..\snippetExample.ifc" (within bcfzip) IsExternal=true "https://.../snippetExample.ifc"
        /// </summary>
        [XmlElement(Order = 1)]
        public String Reference
        {
            get { return _reference; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Validator.RaiseError(nameof(BCFBimSnippet), "Reference is mandatory");
                }
                else
                {
                    _reference = value;
                }
            }
        }
        /// <summary>
        /// URI to BimSnippetSchema (always external)
        /// </summary>
        [XmlElement(Order = 2)]
        public String ReferenceSchema { get; set; }
        public bool ShouldSerializeReferenceSchema()
        {
            return !string.IsNullOrEmpty(ReferenceSchema);
        }
        /// <summary>
        /// Is the BimSnippet external or within the bcfzip. (Default = false).
        /// </summary>
        [XmlAttribute]
        public bool isExternal { get; set; }

        private BCFBimSnippet()//private ctor required by serializer
        { }

        public BCFBimSnippet(String snippetType, String reference)
        {
            SnippetType = snippetType;
            Reference = reference;
        }

        public BCFBimSnippet(XElement node)
        {
            //attributes
            SnippetType = (String)node.Attribute("SnippetType") ?? "";
            isExternal = (bool?)node.Attribute("isExternal") ?? false;

            //nodes
            Reference = (String)node.Element("Reference") ?? "";
            ReferenceSchema = (String)node.Element("ReferenceSchema") ?? "";
        }
    }
}
