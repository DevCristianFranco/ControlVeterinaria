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
    public partial class PetView : Form, IPetView
    {

        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;
        


        //Constructor
        public PetView()
        {
            this.CenterToScreen();
            InitializeComponent();
            AssociatedAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tapPagePetDetail);
            btnClose.Click += delegate { this.Close(); };
            //tabconPets.TabPages.Remove(tabPageList);  PetDetail
        }

        private void AssociatedAndRaiseViewEvents()
        {
            //Search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearchPet.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            var tabPagePetList = this.tapPagePetList;
            var tabPagePetDetail = this.tapPagePetDetail;
            //Add New
            btnAddNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
                tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Add new pet";
            };
            //Edit New
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
               tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Edit new pet";
            };

            //Save Changes 
            btnSave.Click += delegate 
            {
                SaveEvent?.Invoke(this, EventArgs.Empty); 
                if(IsSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPagePetDetail);
                    tabControl1.TabPages.Add(tabPagePetList);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            btnCancel.Click += delegate
            {
               CancelEvent?.Invoke(this, EventArgs.Empty); 
                tabControl1.TabPages.Remove(tabPagePetDetail);
                tabControl1.TabPages.Add(tabPagePetList);
            };
            //Delete
            btnDelete.Click += delegate 
            { 
                var result = MessageBox.Show("Are you sure want to delete the selected pet?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes) 
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }
        //Propperties
        public string PetId
        {
            get { return txtPetId.Text; }
            set { txtPetId.Text = value; }
        }

        public string PetName
        {
            get { return txtPetName.Text; }
            set { txtPetName.Text = value; }
        }

        public string PetType
        {
            get { return txtPetType.Text; }
            set { txtPetType.Text=value;}
        }

        public string PetColour
        {
            get { return txtPetColour.Text; }
            set { txtPetColour.Text=value;}
        }

        public string SearchValue
        {
            get { return txtSearchPet.Text; }
            set { txtSearchPet.Text = value; }
        }

        public bool IsEdit
        {
            get { return isEdit;}
            set { isEdit=value;}
        }

        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message;}
            set { message = value; }
        }


        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler DeleteEvent;

        //Methods
        public void SetPetListBindingSource(BindingSource petList)
        {
            //throw new NotImplementedException();
            dataGridView1.DataSource = petList;
        }

        //Singleton pattern (Open a single form instance)
        private static PetView instance;
        public static PetView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle= FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
           
            else 
            {
                if(instance.WindowState == FormWindowState.Maximized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

 
    }
}
