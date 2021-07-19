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

    class TabDodajZamowienie : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        #endregion

        #region Konstruktory
        public TabDodajZamowienie(Model model)
        {
            this.model = model;
            // !!!!!!!!!! 
        }
        #endregion
    }
}
