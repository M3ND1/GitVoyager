using FontAwesome.Sharp;
using GitVoyager.Models;
using GitVoyager.Repositories;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GitVoyager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserModel _userModel;
        private IGithubRepository githubRepository;
        private IReadOnlyList<GitHubRepositoryModel> _repositoryList;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        public UserModel UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged(nameof(UserModel)); }
        }

        public IReadOnlyList<GitHubRepositoryModel> RepositoryList
        {
            get { return _repositoryList; }
            set { _repositoryList = value; OnPropertyChanged(nameof(RepositoryList)); }
        }

        public ViewModelBase CurrentChildView 
        { 
            get { return _currentChildView; }
            set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } 
        }
        public string Caption 
        {
            get { return _caption; }
            set { _caption = value; OnPropertyChanged(nameof(Caption)); } 
        }
        public IconChar Icon 
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(nameof(Icon)); }
        }
        public ICommand ShowMainViewCommand { get; }
        public ICommand ShowRepoViewCommand { get; }
        public ICommand ShowFollowedRepoViewCommand { get; }
        public MainViewModel()
        {
            githubRepository = new GithubRepository();
            //ShowMainViewCommand = new ViewModelCommand(ExecuteShowMainViewCommand, null);
            ShowRepoViewCommand = new ViewModelCommand(ExecuteShowRepoViewCommand, null);
            ShowFollowedRepoViewCommand = new ViewModelCommand(ExecuteShowFollowedRepoViewCommand, null);
            ExecuteShowRepoViewCommand(null);

            LoadExistingUser();
        }

        private void ExecuteShowFollowedRepoViewCommand(object obj)
        {
            CurrentChildView = new FollowedRepoViewModel();
            Caption = "Followed Repositories";
            Icon = IconChar.CodeBranch;
        }

        private void ExecuteShowRepoViewCommand(object obj)
        {
            CurrentChildView = new RepoViewModel();
            Caption = "Your Repositories";
            Icon = IconChar.CodeBranch;
        }

        private void ExecuteShowMainViewCommand(object obj)
        {
            CurrentChildView = new MainViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private async void LoadExistingUser()
        {
            var user = await githubRepository.GetUser(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                UserModel = new UserModel(user);
            } 
            else
            {
                //UserModel.Name = "";
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
