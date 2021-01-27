using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("Comment")]
    public class BCFComment
    {
        private Guid _guid;
        /// <summary>
        /// Unique Identifier for this comment
        /// </summary>
        [XmlAttribute]
        public Guid Guid
        {
            get { return _guid; }
            set
            {
                if (value == System.Guid.Empty)
                {
                    Validator.RaiseError(nameof(BCFComment), "Guid attribute is mandatory and must contain a valid Guid value");
                }
                else
                {
                    _guid = value;
                }
            }
        }
        private DateTime _date;
        /// <summary>
        /// Date of the comment
        /// </summary>
        [XmlElement(Order = 1)]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == null)
                {
                    Validator.RaiseError(nameof(BCFComment), "Date is mandatory");
                }
                else
                {
                    _date = value;
                }
            }
        }
        private String _author;
        /// <summary>
        /// Comment author
        /// </summary>
        [XmlElement(Order = 2)]
        public String Author
        {
            get { return _author; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Validator.RaiseError(nameof(BCFComment), "Author is mandatory");
                }
                else
                {
                    _author = value;
                }
            }
        }
        /// <summary>
        /// The comment text
        /// </summary>
        [XmlElement(Order = 3)]
        public String Comment { get; set; }
        /// <summary>
        /// Reference back to Viewpoint
        /// </summary>
        [XmlElement(Order = 4)]
        public AttrIDNode Viewpoint { get; set; }
        public bool ShouldSerializeViewpoint()
        {
            return Viewpoint != null;
        }
        /// <summary>
        /// The date when comment was modified
        /// </summary>
        [XmlElement(Order = 5)]
        public DateTime? ModifiedDate { get; set; }
        public bool ShouldSerializeModifiedDate()
        {
            return ModifiedDate != null;
        }
        /// <summary>
        /// The author who modified the comment
        /// </summary>
        [XmlElement(Order = 6)]
        public String ModifiedAuthor { get; set; }
        public bool ShouldSerializeModifiedAuthor()
        {
            return !string.IsNullOrEmpty(ModifiedAuthor);
        }

        //Private parameterless constructor required by Serializer
        private BCFComment()
        { }

        public BCFComment(Guid id, DateTime date, String author, String comment)
        {
            Date = date;
            Author = author;
            Comment = comment;
            Guid = id;
        }

        public BCFComment(XElement node)
        {
            this.Guid = (System.Guid?)node.Attribute("Guid") ?? System.Guid.Empty;
            Date = (DateTime?)node.Element("Date") ?? DateTime.MinValue;
            Author = (String)node.Element("Author") ?? "";
            Comment = (String)node.Element("Comment") ?? "";
            ModifiedDate = (DateTime?)node.Element("ModifiedDate") ?? null;
            ModifiedAuthor = (String)node.Element("ModifiedAuthor") ?? "";

            var viewp = node.Elements("Viewpoint").FirstOrDefault();
            if (viewp != null)
            {
                Viewpoint = new AttrIDNode(node.Element("Viewpoint"));
            }
        }
    }
}
