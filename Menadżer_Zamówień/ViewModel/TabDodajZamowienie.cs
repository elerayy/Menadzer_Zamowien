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
        private bool dodawanieDostepne = true;
        private string co, status, zwrot, username, nazwaSklepu, przewoznik;
        private DateTime dataEst, dataZam;
        private float koszt;
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

        public string Co
        {
            get { return co; }
            set
            {
                co = value;
                onPropertyChanged(nameof(Co));
            }
        }
        public float Koszt
        {
            get { return koszt; }
            set
            {
                koszt = value;
                onPropertyChanged(nameof(Koszt));
            }
        }
        public DateTime DataEst
        {
            get { return dataEst; }
            set
            {
                dataEst = value;
                onPropertyChanged(nameof(DataEst));
            }
        }

        public DateTime DataZam
        {
            get { return dataZam; }
            set
            {
                dataZam = value;
                onPropertyChanged(nameof(DataZam));
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                onPropertyChanged(nameof(Status));
            }
        }

        public string Zwrot
        {
            get { return zwrot; }
            set
            {
                zwrot = value;
                onPropertyChanged(nameof(Zwrot));
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                onPropertyChanged(nameof(Username));
            }
        }

        public string NazwaSklepu
        {
            get { return nazwaSklepu; }
            set
            {
                nazwaSklepu = value;
                onPropertyChanged(nameof(NazwaSklepu));
            }
        }

        public string Przewoznik
        {
            get { return przewoznik; }
            set
            {
                przewoznik = value;
                onPropertyChanged(nameof(Przewoznik));
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

        public bool DodawanieDostepne
        {
            get { return dodawanieDostepne; }
            set
            {
                dodawanieDostepne = value;
                onPropertyChanged(nameof(DodawanieDostepne));
            }
        }
        #endregion

        #region Polecenia
        public void CzyscFormularz()
        {
            Co = "";
            Koszt = 0;
            DodawanieDostepne = true;
        }

        private ICommand dodaj = null;

        public ICommand Dodaj
        {
            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var idSklep = model.ZnajdzIdPoSklepie(NazwaSklepu);
                            var idPrzew = model.ZnajdzIdPoPrzew(Przewoznik);
                            string dataz = DataZam.Date.ToString("yyyy-MM-dd");
                            string datae = DataEst.Date.ToString("yyyy-MM-dd");
                            var zamowienie = new Zamowienie(Co,Koszt,dataz, datae, Status,Zwrot,Username,idSklep.ToString(),idPrzew.ToString());

                            if (model.DodajZamDoBazy(zamowienie))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Zamówienie pomyślnie dodane do bazy!");
                            }
                        },
                        //arg => (Co != "") && (Status != null) && (Zwrot != null) && (Username != null) && (NazwaSklepu != null) && (przewoznik != null));
                        arg => (Co != ""));
                return dodaj;
            }
        }
        #endregion
    }
}
