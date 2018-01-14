using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xbim.BCF.Tests
{
    [TestClass]
    public class BCF20Tests
    {
        private const string version = "2.0";

        [TestInitialize]
        public void TestInit()
        {
        }

        [TestMethod]
        [DeploymentItem("2.0\\XML\\markup20.xml")]
        public void DeserializeMarkupXML()
        {
            MarkupXMLFile xmlObj = new MarkupXMLFile(XDocument.Load("markup20.xml"), version);
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
            Assert.IsNotNull(xmlObj.Topic.AssignedTo);
            Assert.IsNotNull(xmlObj.Topic.Stage);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.Reference);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.SnippetType);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.ReferenceSchema);
            Assert.IsNotNull(xmlObj.Topic.BimSnippet.isExternal);
        }

        [TestMethod]
        [DeploymentItem("2.0\\XML\\project20.xml")]
        public void DeserializeProjectXML()
        {
            ProjectXMLFile xmlObj = new ProjectXMLFile(XDocument.Load("project20.xml"));

            Assert.IsNotNull(xmlObj.ExtensionSchema);
            Assert.IsNotNull(xmlObj.Project);
            Assert.IsNotNull(xmlObj.Project.Name);
            Assert.IsNotNull(xmlObj.Project.ProjectId);
        }

        [TestMethod]
        [DeploymentItem("2.0\\XML\\version20.xml")]
        public void DeserializeVersionXML()
        {
            VersionXMLFile xmlObj = new VersionXMLFile(XDocument.Load("version20.xml"));

            Assert.IsNotNull(xmlObj.VersionId);
            Assert.IsNotNull(xmlObj.DetailedVersion);
        }

        [TestMethod]
        [DeploymentItem("2.0\\XML\\visinfo20.xml")]
        public void DeserializeVisualizationXML()
        {
            VisualizationXMLFile xmlObj = new VisualizationXMLFile(XDocument.Load("visinfo20.xml"), version);

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
    }
}
