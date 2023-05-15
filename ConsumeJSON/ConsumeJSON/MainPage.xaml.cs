using ConsumeJSON.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsumeJSON
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<TestModel> myobj;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ConsumeJSON.testmodels.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                List<TestModel> mylist = JsonConvert.DeserializeObject<List<TestModel>>(json);
                myobj = new ObservableCollection<TestModel>(mylist);
                MyListView.ItemsSource = myobj;
            }

        }
    }
}
