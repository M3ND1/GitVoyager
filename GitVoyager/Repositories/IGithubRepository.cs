using Octokit;
using System.Threading.Tasks;

namespace GitVoyager.Repositories
{
    public interface IGithubRepository
    {
        Task<User> GetUser(string username);
    }
}