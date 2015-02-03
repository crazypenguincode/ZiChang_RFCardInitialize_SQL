using System;
using System.Collections.Generic;
using System.Text;

namespace ICCardInitialize
{
    public class SParameter
    {
        private static IntPtr ptr;
        private static int Number;
        private static int Paud;
        public static IntPtr intptr
        {
            get
            {
                return ptr;
            }
            set
            {
                ptr = value;
            }
        }
        public static int  IntNumber
        {
            get
            {
                return Number;
            }
            set
            {
                Number = value;
            }
        }

        public static int IntPaud
        {
            get
            {
                return Paud;
            }
            set
            {
                Paud = value;
            }
        }
    }
}
