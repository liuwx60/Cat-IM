using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core
{
    public class Assert
    {
        public static void IfNullThrow<T>(T o, string m)
        {
            if (o == null)
            {
                throw new Exception(m);
            }
        }

        public static void IfTrueThrow(bool o, string m)
        {
            if (o)
            {
                throw new Exception(m);
            }
        }

        public static void IfNullOrWhiteSpaceThrow(string o, string m)
        {
            if (string.IsNullOrWhiteSpace(o))
            {
                throw new Exception(m);
            }
        }
    }
}
