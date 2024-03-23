using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDWindFormsMVP.Views;
using CRUDWindFormsMVP.Models;
using CRUDWindFormsMVP._Repositories;
using System.Windows.Forms;
using CRUDWindFormsMVP.Presenters.Common;

namespace CRUDWindFormsMVP.Presenters
{
    public class MainPresenter
    {
        //Fields
        private IMainView mainView;
        private readonly string sqlConnectionString;

        //Constructor
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowPetView += ShowPetsView;
            this.mainView.Showcreatedby += Showcreatedby;
        }

        private void ShowPetsView(object sender, EventArgs e)
        {
            IPetView view = PetView.GetInstance((MainView)mainView);
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(view, repository);
        }

        private void Showcreatedby (object sender, EventArgs e)
        {
            ICreatedBy view = CreatedBy.GetInstance((MainView)mainView);
            new CreatedByPresenter (view);
        }

    }
}
