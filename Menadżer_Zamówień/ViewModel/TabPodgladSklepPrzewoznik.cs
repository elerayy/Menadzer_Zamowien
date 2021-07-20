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

    class TabPodgladSklepPrzewoznik : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Sklep> sklepy = null;
        private ObservableCollection<Przewoznik> przewoznicy = null;
        #endregion

        #region Konstruktory
        public TabPodgladSklepPrzewoznik(Model model)
        {
            this.model = model;
            sklepy = model.Sklepy;
            przewoznicy = model.Przewoznicy;
        }

        public ObservableCollection<Sklep> Sklepy
        {
            get { return sklepy; }
            set
            {
                sklepy = value;
                onPropertyChanged(nameof(Sklepy));
            }
        }

        public ObservableCollection<Przewoznik> Przewoznicy
        {
            get { return przewoznicy; }
            set
            {
                przewoznicy = value;
                onPropertyChanged(nameof(Przewoznicy));
            }
        }
        #endregion
    }
}
