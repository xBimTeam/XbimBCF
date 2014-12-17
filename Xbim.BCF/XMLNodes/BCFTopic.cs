using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    public class BCFTopic
    {
        private Guid _guid;
        /// <summary>
        /// The topic identifier
        /// </summary>
        [XmlAttribute]
        public Guid Guid
        {
            get { return _guid; }
            set
            {
                if (value == null || value == System.Guid.Empty)
                {
                    throw new ArgumentException(this.GetType().Name + " - Guid identifier is mandatory and must contain a valid Guid value");
                }
                else
                {
                    _guid = value;
                }
            }
        }
        private String _title;
        /// <summary>
        /// Title of the topic
        /// </summary>
        [XmlElement(Order = 1)]
        public String Title
        {
            get { return _title; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(this.GetType().Name + " - Title is mandatory");
                }
                else
                {
                    _title = value;
                }
            }
        }
        /// <summary>
        /// The type of the topic (the options can be specified in the extension schema)
        /// </summary>
        [XmlAttribute]
        public String TopicType { get; set; }
        public bool ShouldSerializeTopicType()
        {
            return !string.IsNullOrEmpty(TopicType);
        }
        /// <summary>
        /// Reference to the topic in, for example, a work request management system
        /// </summary>
        [XmlElement(Order = 2)]
        public String ReferenceLink { get; set; }
        public bool ShouldSerializeReferenceLink()
        {
            return !string.IsNullOrEmpty(ReferenceLink);
        }
        /// <summary>
        /// Description of the topic
        /// </summary>
        [XmlElement(Order = 3)]
        public String Description { get; set; }
        public bool ShouldSerializeDescription()
        {
            return !string.IsNullOrEmpty(Description);
        }
        /// <summary>
        /// Topic priority. The list of possible values are defined in the extension schema
        /// </summary>
        [XmlElement(Order = 4)]
        public String Priority { get; set; }
        public bool ShouldSerializePriority()
        {
            return !string.IsNullOrEmpty(Priority);
        }
        /// <summary>
        /// Number to maintain the order of the topics
        /// </summary>
        [XmlElement(Order = 5)]
        public int? Index { get; set; }
        public bool ShouldSerializeIndex()
        {
            return Index != null;
        }
        /// <summary>
        /// Date when the topic was created
        /// </summary>
        [XmlElement(Order = 6)]
        public DateTime? CreationDate { get; set; }
        public bool ShouldSerializeCreationDate()
        {
            return CreationDate != null;
        }
        /// <summary>
        /// User who created the topic
        /// </summary>
        [XmlElement(Order = 7)]
        public String CreationAuthor { get; set; }
        public bool ShouldSerializeCreationAuthor()
        {
            return !string.IsNullOrEmpty(CreationAuthor);
        }
        /// <summary>
        /// Date when the topic was last modified
        /// </summary>
        [XmlElement(Order = 8)]
        public DateTime? ModifiedDate { get; set; }
        public bool ShouldSerializeModifiedDate()
        {
            return ModifiedDate != null;
        }
        /// <summary>
        /// User who modified the topic
        /// </summary>
        [XmlElement(Order = 9)]
        public String ModifiedAuthor { get; set; }
        public bool ShouldSerializeModifiedAuthor()
        {
            return !string.IsNullOrEmpty(ModifiedAuthor);
        }
        /// <summary>
        /// The user to whom this topic is assigned to
        /// </summary>
        [XmlElement(Order = 10)]
        public String AssignedTo { get; set; }
        public bool ShouldSerializeAssignedTo()
        {
            return !string.IsNullOrEmpty(AssignedTo);
        }
        /// <summary>
        /// The status of the topic (the options can be specified in the extension schema)
        /// </summary>
        [XmlElement(Order = 11)]
        public String TopicStatus { get; set; }
        public bool ShouldSerializeTopicStatus()
        {
            return !string.IsNullOrEmpty(TopicStatus);
        }
        /// <summary>
        /// BimSnippet is an additional file containing information related to one or multiple topics. For example, it can be an IFC file containing provisions for voids.
        /// </summary>
        [XmlElement(Order = 12)]
        public BCFBimSnippet BimSnippet { get; set; }
        public bool ShouldSerializeBimSnippet()
        {
            return BimSnippet != null;
        }
        /// <summary>
        /// DocumentReference provides a means to associate additional payloads or links with topics. The references may point to a file within the .bcfzip or to an external location.
        /// </summary>
        [XmlElement(ElementName = "DocumentReferences", Order = 13)]
        public List<BCFDocumentReference> DocumentReferences;
        public bool ShouldSerializeDocumentReferences()
        {
            return DocumentReferences != null && DocumentReferences.Count > 0;
        }
        /// <summary>
        /// Relation between topics (Clash -> PfV -> Opening)
        /// </summary>
        [XmlElement(ElementName = "RelatedTopics", Order = 14)]
        public List<BCFRelatedTopic> RelatedTopics;
        public bool ShouldSerializeRelatedTopics()
        {
            return RelatedTopics != null && RelatedTopics.Count > 0;
        }


        private BCFTopic()
        { }

        public BCFTopic(Guid topicID, String title)
        {
            Guid = topicID;
            Title = title;
            DocumentReferences = new List<BCFDocumentReference>();
            RelatedTopics = new List<BCFRelatedTopic>();
        }

        public BCFTopic(XElement node)
        {
            DocumentReferences = new List<BCFDocumentReference>();
            RelatedTopics = new List<BCFRelatedTopic>();

            this.Guid = Guid.Parse((String)node.Attribute("Guid") ?? "");
            Title = (String)node.Element("Title") ?? "";
            TopicType = (String)node.Attribute("TopicType") ?? "";
            ReferenceLink = (String)node.Element("ReferenceLink") ?? "";
            Description = (String)node.Element("Description") ?? "";
            Priority = (String)node.Element("Priority") ?? "";
            Index = (int?)node.Element("Index") ?? null;
            CreationDate = (DateTime?)node.Element("CreationDate") ?? null;
            CreationAuthor = (String)node.Element("CreationAuthor") ?? "";
            ModifiedDate = (DateTime?)node.Element("ModifiedDate") ?? null;
            ModifiedAuthor = (String)node.Element("ModifiedAuthor") ?? "";
            AssignedTo = (String)node.Element("AssignedTo") ?? "";
            TopicStatus = (String)node.Element("TopicStatus") ?? "";

            var bimSnippet = node.Elements("BimSnippet").FirstOrDefault();
            if (bimSnippet != null)
            {
                BimSnippet = new BCFBimSnippet(bimSnippet);
            }

            var docRefs = node.Elements("DocumentReferences").FirstOrDefault();
            if (docRefs != null)
            {
                foreach (var dref in node.Elements("DocumentReferences"))
                {
                    DocumentReferences.Add(new BCFDocumentReference(dref));
                }
            }

            var relTopics = node.Elements("RelatedTopics").FirstOrDefault();
            if (relTopics != null)
            {
                foreach (var rt in node.Elements("RelatedTopics"))
                {
                    RelatedTopics.Add(new BCFRelatedTopic(rt));
                }
            }
        }
    }
}
