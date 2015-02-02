using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("Comment")]
    public class BCFComment
    {
        /// <summary>
        /// A free text status. The options for this can be agreed, for example, in a project.
        /// </summary>
        [XmlElement(Order = 1)]
        public String VerbalStatus { get; set; }
        public bool ShouldSerializeVerbalStatus()
        {
            return !string.IsNullOrEmpty(VerbalStatus);
        }
        private Guid _guid;
        /// <summary>
        /// Unique Identifier for this topic
        /// </summary>
        [XmlAttribute]
        public Guid Guid
        {
            get { return _guid; }
            set
            {
                if (value == null || value == System.Guid.Empty)
                {
                    throw new ArgumentException(this.GetType().Name + " - Guid attribute is mandatory and must contain a valid Guid value");
                }
                else
                {
                    _guid = value;
                }
            }
        }
        private String _status;
        /// <summary>
        /// Status of the comment / topic (Predefined list in “extension.xsd”)
        /// </summary>
        [XmlElement(Order = 2)]
        public String Status
        {
            get { return _status; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(this.GetType().Name + " - Status is mandatory");
                }
                else
                {
                    _status = value;
                }
            }
        }
        private DateTime _date;
        /// <summary>
        /// Date of the comment
        /// </summary>
        [XmlElement(Order = 3)]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == null || value == DateTime.MinValue)
                {
                    throw new ArgumentException(this.GetType().Name + " - Date is mandatory");
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
        [XmlElement(Order = 4)]
        public String Author
        {
            get { return _author; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(this.GetType().Name + " - Author is mandatory");
                }
                else
                {
                    _author = value;
                }
            }
        }
        private String _comment;
        /// <summary>
        /// The comment text
        /// </summary>
        [XmlElement(Order = 5)]
        public String Comment
        {
            get { return _comment; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(this.GetType().Name + " - Comment text is mandatory");
                }
                else
                {
                    _comment = value;
                }
            }
        }
        private AttrIDNode _topic;
        /// <summary>
        /// Back reference to the topic 
        /// </summary>
        [XmlElement(Order = 6)]
        public AttrIDNode Topic
        {
            get { return _topic; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(this.GetType().Name + " - Topic is mandatory and must contain a valid Guid value");
                }
                else
                {
                    _topic = value;
                }
            }
        }
        /// <summary>
        /// Reference back to Viewpoint
        /// </summary>
        [XmlElement(Order = 7)]
        public AttrIDNode Viewpoint { get; set; }
        public bool ShouldSerializeViewpoint()
        {
            return Viewpoint != null;
        }
        /// <summary>
        /// Guid of the comment to which this comment is a reply
        /// </summary>
        [XmlElement(Order = 8)]
        public AttrIDNode ReplyToComment { get; set; }
        public bool ShouldSerializeReplyToComment()
        {
            return ReplyToComment != null;
        }
        /// <summary>
        /// The date when comment was modified
        /// </summary>
        [XmlElement(Order = 9)]
        public DateTime? ModifiedDate { get; set; }
        public bool ShouldSerializeModifiedDate()
        {
            return ModifiedDate != null;
        }
        /// <summary>
        /// The author who modified the comment
        /// </summary>
        [XmlElement(Order = 10)]
        public String ModifiedAuthor { get; set; }
        public bool ShouldSerializeModifiedAuthor()
        {
            return !string.IsNullOrEmpty(ModifiedAuthor);
        }

        //Private parameterless constructor required by Serializer
        private BCFComment()
        { }

        public BCFComment(Guid id, Guid topicId, String status, DateTime date, String author, String comment)
        {
            Status = status;
            Date = date;
            Author = author;
            Comment = comment;
            Guid = id;
            Topic = new AttrIDNode(topicId);
        }

        public BCFComment(XElement node)
        {
            this.Guid = (System.Guid?)node.Attribute("Guid") ?? System.Guid.Empty;
            Status = (String)node.Element("Status") ?? "";
            Date = (DateTime?)node.Element("Date") ?? DateTime.MinValue;
            Author = (String)node.Element("Author") ?? "";
            Comment = (String)node.Element("Comment") ?? "";
            ModifiedDate = (DateTime?)node.Element("ModifiedDate") ?? null;
            ModifiedAuthor = (String)node.Element("ModifiedAuthor") ?? "";
            VerbalStatus = (String)node.Element("VerbalStatus") ?? "";
            Topic = new AttrIDNode(node.Element("Topic"));

            var reply = node.Elements("ReplyToComment").FirstOrDefault();
            if (reply != null)
            {
                ReplyToComment = new AttrIDNode(node.Element("ReplyToComment"));
            }
            var viewp = node.Elements("Viewpoint").FirstOrDefault();
            if (viewp != null)
            {
                Viewpoint = new AttrIDNode(node.Element("Viewpoint"));
            }
        }
    }
}
