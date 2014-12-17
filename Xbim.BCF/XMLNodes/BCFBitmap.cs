using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Xbim.BCF.XMLNodes
{
    public class BCFBitmap
    {
        private String _bitmap;
        /// <summary>
        /// Format of the bitmap (PNG/JPG)
        /// </summary>
        [XmlElement(Order = 1)]
        public String Bitmap
        {
            get { return _bitmap; }
            set
            {
                if (String.IsNullOrEmpty(value)
                    || (!string.Equals(value, "PNG") && !string.Equals(value, "JPG"))
                    )
                {
                    throw new ArgumentException(this.GetType().Name + " - Bitmap - is a mandatory value of either PNG or JPG (case sensitive)");
                }
                else
                {
                    _bitmap = value;
                }
            }
        }
        private String _reference;
        /// <summary>
        /// Name of the bitmap file in the topic folder
        /// </summary>
        [XmlElement(Order = 2)]
        public String Reference
        {
            get { return _reference; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(this.GetType().Name + " - Reference - is a mandatory value");
                }
                else
                {
                    _reference = value;
                }
            }
        }
        Vector _location;
        /// <summary>
        /// Location of the center of the bitmap in world coordinates
        /// </summary>
        [XmlElement(Order = 3)]
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
        Vector _normal;
        /// <summary>
        /// Normal vector of the bitmap
        /// </summary>
        [XmlElement(Order = 4)]
        public Vector Normal
        {
            get { return _normal; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - Normal - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _normal = value;
                }
            }
        }
        Vector _up;
        /// <summary>
        /// Up vector of the bitmap
        /// </summary>
        [XmlElement(Order = 5)]
        public Vector Up
        {
            get { return _up; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - Up - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _up = value;
                }
            }
        }
        private double _height;
        /// <summary>
        /// Height of the bitmap
        /// </summary>
        [XmlElement(Order = 6)]
        public double Height
        {
            get { return _height; }
            set
            {
                if (value == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - Height - must contain a valid 64-bit floating-point value");
                }
                else
                {
                    _height = value;
                }
            }
        }

        private BCFBitmap()//parameterless ctor required by serializer
        { }

        public BCFBitmap(Vector location, Vector normal, Vector up, double height, String bitmapType, String reference)
        {
            Location = location;
            Normal = normal;
            Up = up;
            Height = height;
            Bitmap = bitmapType;
            Reference = reference;
        }

        public BCFBitmap(XElement node)
        {
            Location = new Vector((double?)node.Element("Location").Element("X") ?? double.NaN,
                                                       (double?)node.Element("Location").Element("Y") ?? double.NaN,
                                                       (double?)node.Element("Location").Element("Z") ?? double.NaN);

            Normal = new Vector((double?)node.Element("Normal").Element("X") ?? double.NaN,
                                                       (double?)node.Element("Normal").Element("Y") ?? double.NaN,
                                                       (double?)node.Element("Normal").Element("Z") ?? double.NaN);

            Up = new Vector((double?)node.Element("Up").Element("X") ?? double.NaN,
                                                       (double?)node.Element("Up").Element("Y") ?? double.NaN,
                                                       (double?)node.Element("Up").Element("Z") ?? double.NaN);

            Height = (double?)node.Element("Height") ?? double.NaN;
            Bitmap = (String)node.Element("Bitmap") ?? "";
            Reference = (String)node.Element("Reference") ?? "";
        }
    }
}
