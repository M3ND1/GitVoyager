using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GitVoyager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            var searchView = new SearchView();
            searchView.Show();
            searchView.IsVisibleChanged += (s, ev) =>
            {
                if (searchView.IsVisible == false && searchView.IsLoaded)
                {
                    var repoView = new RepoView();
                    repoView.Show();
                    searchView.Close();
                }
            };
        }
    }
}
