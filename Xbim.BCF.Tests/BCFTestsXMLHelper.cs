using System;
using System.Linq;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Xml;
using System.Xml.Schema;
using Xbim.BCF.XMLNodes;

namespace Xbim.BCF.Tests
{
    public class BCFTestsXMLHelper
    {
        private bool isValidXml = true;
        private string validationError = "";

        public String ValidationError
        {
            get { return "Validation Error: " + validationError; }
            set { validationError = value; }
        }

        public bool IsValidXml
        {
            get { return isValidXml; }
        }

        public void ValidXmlDoc(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            validateParameters(xmlDocument, xmlSchema);
            XmlReader xmlReader = createXmlReader(xmlDocument, xmlSchema);

            try
            {
                // validate       
                using (xmlReader)
                {
                    while (xmlReader.Read())
                    { }
                }
                isValidXml = true;
            }
            catch (Exception ex)
            {
                ValidationError = ex.Message;
                isValidXml = false;
            }
        }

        private static void validateParameters(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            if (xmlDocument == null)
            {
                new ArgumentNullException("ValidXmlDoc() - Argument NULL: XmlDocument");
            }
            if (xmlSchema == null)
            {
                new ArgumentNullException("ValidXmlDoc() - Argument NULL: XmlSchema");
            }
        }

        private static XmlReader createXmlReader(XmlDocument xmlDocument, XmlSchema xmlSchema)
        {
            StringReader xmlStringReader = convertXmlDocumentToStringReader(xmlDocument);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            xmlReaderSettings.Schemas.Add(xmlSchema);
            return XmlReader.Create(xmlStringReader, xmlReaderSettings);
        }

        private static StringReader convertXmlDocumentToStringReader(XmlDocument xmlDocument)
        {
            StringWriter sw = new StringWriter();
            xmlDocument.WriteTo(new XmlTextWriter(sw));
            return new StringReader(sw.ToString());
        }

        public static XmlSchema GetSchema(String file)
        {
            XmlTextReader reader = new XmlTextReader(file);
            return XmlSchema.Read(reader, ValidationCallback);
        }
        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {

            }
            else if (args.Severity == XmlSeverityType.Error)
            {

            }
        }

        public static MarkupXMLFile BuildMarkupObject()
        {
            MarkupXMLFile xmlObj = new MarkupXMLFile();

            BCFComment comment = new BCFComment(Guid.NewGuid(), Guid.NewGuid(), "testStatus", DateTime.Now, "testAuthor", "testComment");
            comment.ModifiedAuthor = "testModifiedAuthor";
            comment.ModifiedDate = DateTime.Now;
            comment.ReplyToComment = new AttrIDNode(Guid.NewGuid());
            comment.Viewpoint = new AttrIDNode(Guid.NewGuid());
            comment.VerbalStatus = "testVerbalStatus";
            xmlObj.Comments.Add(comment);

            BCFViewpoint viewp = new BCFViewpoint(Guid.NewGuid());
            viewp.Snapshot = "testSnapshot.png";
            viewp.Viewpoint = "testFilename.bcfv";
            xmlObj.Viewpoints.Add(viewp);

            xmlObj.Header = new BCFHeader();

            BCFFile f = new BCFFile();
            f.Date = DateTime.Now;
            f.Filename = "testFilename";
            f.IfcProject = "IfcGuid______________1";
            f.IfcSpatialStructureElement = "IfcGuid______________1";
            f.isExternal = false;
            f.Reference = "testReference";
            xmlObj.Header.Files.Add(f);

            xmlObj.Topic = new BCFTopic(Guid.NewGuid(), "testTitle");
            xmlObj.Topic.AssignedTo = "testAssignedTo";
            xmlObj.Topic.BimSnippet = new BCFBimSnippet("testSnippetType", "testReference");
            xmlObj.Topic.BimSnippet.isExternal = true;
            xmlObj.Topic.BimSnippet.ReferenceSchema = "testReferenceSchema";

            return xmlObj;
        }

        public static ProjectXMLFile BuildProjectObject()
        {
            ProjectXMLFile xmlObj = new ProjectXMLFile();

            xmlObj.ExtensionSchema = "testExtensionSchema";

            xmlObj.Project = new BCFProject();
            xmlObj.Project.Name = "testName";
            xmlObj.Project.ProjectId = "testProjectID";

            return xmlObj;
        }

        public static VersionXMLFile BuildVersionObject()
        {
            VersionXMLFile xmlObj = new VersionXMLFile("testVersionID");

            xmlObj.DetailedVersion = "testDetailedVersion";

            return xmlObj;
        }

        public static VisualizationXMLFile BuildVisualizationObject()
        {
            VisualizationXMLFile xmlObj = new VisualizationXMLFile();
            Vector testVector = new Vector(1.7976931348623157E+308, 1.7976931348623157E+308, 1.7976931348623157E+308);

            BCFBitmap bMap = new BCFBitmap(testVector, testVector, testVector, 1.7976931348623157E+308, "PNG", "testReference");
            xmlObj.Bitmaps.Add(bMap);
            xmlObj.Bitmaps.Add(bMap);

            BCFClippingPlane cp = new BCFClippingPlane(testVector, testVector);
            xmlObj.ClippingPlanes.Add(cp);
            xmlObj.ClippingPlanes.Add(cp);

            BCFComponent c = new BCFComponent();
            c.AuthoringToolId = "testAuthoringToolID";
            c.Color = "7FFFFFFF";
            c.IfcGuid = "IfcGuid______________1";
            c.OriginatingSystem = "testOriginatingSystem";
            c.Selected = true;
            c.Visible = true;
            xmlObj.Components.Add(c);
            xmlObj.Components.Add(c);

            BCFLine l = new BCFLine(testVector, testVector);
            xmlObj.Lines.Add(l);
            xmlObj.Lines.Add(l);

            xmlObj.OrthogonalCamera = new BCFOrthogonalCamera(testVector, testVector, testVector, 1);
            xmlObj.PerspectiveCamera = new BCFPerspectiveCamera(testVector, testVector, testVector, 60);

            return xmlObj;
        }
    }
}
