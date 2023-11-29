using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitVoyager.Repositories
{
    public interface IGithubRepository
    {
        Task<User> GetUser(string username);
        Task<IReadOnlyList<Repository>> GetUserRepositories(string username);
    }
}