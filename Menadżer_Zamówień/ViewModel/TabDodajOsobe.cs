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

    class TabDodajOsobe : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Osoba> osoby = null;
        #endregion

        #region Konstruktory
        public TabDodajOsobe(Model model)
        {
            this.model = model;
            osoby = model.Osoby;
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
        #endregion
    }
}
