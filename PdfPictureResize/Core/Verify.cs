using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfPictureResize.Core
{
    public abstract class Verify
    {
        public static void IsNotNull(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, parameterName);
            }
        }

        public static void IsString(object value, string paramterName)
        {
            if (!(value is string))
            {
                throw new ArgumentException(paramterName, paramterName);
            }
        }
    }
}
