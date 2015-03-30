// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Veritix">
//   Copyright (c) Veritix. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SniffleTracker9000.Controllers
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    using Dapper;

    using SniffleTracker9000.Models;
    using SniffleTracker9000.ViewModels;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Fields

        /// <summary>
        /// The view model.
        /// </summary>
        private readonly MainViewModel viewModel = new MainViewModel();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Renders the index view.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Sniffle"].ConnectionString))
            {
                connection.Open();
                this.viewModel.Sniffles = connection.Query<Sniffle>("SELECT * FROM [Sniffles] ORDER BY [Date] DESC").ToList();
            }

            return this.View(this.viewModel);
        }

        /// <summary>
        /// Adds a sniffle.
        /// </summary>
        /// <param name="newViewModel">
        /// The new view model.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult AddSniffle(MainViewModel newViewModel)
        {
            var date = DateTime.UtcNow.ToString("o");
            var sniffle = new Sniffle { Date = date };

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Sniffle"].ConnectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO [Sniffles] ([Date]) VALUES (@Date)", sniffle);
                newViewModel.Sniffles = connection.Query<Sniffle>("SELECT * FROM [Sniffles] ORDER BY [Date] DESC").ToList();
            }

            return this.Json(newViewModel);
        }

        /// <summary>
        /// Removes a sniffle.
        /// </summary>
        /// <param name="newViewModel">
        /// The view model.
        /// </param>
        /// <param name="id">
        /// The identifier to remove.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult" />.
        /// </returns>
        public JsonResult RemoveSniffle(MainViewModel newViewModel, int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Sniffle"].ConnectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM [Sniffles] WHERE [Id] = @Id", new { Id = id });
                newViewModel.Sniffles = connection.Query<Sniffle>("SELECT * FROM [Sniffles] ORDER BY [Date] DESC").ToList();
            }

            return this.Json(newViewModel);
        }

        #endregion
    }
}