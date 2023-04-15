namespace UTools
{
    partial class ValidText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ValidText
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Black;
            this.Leave += new System.EventHandler(this.ValidText_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidText_KeyPress);
            this.Enter += new System.EventHandler(this.ValidText_Enter);
            this.EnabledChanged += new System.EventHandler(this.ValidText_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion




    }
}
