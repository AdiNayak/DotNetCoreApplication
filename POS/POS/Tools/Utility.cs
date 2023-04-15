using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{

    public interface IForm
    {
        

        FormModes CurrentMode
        { get; }      
        FormModes Add();       
        FormModes Save();
        FormModes Delete();
        FormModes View();        
        FormModes Print();       
    } 
    public interface IUserControl : IForm
    {

    }
    public enum FormModes
    {
        Load,
        Add,
        Edit,
        Save,       
        Delete,
        View,
        Print, 
           
    }
    public enum UserType
    {        
        Admin,
        User,
        Guest,
        Vender
    }
    public enum GstTypes
    {
        Zero = 0,
        Six = 6,
        Twelve = 12,
        TwentyFour = 24,
    }
}
