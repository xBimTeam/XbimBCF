using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF
{
    public class AttrIDNode
    {
        private Guid _id;
        /// <summary>
        /// Identifying Attribute
        /// </summary>
        [XmlAttribute("Guid")]
        public Guid ID
        {
            get { return _id; }
            set
            {
                if (value == null || value == System.Guid.Empty)
                {
                    throw new ArgumentException(this.GetType().Name + " - identifier is mandatory and must contain a valid Guid value");
                }
                else
                {
                    _id = value;
                }
            }
        }

        private AttrIDNode()
        { }

        public AttrIDNode(Guid id)
        {
            ID = id;
        }

        public AttrIDNode(XElement node)
        {
            ID = (System.Guid?)node.Attribute("Guid") ?? System.Guid.Empty;
        }
    }
}
