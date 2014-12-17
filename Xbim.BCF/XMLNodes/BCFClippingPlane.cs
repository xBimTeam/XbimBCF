using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    [XmlType("ClippingPlane")]
    public class BCFClippingPlane
    {
        Vector _location;
        public Vector Location
        {
            get { return _location; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - Location - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _location = value;
                }
            }
        }

        Vector _direction;
        public Vector Direction
        {
            get { return _direction; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - Direction - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _direction = value;
                }
            }
        }

        private BCFClippingPlane()
        { }

        public BCFClippingPlane(Vector location, Vector direction)
        {
            Location = location;
            Direction = direction;
        }

        public BCFClippingPlane(XElement node)
        {
            Location = new Vector((double?)node.Element("Location").Element("X") ?? double.NaN,
                                                       (double?)node.Element("Location").Element("Y") ?? double.NaN,
                                                       (double?)node.Element("Location").Element("Z") ?? double.NaN);

            Direction = new Vector((double?)node.Element("Direction").Element("X") ?? double.NaN,
                                                       (double?)node.Element("Direction").Element("Y") ?? double.NaN,
                                                       (double?)node.Element("Direction").Element("Z") ?? double.NaN);
        }
    }
}
