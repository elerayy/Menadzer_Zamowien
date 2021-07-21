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
        private bool dodawanieDostepne = true;
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


        #endregion
    }
}
