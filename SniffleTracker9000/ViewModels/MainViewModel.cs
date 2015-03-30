// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Veritix">
//   Copyright (c) Veritix. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SniffleTracker9000.ViewModels
{
    using System.Collections.Generic;

    using SniffleTracker9000.Models;

    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel
    {
        #region Constructors and Destructors
        
        public MainViewModel()
        {
            this.Sniffles = new List<Sniffle>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the sniffles.
        /// </summary>
        public IList<Sniffle> Sniffles { get; set; }

        #endregion
    }
}