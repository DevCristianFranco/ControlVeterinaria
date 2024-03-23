using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWindFormsMVP.Views
{
    public partial class CreatedBy : Form, ICreatedBy
    {
        public CreatedBy()
        {
            InitializeComponent();
        }

        private void imagencircular1_Click(object sender, EventArgs e)
        {

        }
        private static CreatedBy instance;
        public static CreatedBy GetInstance (Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CreatedBy();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }

            else
            {
                if (instance.WindowState == FormWindowState.Maximized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }


    }
}
