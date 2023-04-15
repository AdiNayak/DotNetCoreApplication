using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Core
{

    public enum SaveTypes
    {
        Insert=0,
        Update=1,
        Delete=2,
        Cancel=3
    }
    public enum StatusTypes
    {
        New,
        Edited,
        Deleted,     
    }
    public enum OperationTypes
    {
        Create,
        Read,
        Update,
        Delete
    }
    public enum GstTypes
    {
       Zero=0,
       Six=6,
       Twelve=12,
       TwentyFour=24,
    }

    public static  class Common
    {
        public static int IntConvert(object obj)
        {
            int value;
            try
            {
                if (obj == null || obj.ToString() == "")
                    value = 0;
                else
                    value = Convert.ToInt32(obj);
            }
            catch (System.Exception)
            {
                return 0;
            }
            return value;
        }
        public static double Val(object obj)
        {
            double value;
            try
            {
                if (obj == null || obj.ToString() == "")
                    value = 0;
                else
                    value = Convert.ToDouble(obj);
            }
            catch (System.Exception)
            {
                return 0;
            }
            return value;
        }
        public static Decimal DecimalConvert(object obj)
        {
            Decimal value;
            try
            {
                if (obj == null || obj.ToString() == "")
                    value = 0;
                else
                    value = Convert.ToDecimal(obj);
            }
            catch (System.Exception)
            {
                return 0;
            }
            return value;
        }
       
    }
}
