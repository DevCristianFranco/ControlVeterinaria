using CRUDWindFormsMVP.Models;
using CRUDWindFormsMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWindFormsMVP.Presenters.Common
{
    internal class CreatedByPresenter
    {
        //Fields
        private ICreatedBy view;

        //Constructor
        public CreatedByPresenter (ICreatedBy view)
        {
        
          this.view = view;
 

          //Show view
          this.view.Show();
         }
    }
}
