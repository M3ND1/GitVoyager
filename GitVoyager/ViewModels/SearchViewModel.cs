using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GitVoyager.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _username;
        private string _errorMessage;
        private bool _isVisible = true;

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
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        public ICommand SearchRepoCommand { get; }

        public SearchViewModel()
        {
            SearchRepoCommand = new ViewModelCommand(ExecuteSearchRepoCommand, CanExecuteSearchRepoCommand);
        }

        private bool CanExecuteSearchRepoCommand(object obj)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(Username) || Username == null || Username.Length == 0)
                isValid = false;

            return isValid;
        }

        private void ExecuteSearchRepoCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
