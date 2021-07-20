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

    class TabPodglad : ViewModelBase
    {

        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Osoba> osoby = null;
        private ObservableCollection<Zamowienie> zamowienia = null;

        #endregion

        #region Konstruktory
        public TabPodglad(Model model)
        {
            this.model = model;
            osoby = model.Osoby;
            zamowienia = model.Zamowienia;

        }

        public ObservableCollection<Osoba> Osoby
        {
            get { return osoby; }
            set
            {
                osoby = value;
                onPropertyChanged(nameof(Osoby));
            }
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
