using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 
            // appMenu
            // 
            this.appMenu = new MainMenu(this);
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(640, 23);
            this.appMenu.TabIndex = 0;
            this.Controls.Add(this.appMenu);

            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

       }
    }
}
