using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class Model
    {
        public ObservableCollection<Osoba> Osoby { get; set; } = new ObservableCollection<Osoba>();
        public ObservableCollection<Zamowienie> Zamowienia { get; set; } = new ObservableCollection<Zamowienie>();
        public ObservableCollection<Sklep> Sklepy { get; set; } = new ObservableCollection<Sklep>();
        public ObservableCollection<Przewoznik> Przewoznicy { get; set; } = new ObservableCollection<Przewoznik>();


        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var osoby = RepozytoriumOsoba.PobierzWszystkieOsoby();
            foreach (var o in osoby)
                Osoby.Add(o);
            var zamowenia = RepozytoriumZamowienie.PobierzZamowienia();
            foreach (var z in zamowenia)
                Zamowienia.Add(z);
            var sklepy = RepozytoriumSklep.PobierzSklepy();
            foreach (var s in sklepy)
                Sklepy.Add(s);
            var przewoznicy = RepozytoriumPrzewoznik.PobierzPrzewoznikow();
            foreach (var p in przewoznicy)
                Przewoznicy.Add(p);
            
        }

        public bool CzyJestOsobaWRepo(Osoba osoba) => Osoby.Contains(osoba);

        public bool DodajOsobeDoBazy(Osoba osoba)
        {
            if (!CzyJestOsobaWRepo(osoba))
            {
                if(RepozytoriumOsoba.DodajOsobe(osoba))
                {
                    Osoby.Add(osoba);
                    return true;
                }
            }
            return false;
        }

        public ObservableCollection<Zamowienie> PobierzZamowieniaOsoby(Osoba osoba)
        {
            var zamowienia = new ObservableCollection<Zamowienie>();
            foreach (var zam in Zamowienia)
            {
                if(osoba.Username == zam.Username)
                {
                    zamowienia.Add(zam);
                }
            }
            return zamowienia;
        }

        public bool EdytujOsobe(Osoba osoba)
        {
            if(RepozytoriumOsoba.EdytujOsobe(osoba,osoba.Username))
            {
                for(int i=0;i<Osoby.Count;i++)
                {
                    if(Osoby[i].Username == osoba.Username)
                    {
                        Osoby[i] = new Osoba(osoba);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
