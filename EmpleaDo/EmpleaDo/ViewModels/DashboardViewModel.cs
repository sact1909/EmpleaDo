using EmpleaDo.Models;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmpleaDo.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Job> Jobss { get; set; }
        public Command LlenarListaCommand { get; set; }
        public DashboardViewModel() {

            new Action(async () => await cargarDatos())();
           

        }


        public async Task cargarDatos() {
            var Cards = await "https://emplea-apm.azure-api.net/v1/api"
                .AppendPathSegment("jobs")
                .SetQueryParams(new { pagesize = 10, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", "155d4cd48bb34ba0b8375fd50b779b85")
                .GetJsonAsync<JobsList>();

            Jobss = new ObservableCollection<Job>(Cards.Jobs);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
