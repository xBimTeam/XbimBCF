using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("Line")]
    public class BCFLine
    {
        private Vector _startPoint;
        public Vector StartPoint
        {
            get { return _startPoint; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    Validator.RaiseError(nameof(BCFLine), "StartPoint - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                
                _startPoint = value;
                
            }
        }
        private Vector _endPoint;
        public Vector EndPoint
        {
            get { return _endPoint; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    Validator.RaiseError(nameof(BCFLine), "EndPoint - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                
                _endPoint = value;
                
            }
        }

        private BCFLine()
        { }

        public BCFLine(Vector startpoint, Vector endpoint)
        {
            StartPoint = startpoint;
            EndPoint = endpoint;
        }

        public BCFLine(XElement node)
        {
            StartPoint = new Vector((double?)node.Element("StartPoint").Element("X") ?? double.NaN,
                                                                   (double?)node.Element("StartPoint").Element("Y") ?? double.NaN,
                                                                   (double?)node.Element("StartPoint").Element("Z") ?? double.NaN);

            EndPoint = new Vector((double?)node.Element("EndPoint").Element("X") ?? double.NaN,
                                                                   (double?)node.Element("EndPoint").Element("Y") ?? double.NaN,
                                                                   (double?)node.Element("EndPoint").Element("Z") ?? double.NaN);
        }
    }
}
