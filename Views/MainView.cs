﻿using System;
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
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            this.CenterToScreen();
            btnPets.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };
            btncreateby.Click += delegate {Showcreatedby?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler ShowPetView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowVetsView;
        public event EventHandler Showcreatedby;
    }
}
