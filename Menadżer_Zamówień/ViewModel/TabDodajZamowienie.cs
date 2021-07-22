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
    using System.Windows.Input;

    class TabDodajZamowienie : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Zamowienie> zamowienia = null;
        private ObservableCollection<string> sklepy = null;
        private DateTime dataDzis = DateTime.Now.Date;
        private ObservableCollection<string> usernames = null;
        private ObservableCollection<string> przewoznicy = null;
        private List<string> zwroty = new List<string>{ "tak", "nie" };
        private List<string> statusy = new List<string> { "w trakcie", "odebrane" };
        #endregion

        #region Konstruktory
        public TabDodajZamowienie(Model model)
        {
            this.model = model;
            zamowienia = model.Zamowienia;
            usernames = model.Usernames;
            sklepy = model.SklepyString;
            przewoznicy = model.PrzewoznicyString;
        }
        #endregion

        #region Właściwości
        public ObservableCollection<Zamowienie> Zamowienia
        {
            get { return zamowienia; }
            set
            {
                zamowienia = value;
                onPropertyChanged(nameof(Zamowienia));
            }
        }

        public ObservableCollection<string> Sklepy
        {
            get { return sklepy; }
            set
            {
                sklepy = value;
                onPropertyChanged(nameof(Sklepy));
            }
        }

        public ObservableCollection<string> Usernames
        {
            get { return usernames; }
            set
            {
                usernames = value;
                onPropertyChanged(nameof(Usernames));
            }
        }

        public ObservableCollection<string> Przewoznicy
        {
            get { return przewoznicy; }
            set
            {
                przewoznicy = value;
                onPropertyChanged(nameof(Przewoznicy));
            }
        }
        public List<string> Zwroty
        {
            get { return zwroty; }
            set
            {
                zwroty = value;
                onPropertyChanged(nameof(Zwroty));
            }
        }
        public List<string> Statusy
        {
            get { return statusy; }
            set
            {
                statusy = value;
                onPropertyChanged(nameof(Statusy));
            }
        }

        public DateTime DataDzis
        {
            get { return dataDzis; }
            set
            {
                dataDzis = value;
            }
        }
        #endregion

        #region Polecenia
        #endregion
    }
}
