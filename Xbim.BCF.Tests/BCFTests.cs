using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Xbim.BCF.XMLNodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xbim.BCF.Tests
{
    [TestClass]
    public class BCFTests
    {
        private BCFTestsXMLHelper xmlSchemaValidator;

        [TestInitialize]
        public void TestInit()
        {
            xmlSchemaValidator = new BCFTestsXMLHelper();
        }

        [TestMethod]
        [DeploymentItem("XML\\markup.xml")]
        public void DeserializeMarkupXML()
        {
            MarkupXMLFile xmlObj = new MarkupXMLFile(XDocument.Load("markup.xml"));
            //Comments
            Assert.IsTrue(xmlObj.Comments.Count > 0);
            Assert.IsNotNull(xmlObj.Comments[0].Guid);
            Assert.IsNotNull(xmlObj.Comments[0].Date);
            Assert.IsNotNull(xmlObj.Comments[0].Author);
            Assert.IsNotNull(xmlObj.Comments[0].Comment);
            Assert.IsNotNull(xmlObj.Comments[0].ModifiedAuthor);
            Assert.IsNotNull(xmlObj.Comments[0].ModifiedDate);
            Assert.IsNotNull(xmlObj.Comments[0].Viewpoint.ID);
            //Viewpoint
            Assert.IsTrue(xmlObj.Viewpoints.Count > 0);
            Assert.IsNotNull(xmlObj.Viewpoints[0].Snapshot);
            Assert.IsNotNull(xmlObj.Viewpoints[0].Viewpoint);
            Assert.IsNotNull(xmlObj.Viewpoints[0].ID);
            Assert.IsNotNull(xmlObj.Viewpoints[0].Index);
            //Header
            Assert.IsNotNull(xmlObj.Header);
            //Files
            Assert.IsTrue(xmlObj.Header.Files.Count > 0);
            Assert.IsNotNull(xmlObj.Header.Files[0].Date);
            Assert.IsNotNull(xmlObj.Header.Files[0].Filename);
            Assert.IsNotNull(xmlObj.Header.Files[0].IfcProject);
            Assert.IsNotNull(xmlObj.Header.Files[0].IfcSpatialStructureElement);
            Assert.IsNotNull(xmlObj.Header.Files[0].isExternal);
            Assert.IsNotNull(xmlObj.Header.Files[0].Reference);
            //Topic
            Assert.IsNotNull(xmlObj.Topic);
            Assert.IsNotNull(xmlObj.Topic.Guid);
            Assert.IsNotNull(xmlObj.Topic.Title);
            Assert.IsNotNull(xmlObj.Topic.TopicType);
            Assert.IsNotNull(xmlObj.Topic.TopicStatus);
            Assert.IsNotNull(xmlObj.Topic.DueDate);
            Assert.IsNotNull(xmlObj.Topic.AssignedTo);
            Assert.IsNotNull(xmlObj.Topic.Stage);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.Reference);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.SnippetType);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.ReferenceSchema);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.isExternal);
        }

        [TestMethod]
        [DeploymentItem("XML\\project.xml")]
        public void DeserializeProjectXML()
        {
            ProjectXMLFile xmlObj = new ProjectXMLFile(XDocument.Load("project.xml"));

            Assert.IsNotNull(xmlObj.ExtensionSchema);
            Assert.IsNotNull(xmlObj.Project);
            Assert.IsNotNull(xmlObj.Project.Name);
            Assert.IsNotNull(xmlObj.Project.ProjectId);
        }

        [TestMethod]
        [DeploymentItem("XML\\version.xml")]
        public void DeserializeVersionXML()
        {
            VersionXMLFile xmlObj = new VersionXMLFile(XDocument.Load("version.xml"));

            Assert.IsNotNull(xmlObj.VersionId);
            Assert.IsNotNull(xmlObj.DetailedVersion);
        }

        [TestMethod]
        [DeploymentItem("XML\\visinfo.xml")]
        public void DeserializeVisualizationXML()
        {
            VisualizationXMLFile xmlObj = new VisualizationXMLFile(XDocument.Load("visinfo.xml"));

            //Bitmaps
            Assert.IsTrue(xmlObj.Bitmaps.Count > 0);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Bitmap);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Height);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Location);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Normal);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Reference);
            Assert.IsNotNull(xmlObj.Bitmaps[0].Up);
            //ClippingPlanes
            Assert.IsTrue(xmlObj.ClippingPlanes.Count > 0);
            Assert.IsNotNull(xmlObj.ClippingPlanes[0].Direction);
            Assert.IsNotNull(xmlObj.ClippingPlanes[0].Location);
            //Components
            Assert.IsTrue(xmlObj.Components.Selection.Components.Count > 0);
            Assert.IsNotNull(xmlObj.Components.Selection.Components[0].AuthoringToolId);
            Assert.IsNotNull(xmlObj.Components.Colorings[0].Color);
            Assert.IsNotNull(xmlObj.Components.Selection.Components[0].IfcGuid);
            Assert.IsNotNull(xmlObj.Components.Selection.Components[0].OriginatingSystem);
            Assert.IsNotNull(xmlObj.Components.Selection.Components[0]);
            Assert.IsNotNull(xmlObj.Components.Visibility.Exceptions[0]);
            Assert.IsNotNull(xmlObj.Components.ViewSetupHints);     
            //Lines
            Assert.IsTrue(xmlObj.Lines.Count > 0);
            Assert.IsNotNull(xmlObj.Lines[0].StartPoint);
            Assert.IsNotNull(xmlObj.Lines[0].EndPoint);
            //Orth Camera
            Assert.IsNotNull(xmlObj.OrthogonalCamera);
            Assert.IsNotNull(xmlObj.OrthogonalCamera.CameraDirection);
            Assert.IsNotNull(xmlObj.OrthogonalCamera.CameraUpVector);
            Assert.IsNotNull(xmlObj.OrthogonalCamera.CameraViewPoint);
            Assert.IsNotNull(xmlObj.OrthogonalCamera.ViewToWorldScale);
            //Pers Camera
            Assert.IsNotNull(xmlObj.PerspectiveCamera);
            Assert.IsNotNull(xmlObj.PerspectiveCamera.CameraDirection);
            Assert.IsNotNull(xmlObj.PerspectiveCamera.CameraUpVector);
            Assert.IsNotNull(xmlObj.PerspectiveCamera.CameraViewPoint);
            Assert.IsNotNull(xmlObj.PerspectiveCamera.FieldOfView);
        }

        [TestMethod]
        [DeploymentItem("XSD\\markup.xsd")]
        public void SchemaValidateMarkupXML()
        {
            XmlSchema markupSchema = BCFTestsXMLHelper.GetSchema("markup.xsd");
            XmlSerializer markupSerializer = new XmlSerializer(typeof(MarkupXMLFile));
            XmlDocument markupXML = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                using (var xmlWriter = new StreamWriter(stream))
                {
                    markupSerializer.Serialize(xmlWriter, BCFTestsXMLHelper.BuildMarkupObject());
                    stream.Seek(0, SeekOrigin.Begin);
                    markupXML.Load(stream);
                    xmlWriter.Close();
                }
            }
            xmlSchemaValidator.ValidXmlDoc(markupXML, markupSchema);
            Assert.IsTrue(xmlSchemaValidator.IsValidXml, "XML does not match Schema: " + xmlSchemaValidator.ValidationError);
        }

        [TestMethod]
        [DeploymentItem("XSD\\project.xsd")]
        public void SchemaValidateProjectXML()
        {
            XmlSchema projectSchema = BCFTestsXMLHelper.GetSchema("project.xsd");
            XmlSerializer projectSerializer = new XmlSerializer(typeof(ProjectXMLFile));
            XmlDocument projectXML = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                using (var xmlWriter = new StreamWriter(stream))
                {
                    projectSerializer.Serialize(xmlWriter, BCFTestsXMLHelper.BuildProjectObject());
                    stream.Seek(0, SeekOrigin.Begin);
                    projectXML.Load(stream);
                    xmlWriter.Close();
                }
            }

            xmlSchemaValidator.ValidXmlDoc(projectXML, projectSchema);
            Assert.IsTrue(xmlSchemaValidator.IsValidXml, "XML does not match Schema: " + xmlSchemaValidator.ValidationError);
        }

        [TestMethod]
        [DeploymentItem("XSD\\version.xsd")]
        public void SchemaValidateVersionXML()
        {
            XmlSchema versionSchema = BCFTestsXMLHelper.GetSchema("version.xsd");
            XmlSerializer versionSerializer = new XmlSerializer(typeof(VersionXMLFile));
            XmlDocument versionXML = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                using (var xmlWriter = new StreamWriter(stream))
                {
                    versionSerializer.Serialize(xmlWriter, BCFTestsXMLHelper.BuildVersionObject());
                    stream.Seek(0, SeekOrigin.Begin);
                    versionXML.Load(stream);
                    xmlWriter.Close();
                }
            }

            xmlSchemaValidator.ValidXmlDoc(versionXML, versionSchema);
            Assert.IsTrue(xmlSchemaValidator.IsValidXml, "XML does not match Schema: " + xmlSchemaValidator.ValidationError);
        }

        [TestMethod]
        [DeploymentItem("XSD\\visinfo.xsd")]
        public void SchemaValidateVisualizationXML()
        {
            XmlSchema visualizationSchema = BCFTestsXMLHelper.GetSchema("visinfo.xsd");
            XmlSerializer visualizationSerializer = new XmlSerializer(typeof(VisualizationXMLFile));
            XmlDocument visualizationXML = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                using (var xmlWriter = new StreamWriter(stream))
                {
                    visualizationSerializer.Serialize(xmlWriter, BCFTestsXMLHelper.BuildVisualizationObject());
                    stream.Seek(0, SeekOrigin.Begin);
                    visualizationXML.Load(stream);
                    xmlWriter.Close();
                }
            }

            xmlSchemaValidator.ValidXmlDoc(visualizationXML, visualizationSchema);
            Assert.IsTrue(xmlSchemaValidator.IsValidXml, "XML does not match Schema: " + xmlSchemaValidator.ValidationError);
        }
    }
}
