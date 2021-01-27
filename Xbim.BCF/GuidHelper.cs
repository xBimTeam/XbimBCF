using System;

namespace Xbim.BCF
{
    public static class GuidHelper
    {
        public static Guid Parse(string value, Guid? defaultValue = default)
        {
            if(Guid.TryParse(value, out Guid g))
            {
                return g;
            }
            else
            {
                return defaultValue ?? Guid.Empty;
            }
        }
    }
}
