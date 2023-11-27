using GitVoyager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitVoyager.ViewModels
{
    public class RepoViewModel : ViewModelBase
    {
        private UserModel _userModel;
        public UserModel UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged(nameof(UserModel)); }
        }
        public RepoViewModel()
        {

        }
    }
}
