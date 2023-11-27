using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GitVoyager.Models;
using GitVoyager.Repositories;
using Newtonsoft.Json;

namespace GitVoyager.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _username;
        private string _errorMessage;
        private bool _isVisible = true;
        private IGithubRepository _githubRepository;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsVisibleChanged
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisibleChanged));
            }
        }
        public ICommand SearchRepoCommand { get; }

        public SearchViewModel()
        {
            _githubRepository = new GithubRepository();
            SearchRepoCommand = new ViewModelCommand(ExecuteSearchRepoCommand, CanExecuteSearchRepoCommand);
        }

        private bool CanExecuteSearchRepoCommand(object obj)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(Username) || Username == null || Username.Length == 0)
                isValid = false;

            return isValid;
        }

        private async void ExecuteSearchRepoCommand(object obj)
        {
            var user = await _githubRepository.GetUser(_username);
            if(user != null)
            {
                //var user = JsonConvert.DeserializeObject<UserModel>(isValidUsername.Result.ToString());
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username),null);
                IsVisibleChanged = false;
            }
            else
            {
                ErrorMessage = "* Something went wrong";
            }
        }
    }
}
