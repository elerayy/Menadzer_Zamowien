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
    using System.Windows;

    class TabPodglad : ViewModelBase
    {

        #region Składowe prywatne
        private Model model = null;
        private ObservableCollection<Osoba> osoby = null;
        private ObservableCollection<Zamowienie> zamowienia = null;
        private int indexZaznaczonejOsoby = -1;
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

        public Osoba BiezacaOsoba { get; set; }

        public int IndexZaznaczonejOsoby
        {
            get => indexZaznaczonejOsoby;
            set
            {
                indexZaznaczonejOsoby = value;
                onPropertyChanged(nameof(IndexZaznaczonejOsoby));
            }
        }
        #endregion

        #region Polecenia
        private ICommand zaladujZamowienia = null;

        public ICommand ZaladujZamowienia
        {
            get
            {
                if (zaladujZamowienia == null)
                    zaladujZamowienia = new RelayCommand(
                        arg =>
                        {
                            if (BiezacaOsoba != null)
                                Zamowienia = model.PobierzZamowieniaOsoby(BiezacaOsoba);
                        },
                        arg => true);
                return zaladujZamowienia;
            }
        }

        private ICommand zamowieniaDzisiaj = null;

        public ICommand ZamowieniaDzisiaj
        {
            get
            {
                if (zamowieniaDzisiaj == null)
                {
                    List<String> ListaZamowien = new List<String>();
                    zamowieniaDzisiaj = new RelayCommand(
                        arg =>
                        {
                            if (BiezacaOsoba != null)
                            {
                                ListaZamowien = model.DostarczoneDzisiaj(BiezacaOsoba);
                                if (ListaZamowien.Count > 0)
                                {
                                    string MessageToShow = "Dzisiaj powinny przyjść zamówienia: " + string.Join(", ", ListaZamowien.ToArray());
                                    MessageBox.Show(MessageToShow);
                                }
                            }
                        },
                        arg => true);
                }
                return zamowieniaDzisiaj;
            }
        }

        #endregion
    }
}
