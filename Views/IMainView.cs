using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWindFormsMVP.Views
{
    public interface IMainView
    {

        //Eventos
        event EventHandler ShowPetView;
        event EventHandler ShowOwnerView;
        event EventHandler ShowVetsView;
        event EventHandler Showcreatedby; //intentando que salga 
    }
}
