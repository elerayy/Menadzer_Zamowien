using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.ViewModel
{
    using Menadżer_Zamówień.Model;
    class MainViewModel
    {
        private Model model = new Model();
        public TabPodglad TabPodgladVM { get; set; }
        public TabDodajOsobe TabDodaOsobeVM { get; set; }
        public TabDodajZamowienie TabDodajZamowienieVM { get; set; }
        public TabPodgladSklepPrzewoznik TabPodgladSklepPrzewoznikVM { get; set; }

        public MainViewModel()
        {
            TabPodgladVM = new TabPodglad(model);
            TabDodaOsobeVM = new TabDodajOsobe(model);
            TabDodajZamowienieVM = new TabDodajZamowienie(model);
            TabPodgladSklepPrzewoznikVM = new TabPodgladSklepPrzewoznik(model);
        }
    }
}
