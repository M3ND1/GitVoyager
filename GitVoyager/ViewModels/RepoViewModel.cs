using GitVoyager.Models;
using GitVoyager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GitVoyager.ViewModels
{
    public class RepoViewModel : ViewModelBase
    {
        private UserModel _userModel;
        private IGithubRepository githubRepository;
        public UserModel UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged(nameof(UserModel)); }
        }
        public RepoViewModel()
        {
            githubRepository = new GithubRepository();
            LoadCurrentUserRepositories();
        }

        private async void LoadCurrentUserRepositories()
        {
            var user = await githubRepository.GetUser(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                UserModel = new UserModel(user);
            } 
            else
            {
                UserModel.Name = "SOMETHINGWENTWRONG";
            }

        }
    }
}
