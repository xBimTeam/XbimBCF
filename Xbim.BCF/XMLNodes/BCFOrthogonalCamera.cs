using System;
using System.Xml.Linq;

namespace Xbim.BCF.XMLNodes
{
    public class BCFOrthogonalCamera
    {
        private Vector _cameraViewPoint;
        /// <summary>
        /// Camera location
        /// </summary>
        public Vector CameraViewPoint
        {
            get { return _cameraViewPoint; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - CameraViewPoint - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _cameraViewPoint = value;
                }
            }
        }
        private Vector _cameraDirection;
        /// <summary>
        /// Camera direction
        /// </summary>
        public Vector CameraDirection
        {
            get { return _cameraDirection; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - CameraDirection - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _cameraDirection = value;
                }
            }
        }
        private Vector _cameraupVector;
        /// <summary>
        /// Camera up vector
        /// </summary>
        public Vector CameraUpVector
        {
            get { return _cameraupVector; }
            set
            {
                if (value.X == double.NaN || value.Y == double.NaN || value.Z == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - CameraUpVector - must contain X, Y and Z nodes containing a valid 64-bit floating-point value");
                }
                else
                {
                    _cameraupVector = value;
                }
            }
        }
        private double _viewToWorldScale;
        /// <summary>
        /// Scaling from view to world
        /// </summary>
        public double ViewToWorldScale
        {
            get { return _viewToWorldScale; }
            set
            {
                if (value == double.NaN)
                {
                    throw new ArgumentException(this.GetType().Name + " - ViewToWorldScale - must be a valid 64-bit floating-point value");
                }
                else
                {
                    _viewToWorldScale = value;
                }
            }
        }

        //Private parameterless constructor required by Serializer
        private BCFOrthogonalCamera()
        { }

        public BCFOrthogonalCamera(Vector cameraViewPoint, Vector cameraDirection, Vector cameraUpVector, int viewToWorldScale)
        {
            CameraViewPoint = cameraViewPoint;
            CameraDirection = cameraDirection;
            CameraUpVector = cameraUpVector;
            ViewToWorldScale = viewToWorldScale;
        }

        public BCFOrthogonalCamera(XElement node)
        {
            CameraViewPoint = new Vector((double?)node.Element("CameraViewPoint").Element("X") ?? double.NaN,
                                                                   (double?)node.Element("CameraViewPoint").Element("Y") ?? double.NaN,
                                                                   (double?)node.Element("CameraViewPoint").Element("Z") ?? double.NaN);

            CameraDirection = new Vector((double?)node.Element("CameraDirection").Element("X") ?? double.NaN,
                                                                   (double?)node.Element("CameraDirection").Element("Y") ?? double.NaN,
                                                                   (double?)node.Element("CameraDirection").Element("Z") ?? double.NaN);

            CameraUpVector = new Vector((double?)node.Element("CameraUpVector").Element("X") ?? double.NaN,
                                                                   (double?)node.Element("CameraUpVector").Element("Y") ?? double.NaN,
                                                                   (double?)node.Element("CameraUpVector").Element("Z") ?? double.NaN);

            ViewToWorldScale = (double?)node.Element("ViewToWorldScale") ?? double.NaN;

        }
    }
}
