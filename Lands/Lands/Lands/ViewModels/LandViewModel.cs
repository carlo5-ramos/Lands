using Lands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    public class LandViewModel
    {
        #region MyRegion

        #endregion

        #region Properties
        public Land Land { get; set; }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
        }
        #endregion


    }
}
