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
    using System.Globalization;

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
        private bool edycjaDostepna = false;
        private sbyte? id;
        private string co, status, zwrot, username, nazwaSklepu, przewoznik, idP, idS = "";
        private DateTime dataEst = DateTime.Now.Date;
        private DateTime dataZam = DateTime.Now.Date;
        private float koszt = 0.0F;
        private int idStatus = -1;
        private int idZwrot = -1;
        private int idNazwaSklep = -1;
        private int idTypPrzew = -1;
        private int idUsername= -1;
        private int idZaznaczenia = -1;
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

        public Zamowienie BiezaceZamowienie { get; set; }

        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }

        public bool EdycjaDostepna
        {
            get { return edycjaDostepna; }
            set
            {
                edycjaDostepna = value;
                onPropertyChanged(nameof(EdycjaDostepna));
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

        public string IdS
        {
            get { return idS; }
            set
            {
                idS = value;
                onPropertyChanged(nameof(IdS));
            }
        }

        public string IdP
        {
            get { return idP; }
            set
            {
                idP = value;
                onPropertyChanged(nameof(IdP));
            }
        }

        public sbyte? Id
        {
            get { return id; }
            set
            {
                id = value;
                onPropertyChanged(nameof(Id));
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

        public int IdStatus
        {
            get { return idStatus; }
            set
            {
                idStatus = value;
                onPropertyChanged(nameof(IdStatus));
            }
        }

        public int IdZwrot
        {
            get { return idZwrot; }
            set
            {
                idZwrot = value;
                onPropertyChanged(nameof(IdZwrot));
            }
        }

        public int IdUsername
        {
            get { return idUsername; }
            set
            {
                idUsername = value;
                onPropertyChanged(nameof(IdUsername));
            }
        }

        public int IdTypPrzew
        {
            get { return idTypPrzew; }
            set
            {
                idTypPrzew = value;
                onPropertyChanged(nameof(IdTypPrzew));
            }
        }

        public int IdNazwaSklep
        {
            get { return idNazwaSklep; }
            set
            {
                idNazwaSklep = value;
                onPropertyChanged(nameof(IdNazwaSklep));
            }
        }
        #endregion

        #region Polecenia
        public void CzyscFormularz()
        {
            Co = "";
            Koszt = 0.0F;
            DataZam = DataDzis;
            DataEst = DataDzis;
            Status = null;
            Zwrot = null;
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
                                model.OdswiezDane();
                                System.Windows.MessageBox.Show("Zamówienie pomyślnie dodane do bazy!");
                            }
                        },
                        arg => (Co != "") && (IdStatus > -1) && (IdZwrot > -1) && (IdUsername > -1) && (IdNazwaSklep > -1) && (IdTypPrzew > -1));
                return dodaj;
            }
        }

        private ICommand ladujDane;
        public ICommand LadujDane
        {
            get
            {
                if (ladujDane == null)
                    ladujDane = new RelayCommand(
                        arg =>
                        {
                            if (IdZaznaczenia > -1)
                            {
                                Id = BiezaceZamowienie.Id;
                                Co = BiezaceZamowienie.Co;
                                Koszt = BiezaceZamowienie.Koszt;
                                string[] dataZ = BiezaceZamowienie.DataZam.ToString().Split(' ');
                                dataZ = dataZ[0].Split('.');
                                DataZam = new DateTime(int.Parse(dataZ[2]), int.Parse(dataZ[1]), int.Parse(dataZ[0])).Date;
                                string[] dataE = BiezaceZamowienie.DataEst.ToString().Split(' ');
                                dataE = dataE[0].Split('.');
                                DataEst = new DateTime(int.Parse(dataE[2]), int.Parse(dataE[1]), int.Parse(dataE[0])).Date;
                                Status = BiezaceZamowienie.Status;
                                Zwrot = BiezaceZamowienie.Zwrot;
                                Username = BiezaceZamowienie.Username;
                                NazwaSklepu = BiezaceZamowienie.IdS;
                                Przewoznik = BiezaceZamowienie.IdP;
                                IdS = BiezaceZamowienie.IdS;
                                IdP = BiezaceZamowienie.IdP;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Co = "";
                                Koszt = 0;
                                DataZam = DateTime.Now.Date;
                                DataEst = DateTime.Now.Date;
                                Status = "";
                                Zwrot = "";
                                Username = "";
                                IdS = null;
                                IdP = null;
                                NazwaSklepu = "";
                                Przewoznik = "";
                                DodawanieDostepne = true;
                                EdycjaDostepna = false;
                            }
                        },
                        arg => true);

                return ladujDane;
            }
        }

        private ICommand edytujZamowienie = null;
        public ICommand EdytujZamowienie
        {
            get
            {
                if (edytujZamowienie == null)
                    edytujZamowienie = new RelayCommand(
                        arg =>
                        {
                            model.EdytujZamowienie(new Zamowienie(Co, Koszt, DataZam.Date.ToString("yyyy-MM-dd"), DataEst.Date.ToString("yyyy-MM-dd"), Status, Zwrot, Username, IdS, IdP), BiezaceZamowienie.Id);
                            IdZaznaczenia = -1;
                            DodawanieDostepne = true;
                            model.OdswiezDane();
                        },
                        arg => (BiezaceZamowienie?.Co != Co) | (BiezaceZamowienie?.Koszt != Koszt) | (BiezaceZamowienie?.DataZam != DataZam.Date.ToString("yyyy-MM-dd")) | (BiezaceZamowienie?.DataEst != DataEst.Date.ToString("yyyy-MM-dd")) | (BiezaceZamowienie?.Status != Status) | (BiezaceZamowienie?.Zwrot != Zwrot) | (BiezaceZamowienie?.Username != Username) | (BiezaceZamowienie?.IdS != IdS) | (BiezaceZamowienie?.IdP != IdP));

                return edytujZamowienie;
            }
        }

        private ICommand updateUsernames;
        public ICommand UpdateUsernames
        {
            get
            {
                return updateUsernames ?? (updateUsernames = new RelayCommand(
                    p => { Usernames = model.UpdateUsers(); },
                    p => true
                    ));
            }
        }

        #endregion
    }
}
