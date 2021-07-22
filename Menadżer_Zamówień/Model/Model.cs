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
        public ObservableCollection<string> Usernames { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> SklepyString { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> PrzewoznicyString { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> EnumZwrot { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> EnumStatus { get; set; } = new ObservableCollection<string>();


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
            var usernames = RepozytoriumOsoba.PobierzWszystkieUsername();
            foreach (var u in usernames)
                Usernames.Add(u);
            var sklepyString = RepozytoriumSklep.PobierzNazwySklepow();
            foreach (var ss in sklepyString)
                SklepyString.Add(ss);
            var przewoznicyString = RepozytoriumPrzewoznik.PobierzNazwyPrzewoznikow();
            foreach (var ps in przewoznicyString)
                PrzewoznicyString.Add(ps);
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

        public bool DodajZamDoBazy(Zamowienie zamowienie)
        {
            if (RepozytoriumZamowienie.DodajZamowienie(zamowienie))
            {
                Zamowienia.Add(zamowienie);
                return true;
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

        public int ZnajdzIdPoSklepie(string nazwa)
        {
            foreach(var s in Sklepy)
            {
                if (s.Nazwa == nazwa)
                    return s.IdS;
            }
            return 0;
        }
        public int ZnajdzIdPoPrzew(string nazwa)
        {
            foreach(var p in Przewoznicy)
            {
                string[] splitNazwa = nazwa.Split('-');
                if (p.Firma == splitNazwa[1].Trim() && p.Rodzaj == splitNazwa[0].Trim())
                {
                    return p.IdP;
                }
            }
            return 0; 
        }

        public List<String> DostarczoneDzisiaj(Osoba osoba)
        {
            List<string> Dzisiaj = new List<string>();
            foreach (Menadżer_Zamówień.DAL.Encje.Zamowienie element in Zamowienia)
            {
                if (element.Username == osoba.Username)
                {
                    if (element.DataEst == DateTime.Today.ToString("dd.MM.yyyy"))
                    {
                        string NowaPozcyja = element.Co.ToString() + " " + "(zamówione " + element.DataZam.ToString() + ")";
                        Dzisiaj.Add(NowaPozcyja);
                    }
                }
            }
            return Dzisiaj;
        }
    }
}
