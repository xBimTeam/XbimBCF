using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("File")]
    public class BCFFile
    {
        private String _ifcProject;
        /// <summary>
        /// IfcGuid Reference to the project to which this topic is related in the IFC file
        /// </summary>
        [XmlAttribute]
        public String IfcProject
        {
            get { return _ifcProject; }
            set
            {
                if (value.Length != 0 && value.Length != 22)
                {                
                    Validator.RaiseError(nameof(BCFFile), "IfcProject - IfcGuid must be 22 chars exactly", LogLevel.Warning);
                }
                _ifcProject = value;
            }
        }
        public bool ShouldSerializeIfcProject()
        {
            return !string.IsNullOrEmpty(IfcProject);
        }

        private String _ifcSpatialStructureElement;
        /// <summary>
        /// IfcGuid Reference to the spatial structure element, e.g. IfcBuildingStorey, to which this topic is related.
        /// </summary>
        [XmlAttribute]
        public String IfcSpatialStructureElement
        {
            get { return _ifcSpatialStructureElement; }
            set
            {
                if (value.Length != 0 && value.Length != 22)
                {
                    Validator.RaiseError(nameof(BCFFile), "IfcSpatialStructureElement - IfcGuid must be 22 chars exactly", LogLevel.Warning);
                }
                _ifcSpatialStructureElement = value;
            }
        }
        public bool ShouldSerializeIfcSpatialStructureElement()
        {
            return !string.IsNullOrEmpty(IfcSpatialStructureElement);
        }
        /// <summary>
        /// URI to IfcFile. isExternal=false “..\example.ifc“ (within bcfzip) isExternal=true “https://.../example.ifc“
        /// </summary>
        [XmlElement(Order = 3)]
        public String Reference { get; set; }
        public bool ShouldSerializeReference()
        {
            return !string.IsNullOrEmpty(Reference);
        }
        /// <summary>
        /// Date of the BIM file.
        /// </summary>
        [XmlElement(Order = 2)]
        public DateTime? Date { get; set; }
        public bool ShouldSerializeDate()
        {
            return Date != null;
        }
        /// <summary>
        /// The BIM file related to this topic.
        /// </summary>
        [XmlElement(Order = 1)]
        public String Filename { get; set; }
        public bool ShouldSerializeFilename()
        {
            return !string.IsNullOrEmpty(Filename);
        }
        /// <summary>
        /// Is the IFC file external or within the bcfzip. (Default = true)
        /// </summary>
        [XmlAttribute]
        public bool isExternal { get; set; }

        public BCFFile()
        { }

        public BCFFile(XElement node)
        {
            //Attributes
            IfcProject = (string)node.Attribute("IfcProject") ?? "";
            IfcSpatialStructureElement = (string)node.Attribute("IfcSpatialStructureElement") ?? "";
            isExternal = (bool?)node.Attribute("isExternal") ?? true;

            //Nodes
            Reference = (string)node.Element("Reference") ?? "";
            Filename = (string)node.Element("Filename") ?? "";
            Date = (DateTime?)node.Element("Date") ?? null;
        }
    }
}
