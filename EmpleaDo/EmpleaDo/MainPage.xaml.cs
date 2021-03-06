﻿using EmpleaDo.Models;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmpleaDo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            testc();
        }

        public async void testc() {
            // Flurl will use 1 HttpClient instance per host
            var Cards = await "https://emplea-apm.azure-api.net/v1/api"
                .AppendPathSegment("jobs")
                .SetQueryParams(new { pagesize = 10, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", "155d4cd48bb34ba0b8375fd50b779b85")
                .GetJsonAsync<JobsList>();

            ListaEjemplo.HasUnevenRows = true;
            ListaEjemplo.ItemsSource = Cards.Jobs;
        }
    }
}
