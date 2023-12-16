using GitVoyager.Models;
using GitVoyager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitVoyager.ViewModels
{
    public class RepoViewModel : ViewModelBase
    {
        private IGithubRepository githubRepository;
        private IReadOnlyList<GitHubRepositoryModel> _repositoryList;

        public IGithubRepository GithubRepository
        {
            get
            {
                return githubRepository;
            }
            set
            {
                githubRepository = value;
                OnPropertyChanged(nameof(GithubRepository));
            }
        }
        public IReadOnlyList<GitHubRepositoryModel> RepositoryList
        {
            get
            {
                return _repositoryList;
            }
            set
            {
                _repositoryList = value;
                OnPropertyChanged(nameof(RepositoryList));
            }
        }
        public RepoViewModel()
        {
            githubRepository = new GithubRepository();
            LoadExistingUserRepositories();
        }
        private async void LoadExistingUserRepositories()
        {
            var userRepos = await GithubRepository.GetUserRepositories(Thread.CurrentPrincipal.Identity.Name);

            if (userRepos != null)
            {
                RepositoryList = userRepos.Select(repo => new GitHubRepositoryModel(repo)).ToList();
            }
        }
    }
}
