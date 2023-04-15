using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ValidTextBox;
using System.IO;
using System.Security.Cryptography;

namespace POS
{
    public static class Common
    {
        public static string PhysiDataFilePath = @"D:\DATA DUMP";
        public static int CompanyId = 0;
        public static string CompanyName = "";
        public static int CounterId = 0;
        public static string loginId = "";
        public static int InstanceCounter = 0;

        public static string CounterName = "";

        public static int UserId = 1;
        public static string UserName = "Admin";
        public static int FinancialYearId = 1;

        public static string ApplicationName = "POS";
        public static string DateFormat = "dd-MMM-yyyy";

        public static string PackingNo = "15BN45YT1";
        public static string VatNo = "21811116508";
        public static string CstNo = "21811116508";
        public static string DefultBrandName = "-";

        //public static string FilePath = ConfigurationManager.AppSettings["DocumentRepositoryPath"];
        //public static string RemortPort = ConfigurationManager.AppSettings["CompanyRemortPortNumber"];
        //public static string RemortServiceName = ConfigurationManager.AppSettings["CompanyRemortServiceName"];
        //public static string RemortServerName = ConfigurationManager.AppSettings["CompanyRemortServerName"];

        //public static string ApplicationType = ConfigurationManager.AppSettings["ApplicationType"];
        //public static string ServerLocation = ConfigurationManager.AppSettings["Location"];

        public static int TimeCounter = 0;
        public static DateTime StartFinancialYear;
        public static DateTime EndFinancialYear;

      
        public static void EnableControl(Control[] Controls, bool value)
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.Enabled = value;
                //if (ctrl.GetType() == typeof(ListView))
                //    ((ListView)ctrl).Enabled = value;
            }
        }

        public static void ReadonlyControl(Control[] Controls, bool value)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).ReadOnly = value;
                }
                else if (ctrl.GetType() == typeof(ValidText))
                {
                    ((ValidText)ctrl).ReadOnly = value;
                }
            }
        }

        public static void ClearControl(Control[] Controls)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ValidText) || ctrl.GetType() == typeof(Label))
                {
                    ctrl.Text = "";
                    ctrl.Tag = null;
                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctrl).DataSource = null;
                    ((ComboBox)ctrl).Items.Clear();
                }

                else if (ctrl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctrl).Checked = false;

                else if (ctrl.GetType() == typeof(RadioButton))
                    ((RadioButton)ctrl).Checked = false;

                else if (ctrl.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)ctrl).Text = "";
                    ((DateTimePicker)ctrl).Tag = null;
                }

                else if (ctrl.GetType() == typeof(ListView))
                {
                    ((ListView)ctrl).Items.Clear();
                    ((ListView)ctrl).Tag = null;
                }
            }
        }

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

        public static bool ValidateControls(Control[] control)
        {
            Boolean result = true;
            try
            {
                foreach (Control ctrl in control)
                {
                    if (((ValidText)ctrl).IsBlankAllowed == ValidText.ValidationType.No)
                    {
                        if (ctrl.Text == "" || ctrl.Tag == null)
                        {
                            result = false;
                            ctrl.Focus();
                            break;
                        }
                    }
                    else if (((ValidText)ctrl).IsBlankAllowed == ValidText.ValidationType.Yes)
                    {
                        if (ctrl.Text == "" || Common.Val(ctrl.Text) == 0)
                        {
                            result = false;
                            ctrl.Focus();
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return result;
        }

        public static Boolean CheckValidEntries(ValidText[] ctrlArray)
        {
            Boolean RtnVal = true;
            try
            {
                foreach (ValidText ctrl in ctrlArray)
                {
                    if (ctrl.Text.Trim() == "")
                    {
                        RtnVal = false;
                        ctrl.Focus();
                        break;
                    }
                    else if (ctrl.Tag == null && ctrl.IsBlankAllowed.ToString() == "No")
                    {
                        RtnVal = false;
                        ctrl.Focus();
                        break;
                    }
                    else if (Convert.ToString(ctrl.Tag).Trim() == "" && ctrl.IsBlankAllowed.ToString() == "No")
                    {
                        RtnVal = false;
                        ctrl.Focus();
                        break;
                    }
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return RtnVal;
        }

        public static String ConvertInWords(object Value)
        {
            try
            {
                CurrencyToWord.Class1 c2w = new CurrencyToWord.Class1();
                return c2w.ConvertCurrencyToEnglish(Value);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            
        }

        public static Boolean IsNumeric(string Parameter)
        {
            try
            {
                decimal dcm = decimal.Parse(Parameter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean FinancialYrDateVerification(DateTime currentDate)
        {
            Boolean result=false;
            try
            {
                if (currentDate >= StartFinancialYear && currentDate <= EndFinancialYear)
                        result = true;
            }
            catch
            {
                return false;
            }
            return result;
        }

        public static Boolean checkMRP(Decimal minSaleAmt, Decimal mrpAmt)
        {
            Boolean result = false;
            try
            {
                if (minSaleAmt>mrpAmt)
                    result = true;
            }
            catch
            {
                return false;
            }
            return result;
        }


        public static string EncryptText(string password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(password);
            byte[] Salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(password, Salt);
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);

            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }



    }
}
