using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UTools
{
    public partial class ValidText : TextBox
    {
        public ValidText()
        {
            InitializeComponent();
        }

        public enum enmInputtype
        {
            Text,
            Numeric,
            EMail,
            Backspace
        }
        public enum enmDecimalFormat
        {
            None,
            Two,
            Three
        }
        public enum enmValidationType
        {
            Yes,
            No
        }

        enmInputtype envInputType;
        enmDecimalFormat envDecimalFormat;
        enmValidationType envValidationType;
        Single MailCounter;

        public enmInputtype InputType
        {
            get
            {
                return envInputType;
            }
            set
            {
                envInputType = value;
            }
        }

        public enmValidationType IsBlankAllowed
        {
            get
            {
                return envValidationType;
            }
            set
            {
                envValidationType = value;
            }
        }

        public enmDecimalFormat DecimalPlace
        {
            get
            {
                return envDecimalFormat;
            }
            set
            {
                envDecimalFormat = value;
            }
        }

        private void ValidText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Text.Trim() == "" && Convert.ToByte(e.KeyChar) == 32)
            {
                e.Handled = true;
                return;
            }
            if (this.Text.Trim() == "" && Convert.ToByte(e.KeyChar) == 45)
            {
                e.Handled = false;
                return;
            }
            if (this.Text.Trim() == "" && Convert.ToByte(e.KeyChar) == 46)
            {
                e.Handled = true;
                return;
            }
            if (Convert.ToByte(e.KeyChar) == 8)
            {
                e.Handled = false;
                return;
            }

            switch (this.envInputType)
            {
                case enmInputtype.Text:
                    if (Convert.ToByte(e.KeyChar) == 39)
                    {
                        e.Handled = true;
                        return;
                    }
                    break;
                case enmInputtype.Numeric:
                    if (this.envDecimalFormat == enmDecimalFormat.None)
                    {
                        if (char.IsDigit(e.KeyChar) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (char.IsNumber(e.KeyChar) == false && Convert.ToByte(e.KeyChar) != 46)
                        {
                            e.Handled = true;
                            return;
                        }
                        else if (Convert.ToByte(e.KeyChar) == 46)
                        {
                            if (this.Text.IndexOf("@") > 0)
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                    }
                    break;
                case enmInputtype.EMail:
                    MailCounter = 0;
                    CharEnumerator ce = this.Text.GetEnumerator();
                    while (ce.MoveNext())
                    {
                        if ('@' == ce.Current)
                        {
                            MailCounter += 1;
                        }
                    }
                    if (Convert.ToByte(e.KeyChar) == 39)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (Convert.ToByte(e.KeyChar) == 64)
                    {
                        MailCounter += 1;
                        if (MailCounter > 1)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    break;
                case enmInputtype.Backspace:
                    if (Convert.ToByte(e.KeyChar) != 8)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (Convert.ToByte(e.KeyChar) != 13)
                    {
                        e.Handled = true;
                        return;
                    }
                    break;
            }
        }

        private void Valitext_Textchange(object sender, EventArgs e)
        {
            if (this.Text == "")
            {
                this.Tag = 0;
            }
        }

        private void ValidText_Enter(object sender, EventArgs e)
        {
            Label lblLeftBrdr = new Label();
            lblLeftBrdr.Width=1;
            lblLeftBrdr.BackColor = System.Drawing.Color.DarkOrange;
            lblLeftBrdr.Dock = DockStyle.Left;

            Label lblRightBrdr = new Label();
            lblRightBrdr.Width = 1;
            lblRightBrdr.BackColor = System.Drawing.Color.DarkOrange;
            lblRightBrdr.Dock = DockStyle.Right;

            //Label lblTopBrdr = new Label();
            //lblTopBrdr.Height = 1;
            //lblTopBrdr.BackColor = System.Drawing.Color.Orange;
            //lblTopBrdr.Dock = DockStyle.Top;

            //Label lblBottomBrdr = new Label();
            //lblBottomBrdr.Height = 1;
            //lblBottomBrdr.BackColor = System.Drawing.Color.Orange;
            //lblBottomBrdr.Dock = DockStyle.Bottom;
            this.Controls.Clear();
            this.Controls.Add(lblLeftBrdr);
            this.Controls.Add(lblRightBrdr);
            //this.Controls.Add(lblTopBrdr);
            //this.Controls.Add(lblBottomBrdr);
        }

        private void ValidText_Leave(object sender, EventArgs e)
        {
            this.Controls.Clear();

            this.BackColor = Color.White;
            switch (this.envInputType)
            {
                case enmInputtype.Text:
                    break;
                case enmInputtype.Numeric:
                   
                    switch (this.envDecimalFormat)
                    {
                        case enmDecimalFormat.None:
                            break;
                        case enmDecimalFormat.Two:
                            this.Text = string.Format("{0:N2}", System.Convert.ToDecimal((this.Text.Trim() == "" ? "0" : this.Text.Trim())));
                            break;
                        case enmDecimalFormat.Three:
                            this.Text = string.Format("{0:N3}", System.Convert.ToDecimal((this.Text.Trim() == "" ? "0" : this.Text.Trim())));
                            break;
                    }
                    break;
                case enmInputtype.EMail:
                    if (this.Text.IndexOf(".") == -1 || this.Text.IndexOf("@") == -1)
                    {
                        this.Focus();
                    }
                    if (this.Text.Length == this.Text.LastIndexOf("@") + 1)
                    {
                        this.Focus();
                    }
                    break;
            }
        }

        private void ValidText_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Text.Trim() == "")
            {
                if (this.envInputType == enmInputtype.Numeric && this.Enabled == true)
                {
                    if (this.envDecimalFormat == enmDecimalFormat.Two)
                        this.Text = "0.00";
                    else if (this.envDecimalFormat == enmDecimalFormat.Three)
                        this.Text = "0.000";
                    else
                        this.Text = "00";
                }
            }
        }


    }
}