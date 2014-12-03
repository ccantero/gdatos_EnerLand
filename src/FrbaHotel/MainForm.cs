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
        public MainMenu UserControl_MainMenu;
        
        public MainForm()
        {
            InitializeComponent();
            DbManager.Actualizar_Reserva();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 
            // appMenu
            // 
            UserControl_MainMenu = new MainMenu(this);
            /*
            this.appMenu = UserControl_MainMenu;
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(640, 23);
            this.appMenu.TabIndex = 0;
            this.Controls.Add(this.appMenu);
            */

            this.appMenu = UserControl_MainMenu;
            UserControl_MainMenu.Location = new System.Drawing.Point(0, 0);
            UserControl_MainMenu.Name = "UserControl_MainMenu";
            UserControl_MainMenu.Size = new System.Drawing.Size(640, 23);
            this.Controls.Add(UserControl_MainMenu);

            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;            
            
       }

    }
}
