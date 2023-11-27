using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GitVoyager.Repositories
{
    public class GithubRepository : IGithubRepository
    {
        private static GithubRepository _instance;
        private readonly GitHubClient _client;

        public GithubRepository()
        {
            _client = new GitHubClient(new ProductHeaderValue("GitVoyager"));
        }
        public static GithubRepository Instance => _instance ?? (_instance = new GithubRepository());

        public async Task<User> GetUser(string username)
        {
            try
            {
                return await _client.User.Get(username);
            }
            catch (NotFoundException e)
            {
                //to error message
                return null;
            }
            catch (Exception ex)
            {
                //handle it later
                return null;
            }
        }
    }
}
