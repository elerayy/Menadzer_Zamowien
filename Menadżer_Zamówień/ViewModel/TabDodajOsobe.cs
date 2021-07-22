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

    class TabDodajOsobe : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Osoba> osoby = null;
        private string username, imie, nazwisko, adres, nrTel;
        private int idZaznaczenia = -1;
        private bool dodawanieDostepne = true;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabDodajOsobe(Model model)
        {
            this.model = model;
            osoby = model.Osoby;
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Osoba> Osoby
        {
            get { return osoby; }
            set
            {
                osoby = value;
                onPropertyChanged(nameof(Osoby));
            }
        }

        public Osoba BiezacaOsoba { get; set; }

        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
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

        public string Imie
        {
            get { return imie; }
            set
            {
                imie = value;
                onPropertyChanged(nameof(Imie));
            }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        public string Adres
        {
            get { return adres; }
            set
            {
                adres = value;
                onPropertyChanged(nameof(Adres));
            }
        }

        public string NrTel
        {
            get { return nrTel; }
            set
            {
                nrTel = value;
                onPropertyChanged(nameof(NrTel));
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

        public bool EdycjaDostepna
        {
            get { return edycjaDostepna; }
            set
            {
                edycjaDostepna = value;
                onPropertyChanged(nameof(EdycjaDostepna));
            }
        }

        public void CzyscFormularz()
        {
            Username = "";
            Imie = "";
            Nazwisko = "";
            Adres = "";
            NrTel = "";
            DodawanieDostepne = true;
        }
        #endregion

        #region Polecenia
        private ICommand dodaj = null;

        public ICommand Dodaj
        {
            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var osoba = new Osoba(Username, Imie, Nazwisko, Adres, NrTel);

                            if (model.DodajOsobeDoBazy(osoba))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Osoba pomyślnie dodana do bazy!");
                            }
                        },
                        arg => (Username != "") && (Imie != "") && (Nazwisko != "") && (Adres != "") && (NrTel != ""));

                return dodaj;
            }
        }

        private ICommand ladujDane = null;
        public ICommand LadujDane
        {
            get
            {
                if(ladujDane == null)
                    ladujDane = new RelayCommand(
                        arg =>
                        {
                            if(IdZaznaczenia > -1)
                            {
                                Username = BiezacaOsoba.Username;
                                Imie = BiezacaOsoba.Imie;
                                Nazwisko = BiezacaOsoba.Nazwisko;
                                Adres = BiezacaOsoba.Adres;
                                NrTel = BiezacaOsoba.NrTel;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Username = "";
                                Imie = "";
                                Nazwisko = "";
                                Adres = "";
                                NrTel = "";
                                DodawanieDostepne = true;
                                EdycjaDostepna = false;
                            }
                        },
                        arg => true);

                return ladujDane;
            }
        }

        private ICommand edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                        arg =>
                        {
                            model.EdytujOsobe(new Osoba(Username, Imie, Nazwisko, Adres, NrTel));
                            IdZaznaczenia = -1;
                            DodawanieDostepne = true;
                        },
                        arg => (BiezacaOsoba?.Imie != Imie) | (BiezacaOsoba?.Nazwisko != Nazwisko) | (BiezacaOsoba?.Adres != Adres) | (BiezacaOsoba?.NrTel != NrTel));
                
                return edytuj;
            }
        }
        #endregion
    }
}
