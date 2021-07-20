using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.ViewModel
{
    using BaseClass;
    using Menadżer_Zamówień.Model;
    using Menadżer_Zamówień.DAL.Encje;
    using System.Collections.ObjectModel;


    class TabDodajZamowienie : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Zamowienie> zamowienia = null;
        #endregion

        #region Konstruktory
        public TabDodajZamowienie(Model model)
        {
            this.model = model;
            zamowienia = model.Zamowienia;
        }

        public ObservableCollection<Zamowienie> Zamowienia
        {
            get { return zamowienia; }
            set
            {
                zamowienia = value;
                onPropertyChanged(nameof(Zamowienia));
            }
        }
        #endregion
    }
}
